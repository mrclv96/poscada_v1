using System;
using System.Data;
using Microsoft.Data.SqlClient;


namespace SCADA_A.Datos
{
    public class DErrTrace
    { 
        public void ExErrTrace(Exception ex, string ProcedurName)
        {
            string Rpta = "";
            string hResultHexString = "0x" + ex.HResult.ToString("x");

            try
            {
                Rpta = CrearErrTrace(ProcedurName, ex.Message + " " + ex.InnerException.Message, hResultHexString, ex.Source);
            }
            catch (Exception ex2)
            {
                Rpta = ex2.Message;
            }

        }

        public string CrearErrTrace(string ProcedurName, string ErrDescription, string ErrNumber, string ErrSource)
        {
            string Rpta = "";
            SqlDataReader Resultado;
            SqlConnection SqlCon = new SqlConnection();

            try
            {
                SqlCon = Conexion.getInstancia().CrearConexion();
                SqlCommand Comando = new SqlCommand("errTrace_insertar", SqlCon);
                Comando.CommandType = CommandType.StoredProcedure;
                
                Comando.Parameters.Add("@ProcedurName", SqlDbType.VarChar).Value = ProcedurName;
                Comando.Parameters.Add("@ErrNumber", SqlDbType.VarChar).Value = ErrNumber;
                Comando.Parameters.Add("@ErrSource", SqlDbType.VarChar).Value = "VS: " + ErrSource;
                Comando.Parameters.Add("@ErrDescription", SqlDbType.VarChar).Value = ErrDescription;

                SqlCon.Open();
                Resultado = Comando.ExecuteReader();

                return Rpta;
            }
            catch (Exception ex)
            {
                Rpta = ex.Message;
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
            }
            return Rpta;

        }
    }
}
