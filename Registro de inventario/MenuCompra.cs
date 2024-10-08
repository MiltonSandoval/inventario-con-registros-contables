﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Registro_de_inventario
{
    class MenuCompra
    {
        public static void TipoDeCompra(LibroDiario inventario, ListaKardex listaKardex,JsonAlmacen<LibroDiario> jsonAlmacen, JsonAlmacen<ListaKardex> jsonkardex)
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
                        case "Contado":
                            MetodoDePago("CDE", inventario, 0, listaKardex);
                            Controlador = false;
                            break;
                        case "Credito":
                            MetodoDePago("CDT", inventario, 1, listaKardex);
                            Controlador = false;
                            break;
                        default:
                            break;
                    }



                } while (Controlador);
                jsonAlmacen.Guardar(inventario);
                jsonkardex.Guardar(listaKardex);
            }
            catch (Exception Ex)
            {
                Console.Clear() ;
                Console.WriteLine($"Error de tipo: {Ex.Message}");
                Console.ReadKey();  
            }
            
        }

        private static void MetodoDePago(string Comprobante, LibroDiario inventario,int tipo, ListaKardex listaKardex)
        {
            try
            {
                List<List<string>> CuentasPago = new List<List<string>>
                {
                    new List<string>()
                    {"Caja M/N","Caja M/E","Banco cta.cte.M/N","Banco cta.cte.M/E","Caja M/N"},
                    new List<string>()
                    {"Cuenta por pagar","Cuenta por pagar","Cuenta por pagar","Cuenta por pagar","Documento por pagar"},

                };

                bool Controlador = true;
                do
                {
                    string opcion = SubMenu.Menu3();
                    switch (opcion)
                    {
                        case "Efectivo":
                            Modelos("1.1.1.01.01", Comprobante, CuentasPago[tipo][0], inventario, listaKardex);
                            Controlador = false;
                            break;
                        case "Efectivo M/E":
                            Modelos("1.1.1.01.02", Comprobante, CuentasPago[tipo][1], inventario, listaKardex);
                            Controlador = false;
                            break;

                        case "Banco M/N":
                        case "Cheque":
                            Modelos("1.1.1.02.01", Comprobante, CuentasPago[tipo][2], inventario, listaKardex);
                            Controlador = false;
                            break;
                        case "Banco M/E":
                            Modelos("1.1.1.02.02", Comprobante, CuentasPago[tipo][3], inventario, listaKardex);
                            Controlador = false;
                            break;
                        case "Letra de cambio":
                            Modelos("1.1.1.01.01", Comprobante, CuentasPago[tipo][4], inventario, listaKardex);
                            Controlador = false;
                            break;
                        case "Salir":
                            Controlador = false;
                            break;

                        default:
                            break;
                    }

                } while (Controlador);
            }
            catch (Exception Ex)
            {
                Console.WriteLine($"Error inesperado: {Ex.Message}");
                throw;
            }
            
        }
        private static void Modelos(string NCuenta, string Comprobante, string Pago, LibroDiario inventario, ListaKardex listaKardex)
        {
            try
            {
                Console.Clear();
                Console.Write("Ingrese el nombre del producto, sin acento:");
                string producto = Console.ReadLine().ToLower();
                Console.Write("Ingrese la cantidad:");
                decimal cantidad = decimal.Parse(Console.ReadLine());
                Console.Write("Ingrese el costo unitario:");
                decimal unitario = decimal.Parse(Console.ReadLine());
                decimal total = cantidad * unitario;
                Asiento asiento = new Asiento(Comprobante);
                bool Verificador = false;

                Kardex kar = listaKardex.BuscarKardexProducto(producto);
                KardexTransaccion kardexTransaccion = new KardexTransaccion();

                if (kar != null)
                {
                    KardexTransaccion ultimaTransaccion = kar.UltimaTransa();
                    kardexTransaccion.KardexCompra(cantidad, ultimaTransaccion.SaldoFisico + cantidad, unitario, ultimaTransaccion.SaldoValor);
                    kar.AgregarTransaccionKardex(kardexTransaccion);
                    AgregarTransaccionesAsiento(asiento, NCuenta, Pago, total, aplicarImpuestos: true);
                    Verificador = true;

                }
                else
                {
                    bool aplicarImpuestos = PreguntarImpuestos();
                    kar = new Kardex(producto);
                    decimal costoUnitarioAplicado = aplicarImpuestos ? unitario * 0.87m : unitario;
                    decimal totalAplicado = aplicarImpuestos ? total * 0.87m : total;

                    kardexTransaccion.KardexInicio(cantidad, costoUnitarioAplicado, totalAplicado);
                    kar.AgregarTransaccionKardex(kardexTransaccion);

                    AgregarTransaccionesAsiento(asiento, NCuenta, Pago, total, aplicarImpuestos);
                    listaKardex.AgregarKardex(kar);
                    Verificador = false;
                }

                asiento.ImprimirAsientoCon();
                kar.ImprimirKardex();

                PreguntarEditar(NCuenta, Comprobante, Pago, inventario, asiento, listaKardex, kar, Verificador);

            }
            catch (Exception Ex)
            {
                Console.Clear();
                Console.WriteLine(Ex.Message);
                throw;
            }
            
        }

         private static void AgregarTransaccionesAsiento(Asiento asiento, string NCuenta, string Pago, decimal total, bool aplicarImpuestos)
        {
            if (aplicarImpuestos)
            {
                asiento.AgregarTransaccion(new Transaccion("1.1.3.01.01", "inventario de mercadería", total * 0.87m, 0));
                asiento.AgregarTransaccion(new Transaccion("1.1.2.03.01", "crédito fiscal", total * 0.13m, 0));
                asiento.AgregarTransaccion(new Transaccion(NCuenta, "   " + Pago, 0, total));
            }
            else
            {
                asiento.AgregarTransaccion(new Transaccion("1.1.3.01.01", "inventario de mercadería", total, 0));
                asiento.AgregarTransaccion(new Transaccion("3.1.1.01.01", "   Capital Social", 0, total));
            }
        }

        private static bool PreguntarImpuestos()
        {
            while (true)
            {
                Console.WriteLine("¿DESEA APLICAR IMPUESTOS A ESTA COMPRA? Si/No");
                Console.Write("Ingrese su opción: ");
                string opcion = Console.ReadLine().ToLower();

                if (opcion == "si")
                {
                    return true;
                }
                else if (opcion == "no")
                {
                    return false;
                }
                else
                {
                    Console.WriteLine("Error: opción inválida.");
                    Console.ReadKey();
                }
            }
        }

        private static void PreguntarEditar(string NCuenta, string Comprobante, string Pago, LibroDiario inventario, Asiento asiento,ListaKardex listaKardex, Kardex kar, bool verificador)
        {
            while (true)
            {
                Console.WriteLine("CONFIRME SU TRANSACCION");
                Console.WriteLine($"1.Editar transaccion\n" +
                    $"2.Cancelar Transaccion\n" +
                    $"3.Guardar");
                Console.Write("ingrese su opcion:");
                string opcion = Console.ReadLine();


                if(opcion == "1")
                {
                    Editar(kar, listaKardex, verificador);
                    Modelos(NCuenta, Comprobante,Pago,inventario,listaKardex);
                    break;
                }else if(opcion == "2")
                {
                    Editar(kar, listaKardex, verificador);
                    break;
                }else if (opcion == "3")
                {
                    inventario.AgregarAsiento(asiento);
                    break;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Opcion invalida!!!");
                    Console.ReadKey();
                }

            }
        }

        private static void Editar(Kardex kar, ListaKardex listaKardex, bool verificador)
        {
            if (verificador)
            {
                int indice = kar.KardexProducto.Count - 1;
                kar.KardexProducto.RemoveAt(indice);

            }
            else
            {                
                int indice = listaKardex.KardexList.Count - 1;
                listaKardex.KardexList.RemoveAt(indice);
                indice = kar.KardexProducto.Count - 1;
                kar.KardexProducto.RemoveAt(indice);

            }
        }
    }
}
