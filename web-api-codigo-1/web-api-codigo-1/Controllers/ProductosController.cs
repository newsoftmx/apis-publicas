using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using web_api_codigo_1.Models;

namespace web_api_codigo_1.Controllers
{
    public class ProductosController : ApiController
    {
        //agregamos un metodo para que nos pueda devolver una lista de productos
        //como un solo producto
        //definimos una matriz fija
        Producto[] productos = new Producto[]
        {
            new Producto {ID=1, Nombre = "Coca Cola", Categoria = "Refrescos", Precio = 15 },
            new Producto {ID=2, Nombre = "Papas", Categoria = "Refrescos", Precio = 10 },
            new Producto {ID=3, Nombre = "Lechuga", Categoria = "Refrescos", Precio = 25 }
        };

        //ya creados los productos, definimos el primer metodo para que nos devuelva los productos
        public IEnumerable<Producto> GetTodosLosProductos()
        {
            //nos devuelve toda la lista de los productos
            return productos;
        }
        //ahora creamos un solo método que nos va a devolver un solo producto por ID
        public IHttpActionResult GetProducto(int id)
        {
            var producto = productos.FirstOrDefault((p) => p.ID == id);
            if (producto == null)
            {
                return NotFound();
            }
            return Ok (producto);
        }



    }
}
