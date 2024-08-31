using OfficeOpenXml;
using Registro_de_inventario;
using Spectre.Console;

class Program
{
    static void Main(string[] args)
    {

        LibroDiario Inventario = new LibroDiario();
        ListaKardex ListaKardex = new ListaKardex();
        bool Controlador = true;
        do
        {
            Console.Clear();
            string opcion = MenuPrincipal();
            switch (opcion)
            {
                case "1":
                    MenuCompra.TipoDeCompra(Inventario, ListaKardex);
                    break;
                case "2":
                    if (ListaKardex.KardexList.Count > 0)
                        MenuVenta.TipoDeVenta(Inventario,ListaKardex);
                    else
                    {
                        Console.WriteLine("No tienes productos en tu inventario, agrega uno primero");
                        Console.ReadKey();
                    }
                    break;
                case "3":
                    Console.WriteLine("LIBRO DIARIO");
                    Inventario.ImprimirLibro();
                    Console.WriteLine(new string('-',200));
                    Console.WriteLine("TODOS LOS KARDEX");
                    ListaKardex.ImprimirKarkexAll();
                    Console.WriteLine();
                    Console.ReadKey();
                    break;
                case "4":
                    Console.Write("Ingrese la ruta del archivo Excel para guardar: ");
                    string rutaArchivo = Console.ReadLine();
                    GuardarEnExcel(rutaArchivo, ListaKardex,Inventario);
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
    public static void GuardarEnExcel(string rutaArchivo, ListaKardex listaKardex, LibroDiario libro)
    {
        using (var package = new ExcelPackage())
        {
            int contadorLibro = 2;
            int contadorKardex = 1;

            // Hoja para el inventario del libro
            var worksheetLibro = package.Workbook.Worksheets.Add("Inventario");

            worksheetLibro.Cells[1, 1].Value = "FECHA";
            worksheetLibro.Cells[1, 2].Value = "CBTE";
            worksheetLibro.Cells[1, 3].Value = "AS.N";
            worksheetLibro.Cells[1, 4].Value = "COD. CUENTA";
            worksheetLibro.Cells[1, 5].Value = "DETALLE";
            worksheetLibro.Cells[1, 6].Value = "DEBE";
            worksheetLibro.Cells[1, 7].Value = "HABER";

            for (int i = 0; i < libro.Libro.Count; i++)
            {
                var auto = libro.Libro[i];
                worksheetLibro.Cells[contadorLibro + i, 1].Value = auto.date.ToShortDateString();
                worksheetLibro.Cells[contadorLibro + i, 2].Value = auto.Cbte;
                worksheetLibro.Cells[contadorLibro + i, 3].Value = auto.AsientoN;

                foreach (var item in auto.Transacciones)
                {
                    worksheetLibro.Cells[contadorLibro, 4].Value = item.NumeroDeCuenta;
                    worksheetLibro.Cells[contadorLibro, 5].Value = item.Cuenta;
                    worksheetLibro.Cells[contadorLibro, 6].Value = item.Debe;
                    worksheetLibro.Cells[contadorLibro, 7].Value = item.Haber;
                    contadorLibro++;
                }
            }

            var worksheetKardex = package.Workbook.Worksheets.Add("Kardex");


            foreach (var item in listaKardex.KardexList)
            {
                worksheetKardex.Cells[contadorKardex, 1].Value = "FECHA";
                worksheetKardex.Cells[contadorKardex, 2].Value = "DETALLE";
                worksheetKardex.Cells[contadorKardex, 3].Value = "COMP";
                worksheetKardex.Cells[contadorKardex, 4].Value = "ENTRADAS FISICAS";
                worksheetKardex.Cells[contadorKardex, 5].Value = "SALIDAS FISICAS";
                worksheetKardex.Cells[contadorKardex, 6].Value = "SALDO FISICO";
                worksheetKardex.Cells[contadorKardex, 7].Value = "ADQ";
                worksheetKardex.Cells[contadorKardex, 8].Value = "P.P";
                worksheetKardex.Cells[contadorKardex, 9].Value = "ENTRADAS VALOR";
                worksheetKardex.Cells[contadorKardex, 10].Value = "SALIDAS VALOR";
                worksheetKardex.Cells[contadorKardex, 11].Value = "SALDO VALOR";
                contadorKardex++;
                foreach (var kardex in item.KardexProducto)
                {
                    worksheetKardex.Cells[contadorKardex, 1].Value = kardex.fecha.ToShortDateString();
                    worksheetKardex.Cells[contadorKardex, 2].Value = kardex.Detalle;
                    worksheetKardex.Cells[contadorKardex, 3].Value = kardex.Comp;
                    worksheetKardex.Cells[contadorKardex, 4].Value = kardex.EntradasFisica;
                    worksheetKardex.Cells[contadorKardex, 5].Value = kardex.SalidasFisica;
                    worksheetKardex.Cells[contadorKardex, 6].Value = kardex.SaldoFisico;
                    worksheetKardex.Cells[contadorKardex, 7].Value = kardex.CostoAdq;
                    worksheetKardex.Cells[contadorKardex, 8].Value = kardex.CostoPp;
                    worksheetKardex.Cells[contadorKardex, 9].Value = kardex.EntradaValor;
                    worksheetKardex.Cells[contadorKardex, 10].Value = kardex.SalidaValor;
                    worksheetKardex.Cells[contadorKardex, 11].Value = kardex.SaldoValor;

                    contadorKardex++;
                }
                contadorKardex += 5;
            }
            FileInfo fi = new FileInfo(rutaArchivo);
            package.SaveAs(fi);
        }
    }

}
