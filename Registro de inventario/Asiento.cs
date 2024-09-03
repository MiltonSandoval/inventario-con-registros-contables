 using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using Spectre.Console;

namespace Registro_de_inventario
{
    class Asiento
    {
        public DateTime date;
        public string Cbte;
        static int AsientoContador = 1;
        public int AsientoN;
        public List<Transaccion> Transacciones;

        public static int asientoContador
        {
            set { AsientoContador = value; }
        }

        public Asiento(string cbte)
        {
            Transacciones = new List<Transaccion>();
            date = DateTime.Now;
            this.Cbte = cbte;
            AsientoN = AsientoContador;
            AsientoContador++;
        }

        public void AgregarTransaccion(Transaccion transaccion)
        {
            if(transaccion != null) 
                Transacciones.Add(transaccion);
            else
            {
                Console.WriteLine("Error al guardar el aciento");
                Console.ReadKey();
            }
                
        }

        public void ImprimirAsientoCon()
        {
            Console.Clear();
            var table = new Table();
            table.Border = TableBorder.Double;

            table.AddColumns(new[]
            {
                new TableColumn("[darkolivegreen1_1]FECHA[/]").Centered(),
                new TableColumn("[darkolivegreen1_1]CBTE[/]").Centered(),
                new TableColumn("[darkolivegreen1_1]As.N°[/]").Centered(),
                new TableColumn("[darkolivegreen1_1]Cod. Cta[/]").Centered(),
                new TableColumn("[darkolivegreen1_1]Detalle-Glosa[/]").LeftAligned(),
                new TableColumn("[darkolivegreen1_1]Debe[/]").Centered(),
                new TableColumn("[darkolivegreen1_1]Haber[/]").Centered()
            });

            int contador = 0;
            foreach (var item in Transacciones)
            {
                if (contador == 0)
                {
                    table.AddRow(date.ToShortDateString(),Cbte,AsientoN.ToString(),item.NumeroDeCuenta.ToString(),item.Cuenta.ToString(),item.Debe.ToString("F2"),item.Haber.ToString("F2"));
                    contador++;
                }
                else
                {
                    table.AddRow(" "," "," ", item.NumeroDeCuenta.ToString(), item.Cuenta.ToString(), item.Debe.ToString("F2"), item.Haber.ToString("F2"));
                }
            }

            AnsiConsole.Write(table.Centered().BorderColor(Color.Silver));
        }
        
    }
}
