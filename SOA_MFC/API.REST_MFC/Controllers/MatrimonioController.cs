using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using BusinessModel;

namespace API.REST_MFC.Controllers
{
    [EnableCors(origins:"*", headers:"*", methods:"*")]
    [RoutePrefix("v1/Matrimonio")]  //Referencia para usar la api
    public class MatrimonioController : ApiController
    {
        [HttpGet] //Indica el verbo por el cual sera consumido
        [Route("GetAllMatrimonios")]
        public HttpResponseMessage GetAllMatrimonios()
        {
            return Request.CreateResponse(HttpStatusCode.OK, "Esta es una prueba para obtener GetAllMatrimonios");
        }

        [HttpGet] //Indica el verbo por el cual sera consumido
        [Route("GetAcceso/{Usuario}/{Password}")]
        public HttpResponseMessage GetAcceso(string Usuario, string Password)
        {
            LogicAccess.AccesoLogica ObjAccesoLogica = new LogicAccess.AccesoLogica();
            clsUsuario ObjUsuario = new clsUsuario();

            ObjUsuario = ObjAccesoLogica.ObtenerAcceso(Usuario, Password);
            return Request.CreateResponse(HttpStatusCode.OK, ObjUsuario);
        }


        [HttpGet] //Indica el verbo por el cual sera consumido
        [Route("GetSaldos/{ID_Usuario}")]
        public HttpResponseMessage GetSaldos(int ID_Usuario)
        {
            LogicAccess.AccesoLogica ObjAccesoLogica = new LogicAccess.AccesoLogica();
            List<Saldos> ListaSaldos = new List<Saldos>();

            ListaSaldos = ObjAccesoLogica.ObtenerSaldos(ID_Usuario);
            return Request.CreateResponse(HttpStatusCode.OK, ListaSaldos);
        }

        [HttpGet] //Indica el verbo por el cual sera consumido
        [Route("GetAbonos/{ID}")]
        public HttpResponseMessage ConsultaAbonos(int ID)
        {
            LogicAccess.AccesoLogica ObjAccesoLogica = new LogicAccess.AccesoLogica();
            List<Abonos> ListaAbonos = new List<Abonos>();

            ListaAbonos = ObjAccesoLogica.ObtenerAbonos(ID);
            return Request.CreateResponse(HttpStatusCode.OK, ListaAbonos);
        }

        [HttpPost] 
        [Route("AddMatrimonio")] 
        public HttpResponseMessage AddMatrimonio(Matrimonio objMatrimonio)
        {
            LogicAccess.AccesoLogica ObjAccesoLogica = new LogicAccess.AccesoLogica();
            ObjAccesoLogica.AgregarMatrimonio(objMatrimonio.MatrimonioPM, objMatrimonio.NombreEsposa, objMatrimonio.NombreEsposo, objMatrimonio.FechaMatrimonio, objMatrimonio.Nivel, objMatrimonio.Mensualidad, objMatrimonio.ID_Usuario);
            return Request.CreateResponse(HttpStatusCode.OK, objMatrimonio);
        }

        [HttpPost] //Para consumirlo hay que pasarle todos los datos del modelo Abono
        [Route("AddAbono")]
        public HttpResponseMessage AddAbono(Abonos objAbono)
        {
            LogicAccess.AccesoLogica ObjAccesoLogica = new LogicAccess.AccesoLogica();
            ObjAccesoLogica.AgregarAbono(objAbono.Matrimonio_ID, objAbono.Fecha, objAbono.Abono, objAbono.Observacion);
            return Request.CreateResponse(HttpStatusCode.OK, objAbono);
        }

        [HttpDelete] 
        [Route("DeleteMatrimonio/{ID}")]
        public HttpResponseMessage DeleteMatrimonio(int ID)
        {
            string cadena = "No fue borrado";
            bool Borrado = false;
            LogicAccess.AccesoLogica ObjAccesoLogica = new LogicAccess.AccesoLogica();
            Borrado = ObjAccesoLogica.BorrarMatrimonio(ID);
            if(Borrado) cadena = "Elemento Borrado";
            return Request.CreateResponse(HttpStatusCode.OK, cadena);
        }

        public class LogAdd
        {
            public string Status { get; set; }
            public int AffectedRecords { get; set; }
            public string Message { get; set; }
            public Matrimonio ItemMatrimonio { get; set; }
        }

        public class Log2Add
        {
            public string Status { get; set; }
            public int AffectedRecords { get; set; }
            public string Message { get; set; }
            public Abonos ItemAbonos { get; set; }
        }
    }
}
