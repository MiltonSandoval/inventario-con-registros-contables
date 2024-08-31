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
            Console.WriteLine("{0,-12} {1,-10} {2,-8} {3,-8} {4,-8} {5,-8} {6,-8} {7,-10} {8,-10} {9,-10}",
                "Fecha", "Detalle", "Entradas", "Salidas", "Saldos", "C.Adq.", "P.P.", "Costo Ent.", "Costo Sal.", "Costo Saldo");
            Console.WriteLine(new string('-', 100)); 

            foreach (var transaccion in KardexProducto)
            {
                Console.WriteLine("{0,-12} {1,-10} {2,-8} {3,-8} {4,-8} {5,-8:F2} {6,-8:F2} {7,-10:F2} {8,-10:F2} {9,-10:F2}",
                    transaccion.fecha.ToShortDateString() , transaccion.Detalle, transaccion.EntradasFisica, transaccion.SalidasFisica,
                    transaccion.SaldoFisico, transaccion.CostoAdq, transaccion.CostoPp, transaccion.EntradaValor,
                    transaccion.SalidaValor, transaccion.SaldoValor);
            }
        }
    }

}
