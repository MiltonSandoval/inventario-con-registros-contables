using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

    }
}
