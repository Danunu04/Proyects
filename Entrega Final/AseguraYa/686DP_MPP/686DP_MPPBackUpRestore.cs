using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _686DP_Dal;

namespace _686DP_MPP
{
    public class _686DP_MPPBackUpRestore
    {
        _686DPDalGeneral DAL = new _686DPDalGeneral();
        public void RealizarBackupBD(string rutaArchivo)
        {
            try
            {
                string rutaEscapada = rutaArchivo.Replace(@"\", @"\\");

                string consulta = $@"
                    BACKUP DATABASE [AseguraYa]
                    TO DISK = @Ruta
                    WITH INIT;"; 

                ArrayList parametros = new ArrayList
                {
                    new SqlParameter("@Ruta", rutaArchivo)
                };
                DAL._686DPEscribir(consulta, parametros);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al realizar el backup: " + ex.Message);
            }
        }

        public void RealizarRestoreBD(string rutaArchivoBackup)
        {
            try
            {
                string rutaEscapada = rutaArchivoBackup.Replace(@"\", @"\\");

                string consulta = $@"
                   USE master;
                   GO
                    RESTORE FILELISTONLY 
                    FROM DISK = @Ruta;
                    GO

                    -- Restaurar la base
                    RESTORE DATABASE AseguraYa
                    FROM DISK = @Ruta
                    WITH 
                        MOVE 'AseguraYA'     TO @Ruta + 'AseguraYA.mdf',
                        MOVE 'AseguraYA_log' TO @Ruta + 'AseguraYA_log.ldf',
                        REPLACE,
                        STATS = 5;
                    ";

                ArrayList parametros = new ArrayList
                {
                    new SqlParameter("@Ruta", rutaArchivoBackup)
                };

                DAL._686DPEscribir(consulta, parametros);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al realizar el restore: " + ex.Message);
            }
        }
    }
}
