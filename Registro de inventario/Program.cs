using Registro_de_inventario;
using Spectre.Console;

class Program
{
    static void Main(string[] args)
    {
        LibroDiario Inventario = new LibroDiario();
        bool Controlador = true;
        do
        {
            Console.Clear();
            string opcion = MenuPrincipal();
            switch (opcion)
            {
                case "1":
                    MenuCompra.TipoDeCompra(Inventario);
                    break;
                case "2":
                    break;
                case "3":
                    break;
                case "4":
                    Console.Write("Ingrese la ruta del archivo Excel para guardar: ");
                    string rutaArchivo = Console.ReadLine();
                    Inventario.GuardarEnExcel(rutaArchivo);
                    break;
                case "0":
                    Controlador = false;
                    break;
                default:
                    Console.Clear();
                    Console.WriteLine("ERROR INGRESE UNA OPCION VALIDA!!");
                    Console.ReadKey();
                    break;
            }


        } while (Controlador);
    }

    public static string MenuPrincipal()
    {
        Console.WriteLine("INVENTARIO DE MERCADERIA");
        Console.Write("1.REGISTRAR UNA COMPRA\n");
        Console.Write("2.REGISTRAR UNA VENTA\n");
        Console.Write("3.MOSTRAR REGISTROS\n");
        Console.Write("4.GUARDAR EN EXCEL\n");
        Console.Write("0.SALIR\n");
        Console.Write("Ingrese su opcion:");
        return Console.ReadLine();

    }
}
