using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OfficeOpenXml;
using Spectre.Console;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Registro_de_inventario
{
    class LibroDiario
    {
        public List<Asiento> Libro;
        public LibroDiario()
        {
            Libro = new List<Asiento>();
        }
        public void AgregarAsiento(Asiento asiento)
        {
            if (asiento != null)
                Libro.Add(asiento);
            else
            {
                Console.WriteLine("Error al guardar el asiento");
                Console.ReadKey();
            }
        }

        public void ImprimirLibro()
        {

            Console.Clear();
            var Titulo = new Rule("[green1]LIBRO DIARIO[/]");
            AnsiConsole.Write(Titulo);
            var table = new Table();
            table.Border = TableBorder.Double;
            table.AddColumns(new[]
            {
                new TableColumn("[darkolivegreen1_1]FECHA[/]").Centered(),
                new TableColumn("[darkolivegreen1_1]CBTE[/]").Centered(),
                new TableColumn("[darkolivegreen1_1]As.N[/]°").Centered(),
                new TableColumn("[darkolivegreen1_1]Cod. Cta[/]").Centered(),
                new TableColumn("[darkolivegreen1_1]Detalle-Glosa[/]").LeftAligned(),
                new TableColumn("[darkolivegreen1_1]Debe[/]").Centered(),
                new TableColumn("[darkolivegreen1_1]Haber[/]").Centered()
            });

            
            foreach (var item in Libro)
            {
                int contador = 0;
                foreach (var col in item.Transacciones)
                    if (contador == 0)
                    {
                        table.AddRow(item.date.ToShortDateString(), item.Cbte.ToString(), item.AsientoN.ToString(), col.NumeroDeCuenta.ToString(), col.Cuenta.ToString(), col.Debe.ToString("F2"), col.Haber.ToString("F2"));
                        contador++;
                    }
                    else
                    {
                        table.AddRow(" ", " ", " ", col.NumeroDeCuenta.ToString(), col.Cuenta.ToString(), col.Debe.ToString("F2"), col.Haber.ToString("F2"));
                    }
            }
            AnsiConsole.Write(table.Centered().BorderColor(Color.Silver));

        }
    }
}
