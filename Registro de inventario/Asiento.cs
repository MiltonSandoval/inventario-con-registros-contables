using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

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

        public void ImprimirAsiento()
        {
            Console.Clear();
            Console.WriteLine($"{"FECHA",-22}{"CBTE",-10}{"As.N°",-10}{"Cod. Cta",-15}{"Detalle-Glosa",-40}{"Debe",20}{"Haber",20}");

            Console.Write($"{date.ToShortDateString(),-22}{Cbte,-10}{AsientoN,-10}");
            int contador = 0;
            foreach (var item in Transacciones)
            {
                if(contador == 0)
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
