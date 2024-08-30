using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Registro_de_inventario
{
    class MenuVenta
    {
        public static void TipoDeVenta(LibroDiario inventario)
        {
            bool Controlador = true;
            do
            {
                Console.Clear();
                string opcion = SubMenu.Menu2();
                switch (opcion)
                {
                    case "1":
                        MetodoDePago("CDI", inventario, 0);
                        Controlador = false;
                        break;
                    case "2":
                        MetodoDePago("CDT", inventario, 1);
                        Controlador = false;
                        break;
                    default:
                        break;
                }



            } while (Controlador);
        }

        private static void MetodoDePago(string Comprobante, LibroDiario inventario, int tipo)
        {
            List<List<string>> CuentasPago = new List<List<string>>
            {
                new List<string>()
                {"Caja M/N","Caja M/E","Banco cta.cte.M/N","Banco cta.cte.M/E","Caja M/N"},
                new List<string>()
                {"Cuenta por cobrar","Cuenta por cobrar","Cuenta por cobrar","Cuenta por cobrar","Documento por cobrar"},

            };

            bool Controlador = true;
            do
            {
                string opcion = SubMenu.Menu3();
                switch (opcion)
                {
                    case "1":
                    case "5":
                        ModelosVenta("1.1.1.01.01", Comprobante, CuentasPago[tipo][0], inventario);
                        Controlador = false;
                        break;
                    case "2":
                        ModelosVenta("1.1.1.01.02", Comprobante, CuentasPago[tipo][1], inventario);
                        Controlador = false;
                        break;

                    case "3":
                        ModelosVenta("1.1.1.02.01", Comprobante, CuentasPago[tipo][2], inventario);
                        Controlador = false;
                        break;
                    case "4":
                        ModelosVenta("1.1.1.02.02", Comprobante, CuentasPago[tipo][3], inventario);
                        Controlador = false;
                        break;
                    case "6":
                        ModelosVenta("1.1.1.01.01", Comprobante, CuentasPago[tipo][4], inventario);
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
        private static void ModelosVenta(string NCuenta, string Comprobante, string Pago, LibroDiario inventario)
        {   
            Console.Clear();
            Console.Write("Ingrese el nombre del producto, sin ascento:");
            string Producto = Console.ReadLine().ToLower();
            Console.Write("Ingrese la cantidad:");
            double cantidad = double.Parse(Console.ReadLine());
            Console.Write("Ingrese el precio unitario:");
            double unitario = double.Parse(Console.ReadLine());
            double total = cantidad * unitario;
            double costototal = (unitario * 0.87) * cantidad;
            Asiento asiento = new Asiento(Comprobante);

            asiento.AgregarTransaccion(new Transaccion(NCuenta,Pago, total, 0));
            asiento.AgregarTransaccion(new Transaccion("6.1.1.08.01", "impuesto a las transacciones", total * 0.03, 0));
            asiento.AgregarTransaccion(new Transaccion("4.1.1.01.01", "  Venta de mercaderia", 0, total * 0.87));
            asiento.AgregarTransaccion(new Transaccion("2.1.2.01.01", "  Debito fiscal", 0, total * 0.13));
            asiento.AgregarTransaccion(new Transaccion("6.1.1.08.01", "  impuesto a las transacciones p/pagar", 0, total * 0.03));
            asiento.AgregarTransaccion(new Transaccion("1.1.3.01.01", "costo de mercaderia vendida", costototal, 0));
            asiento.AgregarTransaccion(new Transaccion("1.1.3.01.01", "  inventario de mercaderia",0, costototal));

           
            asiento.ImprimirAsiento();
            inventario.AgregarAsiento(asiento);
            Console.ReadKey();
        }

    }
}