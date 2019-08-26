using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace web_api_codigo_1.Models
{
    public class Producto
    {
        public int ID { get; set; }
        public string Nombre { get; set; }
        public string Categoria { set; get; }
        public int Precio { get; set; }
    }
}