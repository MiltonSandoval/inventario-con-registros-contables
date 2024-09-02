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

            table.AddColumns(new[]
            {
                new TableColumn("FECHA").Centered(),
                new TableColumn("CBTE").Centered(),
                new TableColumn("As.N°").Centered(),
                new TableColumn("Cod. Cta").Centered(),
                new TableColumn("Detalle-Glosa").Centered(),
                new TableColumn("Debe").Centered(),
                new TableColumn("Haber").Centered()
            });

            int contador = 0;
            foreach (var item in Transacciones)
            {
                if (contador == 0)
                {
                    table.AddRow(date.ToShortDateString(),Cbte,AsientoN.ToString(),item.NumeroDeCuenta.ToString(),item.Cuenta.ToString(),item.Debe.ToString(),item.Haber.ToString());
                    contador++;
                }
                else
                {
                    table.AddRow(" "," "," ", item.NumeroDeCuenta.ToString(), item.Cuenta.ToString(), item.Debe.ToString(), item.Haber.ToString());
                }
            }

            AnsiConsole.Write(table);
            Console.ReadKey();
        }
        public void ImprimirAsientoSin()
        {
            Console.Write($"{date.ToShortDateString(),-22}{Cbte,-10}{AsientoN,-10}");
            int contador = 0;
            foreach (var item in Transacciones)
            {
                if (contador == 0)
                {
                    item.GetTransaccionSinEspacio();
                    contador++;
                }
                else
                    item.GetTransaccionConEspacio();
            }
            Console.WriteLine();
        }
    }
}
