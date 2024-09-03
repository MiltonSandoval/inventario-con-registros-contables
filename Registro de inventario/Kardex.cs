using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Transactions;
using Spectre.Console;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Registro_de_inventario
{
    class Kardex
    {
        public string Nombre;
        public List<KardexTransaccion> KardexProducto;

        public Kardex(string nombre)
        {
            this.Nombre = nombre;
            KardexProducto = new List<KardexTransaccion>();
        }
        public void AgregarTransaccionKardex(KardexTransaccion kardexTransaccion)
        {

            KardexProducto.Add(kardexTransaccion); 
        }
         
        public KardexTransaccion UltimaTransa()
        {
            int indice = KardexProducto.Count() - 1;
            return indice >= 0 ? KardexProducto[indice] : null;
        }


        public void ImprimirKardex()
        {
            var table = new Table();
            table.Border = TableBorder.Double;
            table.AddColumns(new[]
            {
                new TableColumn($"[darkolivegreen1_1]{Nombre}[/]"),
                new TableColumn("[darkolivegreen1_1]FECHA[/]").Centered(),
                new TableColumn("[darkolivegreen1_1]DETALLE[/]").Centered(),
                new TableColumn("[darkolivegreen1_1]COMP[/]").Centered(),
                new TableColumn("[darkolivegreen1_1]ENTRADAS FISICAS[/]").Centered(),
                new TableColumn("[darkolivegreen1_1]SALIDAS FISICAS[/]").Centered(),
                new TableColumn("[darkolivegreen1_1]SALDO FISICO[/]").Centered(),
                new TableColumn("[darkolivegreen1_1]ADQ.[/]").Centered(),
                new TableColumn("[darkolivegreen1_1]P.P[/]").Centered(),
                new TableColumn("[darkolivegreen1_1]ENTRADAS[/]").Centered(),
                new TableColumn("[darkolivegreen1_1]SALIDAS[/]").Centered(),
                new TableColumn("[darkolivegreen1_1]SALDOS[/]").Centered()
            });
            foreach (var transaccion in KardexProducto)
            {
                table.AddRow(" ", 
                    transaccion.fecha.ToShortDateString(), 
                    transaccion.Detalle.ToString(), 
                    transaccion.Comp, 
                    transaccion.EntradasFisica.ToString(), 
                    transaccion.SalidasFisica.ToString(), 
                    transaccion.SaldoFisico.ToString(), 
                    transaccion.CostoAdq.ToString("F2"), 
                    transaccion.CostoPp.ToString("F2"), 
                    transaccion.EntradaValor.ToString(), 
                    transaccion.SalidaValor.ToString("F2"), 
                    transaccion.SaldoValor.ToString("F2"));
            }
            AnsiConsole.Write(table.Centered().BorderColor(Color.Silver));
        }
    }

}
