using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FerreteriaCsharp.Classes
{
    public class DetalleFactura
    {
        public int Id { get; set; }
        public int NroFactura { get; set; }
        public int IdProducto { get; set; }
        public int Cantidad { get; set; }
        public int Valor { get; set; }
    }
}