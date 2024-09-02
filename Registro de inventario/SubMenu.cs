using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spectre.Console;

namespace Registro_de_inventario
{
    class SubMenu
    {

        
        public static string Menu2()
        {
            Console.Clear();
            var rule = new Rule("[red]TIPO DE COMPRA[/]\n");
            AnsiConsole.Write(rule);
            var opcion = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
            .Title("\t[green]COMPRA AL[/]")
            .PageSize(3)
            .AddChoices(new[] {
            "Contado", "Credito"}));
            return opcion;
        }
        public static string Menu3()
        { 

            Console.Clear();
            var rule = new Rule("[red]METODOS DE PAGO[/]\n");
            AnsiConsole.Write(rule);
            var opcion = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
            .Title("\t[green]PAGO EN[/]")
            .PageSize(8)
            .AddChoices(new[] {
            "Efectivo", "Efectivo M/E","Banco M/N","Banco M/E","Cheque","Letra de cambio","Salir"}));
            return opcion;
        }


    }
}
