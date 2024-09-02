using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Registro_de_inventario
{
    class KardexTransaccion
    {
        public DateTime fecha;

        public string Detalle;
        public string Comp;
        public decimal EntradasFisica { get; set; }
        public decimal SalidasFisica { get; set; }
        public decimal SaldoFisico { get; set; }
        public decimal CostoAdq { get; set; }
        public decimal CostoPp { get; set; }
        public decimal EntradaValor { get; set; }
        public decimal SalidaValor { get; set; }
        public decimal SaldoValor { get; set; }




        public KardexTransaccion()
        {
            this.fecha = DateTime.Now;
        }

        public void KardexInicio(decimal saldosfisicos,decimal costoPP, decimal saldoValor)
        {
            Detalle = "Saldo Inicial";
            Comp = "CDT";
            EntradasFisica = 0;
            SalidasFisica = 0;
            SaldoFisico = saldosfisicos;
            CostoAdq = 0;
            CostoPp = costoPP;
            EntradaValor = 0;
            SalidaValor = 0;
            SaldoValor = saldoValor;
        }

        public void KardexCompra(decimal entradasfisicas, decimal saldosfisicos, decimal costoadq, decimal saldoanterior)
        {
            Detalle = $"Compra";
            Comp = "CDE";
            EntradasFisica = entradasfisicas;
            SalidasFisica = 0;
            SaldoFisico = saldosfisicos;
            CostoAdq = (costoadq * 0.87m);
            EntradaValor = EntradasFisica * CostoAdq;
            SalidaValor = 0;
            SaldoValor = EntradaValor + saldoanterior;
            CostoPp = SaldoValor /SaldoFisico;
        } 
        public void Kardexventa(decimal salidasfisicas, decimal saldosfisicos, decimal costopp, decimal saldot)
        {
            Detalle = $"Venta";
            Comp = "CDI";
            EntradasFisica = 0;
            SalidasFisica = salidasfisicas;
            SaldoFisico = saldosfisicos;
            CostoAdq =  0;
            CostoPp = costopp;
            EntradaValor =  0;
            SalidaValor = SalidasFisica * CostoPp;
            SaldoValor =saldot -  SalidaValor;
        }
    }
}
