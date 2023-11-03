using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FerreteriaCsharp.Classes
{
    public class Factura
    {
        public int NroFactura { get; set; }
        public DateOnly Fecha { get; set; }
        public int IdCliente { get; set; }
        public decimal TotalFactura { get; set; }
    }
}