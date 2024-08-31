using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OfficeOpenXml;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Registro_de_inventario
{
    class LibroDiario
    {
        public List<Asiento> Libro;
        public LibroDiario()
        {
            Libro = new List<Asiento>();
        }
        public void AgregarAsiento(Asiento asiento)
        {
            if (asiento != null)
                Libro.Add(asiento);
            else
            {
                Console.WriteLine("Error al guardar el asiento");
                Console.ReadKey();
            }
        }

        public void ImprimirLibro()
        {
            Console.Clear();
            Console.WriteLine($"{"FECHA",-22}{"CBTE",-10}{"As.N°",-10}{"Cod. Cta",-15}{"Detalle-Glosa",-40}{"Debe",20}{"Haber",20}");
            foreach (var item in Libro)
            {
                item.ImprimirAsientoSin();
            }

        }
    }
}
