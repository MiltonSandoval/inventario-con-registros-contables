using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            foreach (var item in KardexList)
            {
                Console.WriteLine(item.Nombre);
                item.ImprimirKardex();
                Console.WriteLine();
                Console.WriteLine(new string('-', 200));
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
