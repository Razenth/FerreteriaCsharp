using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FerreteriaCsharp.Classes
{
    public class Menu
    {
        public void MenuOption(){
            Console.Clear();
            Console.Write("--------------------- MENU FERRETERIA ---------------------");
            Console.Write("1. LISTAR LOS PRODUCTOS DEL INVENTARIO");
            Console.Write("2. LISTAR LOS PRODUCTOS QUE ESTAN A PUNTO DE AGOTARSE");
            Console.Write("3. LISTAR LOS PRODUCTOS QUE SE DEBEN COMPRAR Y CUANTO");
            Console.Write("4. LISTAR EL TOTAL DE FACTURAS DEL MES DE ENERO DEL 2023");
            Console.Write("5. LISTAR EL TOTAL DE FACTURAS DEL MES DE ENERO DEL 2023");
            Console.Write("6.  CALCULAR EL VALOR TOTAL DEL INVENTARIO");
            Console.Write(".)");
            string opt = Console.ReadLine();

            switch (opt)
            {
                case "1":

                
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