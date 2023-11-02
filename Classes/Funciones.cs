using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FerreteriaCsharp.Classes
{
    public class Funciones
    {
        List<Productos> _productos = new List<Productos>(){
            new Productos(){Id = 1, Nombre = "Llave", PrecioUnit = 1500, Cantidad = 25, StockMin = 15, StockMax = 100},
            new Productos(){Id = 2, Nombre = "Regla", PrecioUnit = 2000, Cantidad = 15, StockMin = 10, StockMax = 100},
            new Productos(){Id = 3, Nombre = "Cemento", PrecioUnit = 10500, Cantidad = 44, StockMin = 35, StockMax = 100},
            new Productos(){Id = 4, Nombre = "Destornillador", PrecioUnit = 1000, Cantidad = 21, StockMin = 10, StockMax = 100},
            new Productos(){Id = 5, Nombre = "Tornillo", PrecioUnit = 500, Cantidad = 32, StockMin = 20, StockMax = 100},
            new Productos(){Id = 6, Nombre = "Martillo", PrecioUnit = 5500, Cantidad = 28, StockMin = 12, StockMax = 100},
            new Productos(){Id = 7, Nombre = "Clavo", PrecioUnit = 100, Cantidad = 72, StockMin = 18, StockMax = 100},
            new Productos(){Id = 8, Nombre = "Corcho", PrecioUnit = 1800, Cantidad = 31, StockMin = 21, StockMax = 100}
        };

        List<Factura> _factura = new List<Factura>(){
            new Factura(){NroFactura = 1, Fecha = new DateTime(2023, 01, 01), IdCliente = 1, TotalFactura = 27500},
            new Factura(){NroFactura = 2, Fecha = new DateTime(2023, 02, 11), IdCliente = 2, TotalFactura = 10000},
            new Factura(){NroFactura = 3, Fecha = new DateTime(2023, 02, 28), IdCliente = 3, TotalFactura = 45000},
            new Factura(){NroFactura = 4, Fecha = new DateTime(2022, 02, 4), IdCliente = 4, TotalFactura = 65000},
            new Factura(){NroFactura = 5, Fecha = new DateTime(2022, 01, 08), IdCliente = 5, TotalFactura = 33000}
        };
        List<DetalleFactura> _detalleFactura = new List<DetalleFactura>(){
            new DetalleFactura(){Id = 1, NroFactura = 1, IdProducto = 1, Cantidad = 3, Valor = 4500},
            new DetalleFactura(){Id = 2, NroFactura = 1, IdProducto = 2, Cantidad = 1, Valor = 2000},
            new DetalleFactura(){Id = 3, NroFactura = 1, IdProducto = 3, Cantidad = 2, Valor = 21000},
            new DetalleFactura(){Id = 4, NroFactura = 1, IdProducto = 5, Cantidad = 10, Valor = 5000},
            new DetalleFactura(){Id = 5, NroFactura = 2, IdProducto = 7, Cantidad = 3, Valor = 4500},
            new DetalleFactura(){Id = 6, NroFactura = 2, IdProducto = 8, Cantidad = 2, Valor = 3600},
            new DetalleFactura(){Id = 7, NroFactura = 3, IdProducto = 1, Cantidad = 3, Valor = 4500},
            new DetalleFactura(){Id = 8, NroFactura = 3, IdProducto = 4, Cantidad = 1, Valor = 1000},
            new DetalleFactura(){Id = 9, NroFactura = 4, IdProducto = 7, Cantidad = 32, Valor = 3200},
            new DetalleFactura(){Id = 10, NroFactura = 5, IdProducto = 8, Cantidad = 3, Valor = 5400},
            new DetalleFactura(){Id = 11, NroFactura = 5, IdProducto = 3, Cantidad = 3, Valor = 31500}
        };
        public void ListProducts()
        {
            Console.Clear();
            foreach (var e in _productos)
            {
                Console.WriteLine("Nombre Producto: {0} \nPrecio Unitario: {1}\nCantidad Existente: {2}", e.Nombre, e.PrecioUnit, e.Cantidad);
            }
            Console.WriteLine("Presione cualquier tecla para continuar");
            Console.ReadLine();
        }
    }
}