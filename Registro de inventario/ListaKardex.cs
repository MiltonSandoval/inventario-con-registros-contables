using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spectre.Console;

namespace Registro_de_inventario
{
    class ListaKardex
    {
        public List<Kardex> KardexList;

        public ListaKardex()
        {
            KardexList = new List<Kardex>();
        }

        public void AgregarKardex(Kardex kardex) 
        {
            KardexList.Add(kardex);
        }

        public void ImprimirKarkexAll()
        {
            var rule = new Rule("[green1]KARDEX[/]");
            AnsiConsole.Write(rule);
            foreach (var item in KardexList)
            {
                item.ImprimirKardex();
                Console.WriteLine();            
            }
            
        }


        public Kardex BuscarKardexProducto(string Producto)
        {
            foreach(var item in KardexList)
            {
                if(item.Nombre == Producto)
                    return item;
            }
            return null;
        }

    }
}
