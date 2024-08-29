using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Registro_de_inventario
{
    class MenuCompra
    {
        public static void TipoDeCompra(LibroDiario inventario)
        {
            bool Controlador = true;
            do
            {
                Console.Clear();
                string opcion = SubMenu.Menu2();
                switch (opcion)
                {
                    case "1":
                        MetodoDePago("CDE", inventario);
                        Controlador = false;
                        break;
                    case "2":
                        MetodoDePago("CDT", inventario);
                        Controlador = false;
                        break;
                    case "3":
                        MetodoDePago("CDE", inventario);
                        Controlador = false;
                        break;
                    default:
                        break;
                }



            } while (Controlador);
        }

        public static void MetodoDePago(string Comprobante, LibroDiario inventario)
        {

            bool Controlador = true;
            do
            {
                string opcion = SubMenu.Menu3();
                switch (opcion)
                {
                    case "1":
                    case "5":
                    case "6":
                        Modelos("1.1.1.01.01",Comprobante,"Caja M/N",inventario);
                        Controlador = false;
                        break;
                    case "2":
                        Modelos("1.1.1.01.02", Comprobante, "Caja M/E", inventario);
                        Controlador = false;
                        break;

                    case "3":
                        Modelos("1.1.1.02.01", Comprobante, "Banco cta.cte.M/N", inventario);
                        Controlador = false;
                        break;
                    case "4":
                        Modelos("1.1.1.02.02", Comprobante, "Banco cta.cte.M/E", inventario);
                        Controlador = false;
                        break;
                    case "0":
                        Controlador = false;
                        break;

                    default:
                        break;
                }



            } while (Controlador);
        }
        public static void Modelos(string NCuenta,string Comprobante,string Pago, LibroDiario inventario)
        {
            Console.Clear();
            Console.Write("Ingrese el nombre del producto, sin ascento:");
            string Producto = Console.ReadLine().ToLower();
            Console.Write("Ingrese la cantidad:");
            double cantidad = double.Parse(Console.ReadLine());
            Console.Write("Ingrese el costo unitario:");
            double unitario = double.Parse(Console.ReadLine());
            double total = cantidad * unitario;
            Asiento asiento = new Asiento(Comprobante);

            asiento.AgregarTransaccion(new Transaccion("1.1.3.01.01", "inventario de mercaderia", total * 0.87, 0));
            asiento.AgregarTransaccion(new Transaccion("1.1.2.03.01", "credito fiscal", total * 0.13, 0));
            asiento.AgregarTransaccion(new Transaccion(NCuenta,"  "+Pago, 0, total));
            asiento.ImprimirAsiento();
            inventario.AgregarAsiento(asiento);
            Console.ReadKey();
        }

    }
}
