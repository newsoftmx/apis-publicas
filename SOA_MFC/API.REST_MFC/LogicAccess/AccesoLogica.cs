using API.REST_MFC.DataAccess;
using BusinessModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;


namespace API.REST_MFC.LogicAccess
{
    public class AccesoLogica
    {
        /// <summary>
        /// Obtiene una lista de los saldos por usuario y nivel, Si el Nivel_Usuario = 1, devuelve todos, de lo contrario devuelve los saldos del usuario pasado
        /// </summary>
        /// <param name="ID_Usuario"></param>
        /// <param name="Nivel"></param>
        /// <returns></returns>
        public List<Saldos> ObtenerSaldos(int ID_Usuario)
        {
            List<Saldos> ListaSaldos = new List<Saldos>();
            Saldos _Saldos = new Saldos();
            AccesoDatos datos = new AccesoDatos();
            //DataSet ds = new DataSet();
            DataTable tblSaldos = datos.ObtenerSaldos(ID_Usuario);

            int a = 1;
            //----
            if (tblSaldos != null)
            {
                for (int i = 0; i < tblSaldos.Rows.Count; i++)
                {
                    ListaSaldos.Add(new Saldos
                    {
                        Matrimonio_ID = (int)tblSaldos.Rows[i]["Matrimonio_ID"],
                        MatrimonioPM = tblSaldos.Rows[i]["MatrimonioPM"].ToString(),
                        NombreEsposa = tblSaldos.Rows[i]["NombreEsposa"].ToString(),
                        NombreEsposo = tblSaldos.Rows[i]["NombreEsposo"].ToString(),
                        FechaMatrimonio = (DateTime)tblSaldos.Rows[i]["FechaMatrimonio"],
                        Nivel = Convert.ToInt16(tblSaldos.Rows[i]["Nivel"].ToString()),
                        Mensualidad = (decimal)tblSaldos.Rows[i]["Mensualidad"],
                        TotalaPagar = (decimal)tblSaldos.Rows[i]["TotalaPagar"],
                        Saldo = (decimal)tblSaldos.Rows[i]["Saldo"],
                        ID_Usuario = (int)tblSaldos.Rows[i]["ID_Usuario"]
                    });
                }
            }
            

            //for (int i = 0; i < tblSaldos.Rows.Count; i++)
            //{
            //    _Saldos = new Saldos();
            //    _Saldos.Matrimonio_ID = (int)tblSaldos.Rows[i]["Matrimonio_ID"];
            //    _Saldos.MatrimonioPM = tblSaldos.Rows[i]["MatrimonioPM"].ToString();
            //    _Saldos.NombreEsposa = tblSaldos.Rows[i]["NombreEsposa"].ToString();
            //    _Saldos.NombreEsposo = tblSaldos.Rows[i]["NombreEsposo"].ToString();
            //    _Saldos.FechaMatrimonio = (DateTime)tblSaldos.Rows[i]["FechaMatrimonio"];
            //    _Saldos.Nivel = Convert.ToInt16(tblSaldos.Rows[i]["Nivel"].ToString());
            //    _Saldos.Mensualidad = (decimal)tblSaldos.Rows[i]["Mensualidad"];
            //    _Saldos.TotalaPagar = (decimal)tblSaldos.Rows[i]["TotalaPagar"];
            //    _Saldos.Saldo = (decimal)tblSaldos.Rows[i]["Saldo"];
            //    _Saldos.ID_Usuario = (int)tblSaldos.Rows[i]["ID_Usuario"];
            //    _Saldos.Nivel_Usuario = Convert.ToInt16(tblSaldos.Rows[i]["Nivel_Usuario"]);
            //    ListaSaldos.Add(_Saldos);
            //}

            return ListaSaldos;
        }

        /// <summary>
        /// Obtiene los abonos del ID del matrimonio indicado
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public List<Abonos> ObtenerAbonos(int ID)
        {
            List<Abonos> ListaAbonos = new List<Abonos>();
            Abonos _Abonos = new Abonos();
            AccesoDatos datos = new AccesoDatos();
            //DataSet ds = new DataSet();
            DataTable tblAbonos = datos.ObtenerAbonos(ID);

            int a = 1;
            //----
            if (tblAbonos != null)
            {
                for (int i = 0; i < tblAbonos.Rows.Count; i++)
                {
                    ListaAbonos.Add(new Abonos
                    {
                        Matrimonio_ID = (int)tblAbonos.Rows[i]["Matrimonio_ID"],
                        Abono_ID = (int)tblAbonos.Rows[i]["Abono_ID"],
                        MatrimonioPM = tblAbonos.Rows[i]["MatrimonioPM"].ToString(),
                        TotalaPagar = (decimal)tblAbonos.Rows[i]["TotalaPagar"],
                        Fecha = (DateTime)tblAbonos.Rows[i]["Fecha"],
                        Abono = (decimal)tblAbonos.Rows[i]["Abono"],
                        Abonado = (decimal)tblAbonos.Rows[i]["Abonado"],
                        Saldo = (decimal)tblAbonos.Rows[i]["Saldo"],
                        Observacion = tblAbonos.Rows[i]["Observacion"].ToString()
                    });
                }
            }

            return ListaAbonos;
        }

        public clsUsuario ObtenerAcceso(string Usuario, string Password)
        {

            clsUsuario _Usuario = new clsUsuario();
            AccesoDatos datos = new AccesoDatos();
            //DataSet ds = new DataSet();
            DataTable tblUsuario = datos.ObtenerAcceso(Usuario,Password);

            int a = 1;
            //----
            if (tblUsuario != null && tblUsuario.Rows.Count!=0)
            {
                _Usuario.ID = (int)tblUsuario.Rows[0]["ID"];
                _Usuario.Usuario = tblUsuario.Rows[0]["Usuario"].ToString();
                _Usuario.Password = tblUsuario.Rows[0]["Password"].ToString();
                _Usuario.Nivel_Usuario = Convert.ToInt16(tblUsuario.Rows[0]["Nivel_Usuario"].ToString());
            }
            else
            {
                _Usuario.ID = 0;
                _Usuario.Usuario = "";
                _Usuario.Password = "";
                _Usuario.Nivel_Usuario = 0;
            }

            return _Usuario;
        }


        public bool AgregarMatrimonio(string MatrimonioPM, string NombreEsposa, string NombreEsposo, DateTime FechaMatrimonio, int Nivel, decimal Mensualidad, int ID_Usuario)
        {
            AccesoDatos datos = new AccesoDatos();
            return datos.AgregarMatrimonio(MatrimonioPM, NombreEsposa, NombreEsposo, FechaMatrimonio, Nivel, Mensualidad,  ID_Usuario,"");
        }

        public bool AgregarAbono(int Matrimonio_ID, DateTime Fecha, decimal Abono, string Observacion)
        {
            AccesoDatos datos = new AccesoDatos();
            return datos.AgregarAbono(Matrimonio_ID, Fecha, Abono, Observacion);
        }

        public bool BorrarMatrimonio(int ID)
        {
            AccesoDatos datos = new AccesoDatos();
            return datos.BorrarMatrimonio(ID);
        }
    }
}

