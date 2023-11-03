using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FerreteriaCsharp.Classes
{
    public class Menu
    {
        Funciones functions = new Funciones();
        public void MenuOption()
        {
            bool flag = true;
            while (flag)
            {
                Console.Clear();
                Console.WriteLine("--------------------- MENU FERRETERIA ---------------------");
                Console.WriteLine("1. LISTAR LOS PRODUCTOS DEL INVENTARIO");
                Console.WriteLine("2. LISTAR LOS PRODUCTOS QUE ESTAN A PUNTO DE AGOTARSE");
                Console.WriteLine("3. LISTAR LOS PRODUCTOS QUE SE DEBEN COMPRAR Y CUANTO");
                Console.WriteLine("4. LISTAR EL TOTAL DE FACTURAS DEL MES DE ENERO DEL 2023");
                Console.WriteLine("5. LISTAR LOS PRODUCTOS VENDIDOS DE UNA FACTURA");
                Console.WriteLine("6. CALCULAR EL VALOR TOTAL DEL INVENTARIO");
                Console.WriteLine("7. SALIR");
                Console.Write(".)");
                string opt = Console.ReadLine();
                switch (opt)
                {
                    case "1":
                        functions.ListProducts();
                        break;

                    case "2":
                        functions.EmptyProducts();
                        break;

                    case "3":
                        functions.ProductsToBuy();
                        break;

                    case "4":
                        functions.FebruaryBills();
                        break;

                    case "5":
                        functions.ShowBillProducts();
                        break;

                    case "6":
                        functions.AllProducts();
                        break;

                    case "7":
                        Console.Clear();
                        Console.WriteLine("Adios!");
                        flag = false;
                        break;

                    default:
                        Console.Clear();
                        Console.WriteLine("Error en opcion digitada");
                        Console.WriteLine("Presione cualquier tecla para continuar");
                        Console.ReadKey();
                        break;
                }
            }
        }
    }
}