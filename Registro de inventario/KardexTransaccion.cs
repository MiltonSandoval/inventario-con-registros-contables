using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Registro_de_inventario
{
    class KardexTransaccion
    {
        DateTime fecha;

        public string Detalle;
        public string Comp;
        public int EntradasFisica { get; set; }
        public int SalidasFisica { get; set; }
        public int SaldoFisico { get; set; }
        public double CostoAdq { get; set; }
        public double CostoPp { get; set; }
        public double EntradaValor { get; set; }
        public double SalidaValor { get; set; }
        public double SaldoValor { get; set; }

        private static int CompraN = 1;

        private static int VentaN = 1;



        public KardexTransaccion()
        {
            this.fecha = DateTime.Now;
        }

        public void KardexInicio(int saldosfisicos,double costoAdq, double saldoValor)
        {
            Detalle = "Saldo Inicial";
            Comp = "CDT";
            EntradasFisica = 0;
            SalidasFisica = 0;
            SaldoFisico = saldosfisicos;
            CostoAdq = 0;
            CostoPp = saldoValor;
            EntradaValor = 0;
            SalidaValor = 0;
            SaldoValor = SaldoFisico * CostoAdq;
        }

        public void KardexCompra(int entradasfisicas, int saldosfisicos, double costoadq)
        {
            Detalle = $"Compra {CompraN}";
            Comp = "CDE";
            EntradasFisica = entradasfisicas;
            SalidasFisica = 0;
            SaldoFisico = saldosfisicos;
            CostoAdq = costoadq * 0.87;
            EntradaValor = EntradasFisica * CostoAdq;
            SalidaValor = 0;
            SaldoValor = EntradaValor + SaldoValor;
            CostoPp = SaldoValor /SaldoFisico;
            CompraN++;
        } 
        public void Kardexventa(int salidasfisicas, int saldosfisicos, double costopp)
        {
            Detalle = $"Vemta {VentaN}";
            Comp = "CDI";
            EntradasFisica = 0;
            SalidasFisica = salidasfisicas;
            SaldoFisico -= SalidasFisica;
            CostoAdq =  0;
            CostoPp = costopp;
            EntradaValor =  0;
            SalidaValor = SalidasFisica * CostoPp;
            SaldoValor -= SalidaValor;
            VentaN++;
        }
    }
}
