using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using BetterConsoleTables;
using ConsoleTables;

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
            new Productos(){Id = 6, Nombre = "Martillo", PrecioUnit = 5500, Cantidad = 11, StockMin = 12, StockMax = 50},
            new Productos(){Id = 7, Nombre = "Clavo", PrecioUnit = 200, Cantidad = 12, StockMin = 18, StockMax = 220},
            new Productos(){Id = 8, Nombre = "Corcho", PrecioUnit = 1800, Cantidad = 11, StockMin = 15, StockMax = 25}
        };

        List<Factura> _factura = new List<Factura>(){
            new Factura(){NroFactura = 1, Fecha = new DateOnly(2023, 01, 01), IdCliente = 1, TotalFactura = 27500},
            new Factura(){NroFactura = 2, Fecha = new DateOnly(2023, 02, 11), IdCliente = 2, TotalFactura = 10000},
            new Factura(){NroFactura = 3, Fecha = new DateOnly(2023, 02, 28), IdCliente = 3, TotalFactura = 45000},
            new Factura(){NroFactura = 4, Fecha = new DateOnly(2022, 02, 4), IdCliente = 4, TotalFactura = 65000},
            new Factura(){NroFactura = 5, Fecha = new DateOnly(2022, 01, 08), IdCliente = 5, TotalFactura = 33000}
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
            var table = new Table("ID", "Nombre Producto", "Precio Unitario", "Cantidad Existente");
            _productos.ForEach(x => table.AddRow(x.Id, x.Nombre, x.PrecioUnit, x.Cantidad));
            table.Config = TableConfiguration.UnicodeAlt();
            Console.WriteLine(table.ToString());
        }

        public void EmptyProducts()
        {
            Console.Clear();
            var newlist = _productos.Where(e => e.Cantidad < e.StockMin);
            if (newlist.Count() == 0)
            {
                Console.WriteLine("No hay productos a punto de agotarse");
                Console.WriteLine("Presione cualquier tecla para continuar");
                Console.ReadLine();
            }
            else
            {
                var table = new Table("Nombre Producto", "Cantidad Existente", "Stock Mínimo");
                foreach (var e in newlist)
                {
                    table.AddRow(e.Nombre, e.Cantidad, e.StockMin);
                }
                table.Config = TableConfiguration.UnicodeAlt();
                Console.WriteLine(table.ToString());
            }

        }

        public void ProductsToBuy()
        {
            Console.Clear();
            var newlist = from e in _productos
                        where e.Cantidad < e.StockMin
                        select new ProductoDto()
                        {
                            Nombre = e.Nombre,
                            ValorTotal = e.StockMax - e.Cantidad
                        };
            if (newlist.Count() == 0)
            {
                Console.WriteLine("No hay productos a comprar");
            }
            else
            {
                var table = new Table("Nombre Producto", "Cantidad a Comprar");
                foreach (var e in newlist)
                {
                    table.AddRow(e.Nombre, e.ValorTotal);
                }
                table.Config = TableConfiguration.UnicodeAlt();
                Console.WriteLine(table.ToString());
            }
        }

        public void FebruaryBills()
        {
            Console.Clear();
            var newlist = _factura.Where(e => e.Fecha.Month == 1);
            if (newlist.Count() == 0)
            {
                Console.WriteLine("No hay facturas con esta fecha de creacion");
            }
            else
            {
                var table = new Table("Cliente", "Nro de Factura", "Fecha de Creacion", "Total Factura");
                foreach (var e in newlist)
                {
                    table.AddRow(e.IdCliente, e.NroFactura, e.Fecha, e.TotalFactura);
                }
                table.Config = TableConfiguration.UnicodeAlt();
                Console.WriteLine(table.ToString());
            }
        }

        public void ShowBillProducts()
        {
            Console.Clear();
            Console.Write("Digite el numero de la factura: ");
            try
            {
                Int128 nrBill = Int128.Parse(Console.ReadLine());
                var newlist = _detalleFactura.Where(e => e.NroFactura == nrBill);
                if (newlist.Count() == 0)
                {
                    Console.WriteLine("El número de factura digitada no existe");
                }
                else
                {
                    var ListProducts = from fa in newlist
                                    join pr in _productos
                                    on fa.IdProducto equals pr.Id
                                    select new
                                    {
                                        NombreProducto = pr.Nombre,
                                        PrecioUnitario = pr.PrecioUnit,
                                        TotalVendidos = fa.Cantidad,
                                        IdFactura = fa.NroFactura
                                    };
                    Console.Clear();
                    var table = new Table("Nombre Producto", "Precio Unitario", "Cantidad Comprada");
                    foreach (var e in ListProducts)
                    {
                        table.AddRow(e.NombreProducto, e.PrecioUnitario, e.TotalVendidos);
                    }
                    table.Config = TableConfiguration.UnicodeAlt();
                    Console.WriteLine(table.ToString());
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Error en dato ingresado, por favor sólo ingrese numeros");
            }
        }

        public void AllProducts()
        {
            Console.Clear();
            var newlist = from e in _productos
                        select new
                        {
                            totalPor = e.Cantidad * e.PrecioUnit
                        };
            if (newlist.Count() == 0)
            {
                Console.WriteLine("No existen productos disponibles");
            }
            else
            {
                var table = new Table("Total en inventario");
                table.AddRow($"${newlist.Sum(e => e.totalPor)}");
                table.Config = TableConfiguration.UnicodeAlt();
                Console.WriteLine(table.ToString());
            }
        }
    }
}