using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FerreteriaCsharp.Classes
{
    public class Productos
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int PrecioInt { get; set; }
        public int Cantidad { get; set; }
        public int StockMin { get; set; }
        public int StockMax { get; set; }
    }
}