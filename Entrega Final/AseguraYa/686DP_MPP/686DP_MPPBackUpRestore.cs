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
                string backup = rutaArchivoBackup;
                string mdfPath = @"C:\SQLData\AseguraYA.mdf";
                string ldfPath = @"C:\SQLData\AseguraYA_log.ldf";

                string consulta = @"
                USE master;
                ALTER DATABASE AseguraYa SET SINGLE_USER WITH ROLLBACK IMMEDIATE;

                RESTORE DATABASE AseguraYa
                FROM DISK = @Ruta
                WITH 
                    MOVE 'AseguraYA'     TO @Mdf,
                    MOVE 'AseguraYA_log' TO @Ldf,
                REPLACE,
                STATS = 5;

                ALTER DATABASE AseguraYa SET MULTI_USER;
                ";

                ArrayList parametros = new ArrayList
                {
                    new SqlParameter("@Ruta", backup),
                    new SqlParameter("@Mdf", mdfPath),
                    new SqlParameter("@Ldf", ldfPath)
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
