using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Registro_de_inventario
{
    class MenuVenta
    {
        public static void TipoDeVenta(LibroDiario inventario, ListaKardex listaKardex)
        {
            try
            {
                bool Controlador = true;
                do
                {
                    Console.Clear();
                    string opcion = SubMenu.Menu2();
                    switch (opcion)
                    {
                        case "1":
                            MetodoDePago("CDI", inventario, 0, listaKardex);
                            Controlador = false;
                            break;
                        case "2":
                            MetodoDePago("CDT", inventario, 1, listaKardex);
                            Controlador = false;
                            break;
                        default:
                            break;
                    }



                } while (Controlador);
            }
            catch (Exception Ex)
            {
                Console.Clear();
                Console.WriteLine($"Error de inesperado:{Ex.Message}");
                Console.ReadKey();
            }
            
        }

        private static void MetodoDePago(string Comprobante, LibroDiario inventario, int tipo, ListaKardex listakardex)
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
                        ModelosVenta("1.1.1.01.01", Comprobante, CuentasPago[tipo][0], inventario, listakardex);
                        Controlador = false;
                        break;
                    case "2":
                        ModelosVenta("1.1.1.01.02", Comprobante, CuentasPago[tipo][1], inventario, listakardex);
                        Controlador = false;
                        break;

                    case "3":
                        ModelosVenta("1.1.1.02.01", Comprobante, CuentasPago[tipo][2], inventario, listakardex);
                        Controlador = false;
                        break;
                    case "4":
                        ModelosVenta("1.1.1.02.02", Comprobante, CuentasPago[tipo][3], inventario, listakardex);
                        Controlador = false;
                        break;
                    case "6":
                        ModelosVenta("1.1.1.01.01", Comprobante, CuentasPago[tipo][4], inventario, listakardex);
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
        private static void ModelosVenta(string NCuenta, string Comprobante, string Pago, LibroDiario inventario, ListaKardex listakardex)
        {   
            Console.Clear();
            Kardex producto1 = Historial(listakardex);
            Console.Write("Ingrese la cantidad:");
            decimal cantidad = decimal.Parse(Console.ReadLine());
            Console.Write("Ingrese el precio unitario de venta :");
            decimal unitario = decimal.Parse(Console.ReadLine());


            KardexTransaccion ultimaTransaccion = producto1.UltimaTransa();
            KardexTransaccion kardexventa = new KardexTransaccion();
            decimal total = cantidad * unitario;
            decimal costototal =  ultimaTransaccion.CostoPp * cantidad;
            kardexventa.Kardexventa(cantidad, ultimaTransaccion.SaldoFisico - cantidad, ultimaTransaccion.CostoPp,ultimaTransaccion.SaldoValor);
            Asiento asiento = new Asiento(Comprobante);



            asiento.AgregarTransaccion(new Transaccion(NCuenta,Pago, total, 0));
            asiento.AgregarTransaccion(new Transaccion("6.1.1.08.01", "impuesto a las transacciones", total * 0.03m, 0));
            asiento.AgregarTransaccion(new Transaccion("4.1.1.01.01", "  Venta de mercaderia", 0, total * 0.87m));
            asiento.AgregarTransaccion(new Transaccion("2.1.2.01.01", "  Debito fiscal", 0, total * 0.13m));
            asiento.AgregarTransaccion(new Transaccion("6.1.1.08.01", "  impuesto a las transacciones p/pagar", 0, total * 0.03m));
            asiento.AgregarTransaccion(new Transaccion("1.1.3.01.01", "costo de mercaderia vendida", costototal, 0));
            asiento.AgregarTransaccion(new Transaccion("1.1.3.01.01", "  inventario de mercaderia",0, costototal));

            asiento.ImprimirAsientoCon();
            producto1.AgregarTransaccionKardex(kardexventa);
            producto1.ImprimirKardex();
            inventario.AgregarAsiento(asiento);
            Console.ReadKey();
        }


        private static Kardex Historial(ListaKardex listaKardex)
        {

            while (true)
            {
                Console.WriteLine("Productos");
                int contador = 1;
                foreach (var item in listaKardex.KardexList)
                {

                    Console.WriteLine($"{contador}.{item.Nombre}");
                    contador++;
                }
                Console.Write("Ingrese su opcion:");
                string opcion = Console.ReadLine();
                if (int.Parse(opcion) - 1 >= 0 && int.Parse(opcion)<= listaKardex.KardexList.Count)
                {
                    return listaKardex.KardexList[int.Parse(opcion) - 1 ];
                }
                else
                {
                    Console.WriteLine("Error ingrese una opcion valida!!");
                    Console.ReadKey();
                }
            }
            return null;
        }
    }
}