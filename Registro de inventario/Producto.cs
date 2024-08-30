using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Registro_de_inventario
{
    class Producto
    {
        public string nombre;
        public int cantidad;


        public Producto(string nombre, int cantidad)
        {
            this.nombre = nombre;
            this.cantidad = cantidad;

        }



    }
}
