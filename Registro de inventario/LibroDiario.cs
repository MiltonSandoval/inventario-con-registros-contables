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
        List<Asiento> Libro;
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

        public void GuardarEnExcel(string rutaArchivo)
        {
            
            using (var package = new ExcelPackage())
            {
                int contador = 2;
                var worksheet = package.Workbook.Worksheets.Add("Inventario");

                worksheet.Cells[1, 1].Value = "FECHA";
                worksheet.Cells[1, 2].Value = "CBTE";
                worksheet.Cells[1, 3].Value = "AS.N";
                worksheet.Cells[1, 4].Value = "COD. CUENTA";
                worksheet.Cells[1, 5].Value = "DETALLE";
                worksheet.Cells[1, 6].Value = "DEBE";
                worksheet.Cells[1, 7].Value = "HABER";

                for (int i = 0; i < Libro.Count; i++)
                {
                    var auto = Libro[i];
                    worksheet.Cells[contador + i, 1].Value = auto.date.ToShortDateString();
                    worksheet.Cells[contador + i, 2].Value = auto.Cbte;
                    worksheet.Cells[contador + i, 3].Value = auto.AsientoN;

                    foreach (var item in auto.Transacciones)
                    {

                        worksheet.Cells[i + contador, 4].Value = item.NumeroDeCuenta;
                        worksheet.Cells[i + contador, 5].Value = item.Cuenta;
                        worksheet.Cells[i + contador, 6].Value = item.Debe;
                        worksheet.Cells[i + contador, 7].Value = item.Haber;
                        contador++;
                    }
                    contador++;
                }

                FileInfo fi = new FileInfo("C:\\Proyecto Prueba Excel\\Prueba.xlsx");
                package.SaveAs(fi);
            }
        }
    }
}
