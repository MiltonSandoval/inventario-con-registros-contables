using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Registro_de_inventario
{
    class Transaccion
    {
        
        public string NumeroDeCuenta;
        public string Cuenta;
        public double Debe = 0;
        public double Haber = 0;


        public Transaccion(string NumCta, string Cuenta, double debe, double haber)
        {

            this.NumeroDeCuenta = NumCta;
            this.Cuenta = Cuenta;
            this.Debe = debe;
            this.Haber = haber;
        }

        public void GetTransaccionConEspacio()
        {
            string vacia = "";

            Console.WriteLine($"{vacia,-42}{NumeroDeCuenta,-15}{Cuenta,-40}{Debe,20:N2}{Haber,20:N2}");
        }
        public void GetTransaccionSinEspacio()
        {
            string vacia = "";

            Console.WriteLine($"{vacia}{NumeroDeCuenta,-15}{Cuenta,-40}{Debe,20:N2}{Haber,20:N2}");
        }
    }
}
