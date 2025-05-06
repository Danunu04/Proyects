using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _686DP_Dal
{
    public class _686DPDalGeneral
    {
        //public SqlConnection conn = new SqlConnection(@"Data Source=DANAPC;Initial Catalog=AseguraYA;Integrated Security=True");
        public SqlConnection conn = new SqlConnection(@"Data Source=TECBI004\DBPERSONAL;Initial Catalog=AseguraYA;Integrated Security=True");
        public SqlCommand cmd;
        public DataTable _686DPConsultar(string consulta, ArrayList parametros)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter DA;
            cmd = new SqlCommand(consulta, conn);
            cmd.CommandType = CommandType.Text;

            try
            {
                if (parametros != null)
                {
                    foreach (SqlParameter dato in parametros)
                    {
                        cmd.Parameters.AddWithValue(dato.ParameterName, dato.Value);
                    }
                }

                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }

                DA = new SqlDataAdapter(cmd);
                DA.Fill(dt);
            }
            catch (SqlException ex)
            {
                throw new Exception("Error SQL: Hubo un error al realizar la consulta" );
            }
            catch (Exception ex)
            {
                throw new Exception("🛑 Error inesperado en la operación de consulta: " + ex.Message, ex);
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }

            return dt;
        }

        public void _686DPEscribir(string consulta, ArrayList parametros)
        {
            cmd = new SqlCommand(consulta, conn);
            cmd.CommandType = CommandType.Text;

            try
            {
                if (parametros != null)
                {
                    foreach (SqlParameter dato in parametros)
                    {
                        cmd.Parameters.AddWithValue(dato.ParameterName, dato.Value);
                    }
                }

                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }

                cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                throw new Exception("⚠️ Se produjo un error al ejecutar una escritura SQL.");
            }
            catch (Exception ex)
            {
                throw new Exception("🛑 Error general al ejecutar la instrucción SQL: " + ex.Message, ex);
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
        }
    }
}
