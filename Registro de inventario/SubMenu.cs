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
            var opcion = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
            .Title("[green]COMPRA AL[/]")
            .PageSize(3)
            .AddChoices(new[] {
            "Contado", "Credito"}));
            return opcion;
        }
        public static string Menu3()
        { 

            Console.Clear();
            var opcion = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
            .Title("[green]METODOS DE PAGO[/]")
            .PageSize(8)
            .AddChoices(new[] {
            "Efectivo", "Efectivo M/E","Banco M/N","Banco M/E","Cheque","Letra de cambio","Salir"}));
            return opcion;
        }


    }
}
