using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using BusinessModel;

namespace API.REST_MFC.DataAccess
{
    public class AccesoDatos
    {
        string cadenaconexion = System.Configuration.ConfigurationManager.ConnectionStrings["dbMFC"].ToString();
        /// <summary>
        /// Consulta Saldos de los matrimonios, si Nivel_Usuario=1 trae todos, de lo contrario trae el ID_Usuario indicado 
        /// </summary>
        /// <param name="ID_Usuario"></param>
        /// <param name="Nivel_Usuario"></param>
        /// <returns></returns>
        public DataTable ObtenerSaldos(int ID_Usuario)
        {
            //List<Saldos> ListaSaldos = new List<Saldos>();
            DataTable tblSaldos = new DataTable();
            try
            {
                SqlConnection conexion = new SqlConnection(cadenaconexion);
                conexion.Open();
                SqlCommand comando = new SqlCommand("spt_Consulta_Saldos2", conexion);
                comando.Parameters.Add("@ID_Usuario", SqlDbType.Int).Value = ID_Usuario;

                comando.CommandType = CommandType.StoredProcedure;
                System.Data.SqlClient.SqlDataAdapter adapter = new System.Data.SqlClient.SqlDataAdapter(comando);
                DataSet ds = new DataSet();
                adapter.Fill(ds);
                tblSaldos = ds.Tables[0];
                //DataTable tblDetalleContacto = ds.Tables[1];
                //ListaSaldos.Add(new Saldos
                //{
                //    Matrimonio_ID = (int)tblSaldos.Rows[0]["Matrimonio_ID"],
                //    MatrimonioPM = tblSaldos.Rows[0]["MatrimonioPM"].ToString(),
                //    NombreEsposa = tblSaldos.Rows[0]["NombreEsposa"].ToString(),
                //    NombreEsposo = tblSaldos.Rows[0]["NombreEsposo"].ToString(),
                //    FechaMatrimonio = (DateTime)tblSaldos.Rows[0]["FechaMatrimonio"],
                //    Nivel = (int)tblSaldos.Rows[0]["Nivel"],
                //    Mensualidad = (decimal)tblSaldos.Rows[0]["Mensualidad"],
                //    TotalaPagar = (decimal)tblSaldos.Rows[0]["TotalaPagar"],
                //    Saldo = (decimal)tblSaldos.Rows[0]["Saldo"],
                //    ID_Usuario = (int)tblSaldos.Rows[0]["ID_Usuario"],
                //    Nivel_Usuario = (int)tblSaldos.Rows[0]["Nivel_Usuario"]
                //});

                //SqlDataReader reader;
                ////Con conectados
                //comando.CommandType = CommandType.StoredProcedure;

                //reader = comando.ExecuteReader();
                //while (reader.Read())
                //{
                //    ListaPersona.Add(new Persona
                //    {
                //        CURP = reader["per_CURP"].ToString(),
                //        ApellidoPaterno = reader["per_ApellidoPaterno"].ToString(),
                //        ApellidoMaterno = reader["per_ApellidoMaterno"].ToString(),
                //        Nombre = reader["per_NOMBRE"].ToString(),
                //        Genero = reader["per_Genero"].ToString(),
                //        FechaNacimiento = reader["per_FechaNacimiento"].ToString()
                //    });

                //}
                //reader.Close();
                conexion.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return tblSaldos;
        }

        /// <summary>
        /// Consulta los bonos del ID del matrimonio
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public DataTable ObtenerAbonos(int ID)
        {
            DataTable tblAbonos = new DataTable();
            try
            {
                SqlConnection conexion = new SqlConnection(cadenaconexion);
                conexion.Open();
                SqlCommand comando = new SqlCommand("spt_Consulta_Abonos2", conexion);
                comando.Parameters.Add("@Matrimonio_ID", SqlDbType.Int).Value = ID;

                comando.CommandType = CommandType.StoredProcedure;
                System.Data.SqlClient.SqlDataAdapter adapter = new System.Data.SqlClient.SqlDataAdapter(comando);
                DataSet ds = new DataSet();
                adapter.Fill(ds);
                tblAbonos = ds.Tables[0];
               
                conexion.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return tblAbonos;
        }

        /// <summary>
        /// Obtiene los datos del usuario: ID,Usuario,Password,Nivel_Usuario
        /// </summary>
        /// <param name="Usuario"></param>
        /// <param name="Password"></param>
        /// <returns></returns>
        public DataTable ObtenerAcceso(string Usuario, string Password)
        {
            SqlConnection conexion = new SqlConnection(cadenaconexion);
            DataTable dt=new DataTable();
            try
            {
                SqlCommand comando = new SqlCommand("select * from Usuarios where Usuario=@Usuario and Password=@Password", conexion);
                comando.Parameters.Add("@Usuario", SqlDbType.VarChar,50).Value = Usuario;
                comando.Parameters.Add("@Password", SqlDbType.VarChar,50).Value = Password;

                conexion.Open();

                SqlDataReader dr = comando.ExecuteReader(CommandBehavior.CloseConnection);
                dt = new DataTable();
                dt.Load(dr);
            }

            catch (SqlException ex)
            {
                // handle error 
            }

            catch (Exception ex)
            {
                // handle error 
            }

            finally
            {
                conexion.Close();
            }
            return dt;
        }


        /// <summary>
        /// Inserta nuevo Matrimonio
        /// </summary>
        /// <param name="Matrimonio"></param>
        /// <param name="NombreEsposa"></param>
        /// <param name="NombreEsposo"></param>
        /// <param name="FechaMatrimonio"></param>
        /// <param name="Nivel"></param>
        /// <param name="Mensualidad"></param>
        /// <param name="ID_Usuario"></param>
        /// <param name="Nivel_Usuario"></param>
        /// <returns></returns>
        public bool AgregarMatrimonio(string Matrimonio, string NombreEsposa, string NombreEsposo, DateTime FechaMatrimonio, int Nivel, decimal Mensualidad,int ID_Usuario,string Resultado)
        {
            bool Insertado = true;
            try
            {
                SqlConnection conexion = new SqlConnection(cadenaconexion);
                int res = 0;
                conexion.Open();
                SqlCommand comando = new SqlCommand("spt_Inserta_Matrimonio2", conexion);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@Matrimonio", Matrimonio);
                comando.Parameters.AddWithValue("@NombreEsposa", NombreEsposa);
                comando.Parameters.AddWithValue("@NombreEsposo", NombreEsposo);
                comando.Parameters.AddWithValue("@FechaMatrimonio", FechaMatrimonio);
                comando.Parameters.AddWithValue("@Nivel", Nivel);
                comando.Parameters.AddWithValue("@Mensualidad", Mensualidad);
                comando.Parameters.AddWithValue("@ID_Usuario", ID_Usuario);
                comando.Parameters.AddWithValue("@Resultado", Resultado);

                res = comando.ExecuteNonQuery();

                conexion.Close();
            }
            catch (Exception ex)
            {
                Insertado = false;
                throw ex;
            }
            return Insertado;
        }

        public bool AgregarAbono(int Matrimonio_ID, DateTime Fecha, decimal Abono,  string Observacion)
        {
            bool Insertado = true;
            try
            {
                SqlConnection conexion = new SqlConnection(cadenaconexion);
                int res = 0;
                conexion.Open();
                SqlCommand comando = new SqlCommand("spt_Inserta_Abono", conexion);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@Matrimonio_ID", Matrimonio_ID);
                comando.Parameters.AddWithValue("@Fecha", Fecha);
                comando.Parameters.AddWithValue("@Abono", Abono);
                comando.Parameters.AddWithValue("@Observacion", Observacion);

                res = comando.ExecuteNonQuery();

                conexion.Close();
            }
            catch (Exception ex)
            {
                Insertado = false;
                throw ex;
            }
            return Insertado;
        }

        public bool BorrarMatrimonio(int ID)
        {
            bool Borrado = true;
            try
            {
                SqlConnection conexion = new SqlConnection(cadenaconexion);
                int res = 0;
                conexion.Open();
                SqlCommand comando = new SqlCommand("spt_Delete_Matrimonio", conexion);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@ID", ID);

                res = comando.ExecuteNonQuery();
                Borrado = true;
                conexion.Close();
            }
            catch (Exception ex)
            {
                Borrado = false;
                throw ex;
            }
            return Borrado;
        }
    }
}



