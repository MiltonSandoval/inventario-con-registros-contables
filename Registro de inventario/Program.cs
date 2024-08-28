using Spectre.Console;

namespace Registro
{
    class Programa
    {
        static void Main(string[] args)
        {
            bool Controlador = true;
            do
            {
                string opcion = MenuPrincipal();
                switch (opcion)
                {
                    case "1":
                        break;
                    case "2":
                        break;
                    case "3":
                        break;
                    case "4":
                        Controlador = false;
                        break;
                    default:
                        break;
                }


            } while (Controlador);



        }
        public static string MenuPrincipal()
        {
            Console.WriteLine("----------");
            Console.Write(
                $"1.Compra\n" +
                $"2.Venta\n" +
                $"3.Registro\n" +
                $"4.Salir\n");
            Console.WriteLine("----------");
            Console.Write("ingrese su opcion:");
            return Console.ReadLine();
        }
    }

}



