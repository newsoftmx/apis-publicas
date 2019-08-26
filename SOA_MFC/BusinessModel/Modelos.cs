using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessModel
{
    public class Matrimonio
    {
        public int ID { get; set; }
        public string MatrimonioPM { get; set; }
        public string NombreEsposa { get; set; }
        public string NombreEsposo { get; set; }
        public DateTime FechaMatrimonio { get; set; }
        public int Nivel { get; set; }
        public decimal Mensualidad { get; set; }
        public int ID_Usuario { get; set; }
    }

    public class Saldos
    {
        public int Matrimonio_ID { get; set; }
        public string MatrimonioPM { get; set; }
        public string NombreEsposa { get; set; }
        public string NombreEsposo { get; set; }
        public DateTime FechaMatrimonio { get; set; }
        public int Nivel { get; set; }
        public decimal Mensualidad { get; set; }
        public decimal TotalaPagar { get; set; }
        public decimal Saldo { get; set; }
        public int ID_Usuario { get; set; }
    }

    public class Abonos
    {  
        public int Matrimonio_ID { get; set; }
        public int Abono_ID { get; set; }
        public string MatrimonioPM { get; set; }
        public decimal TotalaPagar { get; set; }
        public DateTime Fecha { get; set; }
        public decimal Abono { get; set; }
        public decimal Abonado { get; set; }
        public decimal Saldo { get; set; }
        public string Observacion { get; set; }
    }


    public class clsUsuario
    {
        public int ID { get; set; }
        public string Usuario { get; set; }
        public string Password { get; set; }
        public int Nivel_Usuario { get; set; }
    }

}
