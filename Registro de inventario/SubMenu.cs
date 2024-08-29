using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Registro_de_inventario
{
    class SubMenu
    {
        public static string Menu2()
        {
            Console.Clear();
            Console.WriteLine("----------");
            Console.Write(
                $"Compra al:\n"+
                $"1.Contado\n" +
                $"2.Credito\n" +
                $"3.Anticipo\n");
            return Console.ReadLine();
        }
        public static string Menu3()
        {
            Console.Clear();
            Console.WriteLine("----------");
            Console.Write(
                $"METODOS DE PAGO\n" +
                $"1.Efectivo\n" +
                $"2.Efectivo M/E\n" +
                $"3.Banco M/N\n" +
                $"4.Banco M/E\n" +
                $"5.Cheque\n" +
                $"6.Letra de cambio\n" +
                $"0.Salir\n");
            return Console.ReadLine();
        }
    }
}
