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
            foreach (var e in _productos)
            {
                Console.WriteLine("PRODUCTO {3}:\nNombre Producto: {0} \nPrecio Unitario: {1}\nCantidad Existente: {2}\n--------------------------",
                e.Nombre, e.PrecioUnit, e.Cantidad, _productos.IndexOf(e) + 1);
            }
            Console.WriteLine("Presione cualquier tecla para continuar");
            Console.ReadLine();
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
                Console.WriteLine("PRODUCTOS A AGOTARSE:");
                foreach (var e in newlist)
                {
                    Console.WriteLine("----------------------------\n Nombre Producto: {0}\n Cantidad Existente: {1}\n Stock Minimo: {2}\n----------------------------",
                    e.Nombre, e.Cantidad, e.StockMin);
                }
                Console.WriteLine("Presione cualquier tecla para continuar");
                Console.ReadLine();
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
                Console.WriteLine("Presione cualquier tecla para continuar");
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("PRODUCTOS A COMPRAR:");
                foreach (var e in newlist)
                {
                    Console.WriteLine("----------------------------\n Nombre Producto: {0}\n Cantidad a Comprar: {1} \n----------------------------",
                    e.Nombre, e.ValorTotal);
                }
                Console.WriteLine("Presione cualquier tecla para continuar");
                Console.ReadLine();
            }
        }

        public void FebruaryBills()
        {
            Console.Clear();
            var newlist = _factura.Where(e => e.Fecha.Month == 1);
            if (newlist.Count() == 0)
            {
                Console.WriteLine("No hay facturas con esta fecha de creacion");
                Console.WriteLine("Presione cualquier tecla para continuar");
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("FACTURAS DE ENERO:");
                foreach (var e in newlist)
                {
                    Console.WriteLine("----------------------------\n ID Cliente: {3}\n Nro de Factura: {0}\n Fecha: {1}\n Total Factura: {2}\n----------------------------",
                        e.NroFactura, e.Fecha, e.TotalFactura, e.IdCliente);
                }
                Console.WriteLine("Presione cualquier tecla para continuar");
                Console.ReadLine();
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
                    Console.WriteLine("Presione cualquier tecla para continuar");
                    Console.ReadLine();
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
                    Console.WriteLine("PRODUCTOS FACTURA {0}", nrBill);
                    foreach (var e in ListProducts)
                    {
                        Console.WriteLine("----------------------------\n Nombre Producto: {0}\n Precio Unitario: {1}\n Cantidad Comprada: {2}\n----------------------------",
                            e.NombreProducto, e.PrecioUnitario, e.TotalVendidos);
                    }
                    Console.WriteLine("Presione cualquier tecla para continuar");
                    Console.ReadLine();
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Error en dato ingresado, por favor sólo ingrese numeros");
                Console.WriteLine("Presione cualquier tecla para continuar");
                Console.ReadLine();
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
            Console.WriteLine("Presione cualquier tecla para continuar");
            Console.ReadLine();
        }
        else
        {
            Console.WriteLine("TOTAL EN PRODUCTOS: ${0}", newlist.Sum(e => e.totalPor));
            Console.WriteLine("Presione cualquier tecla para continuar");
            Console.ReadLine();
        }
    }
}
}