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

        public KardexTransaccion UltimaTransa()
        {
            int indice = KardexProducto.Count() - 1;
            return indice >= 0  ? KardexProducto[indice] : null;
        }


        public void ImprimirKardex()
        {
            Console.WriteLine("{0,-24} {1,-20} {2,-16} {3,-16} {4,-16} {5,-16} {6,-16} {7,-20} {8,-20} {9,-20}",
                "Fecha", "Detalle", "Entradas", "Salidas", "Saldos", "C.Adq.", "P.P.", "Costo Ent.", "Costo Sal.", "Costo Saldo");
            Console.WriteLine(new string('-', 200)); 

            foreach (var transaccion in KardexProducto)
            {
                Console.WriteLine("{0,-24} {1,-20} {2,-16} {3,-16} {4,-16} {5,-16:N2} {6,-16:N2} {7,-20:N2} {8,-20:N2} {9,-20:N2}",
                    transaccion.fecha.ToShortDateString() , transaccion.Detalle, transaccion.EntradasFisica, transaccion.SalidasFisica,
                    transaccion.SaldoFisico, transaccion.CostoAdq, transaccion.CostoPp, transaccion.EntradaValor,
                    transaccion.SalidaValor, transaccion.SaldoValor);
            }
        }
    }

}
