using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consola
{
    static class Validaciones
    {
        public static string Texto(string mensaje)
        {
            string texto;
            do
            {
                Console.Write("Ingresar " + mensaje + ": ");
                texto = Console.ReadLine();
            } while (string.IsNullOrEmpty(texto));
            return texto;
        }
        public static int Entero(string mensaje, int min, int max)
        {
            int retorno;
            do
            {
                Console.Write("Ingresar "+mensaje+":");
                if (!int.TryParse(Console.ReadLine(), out retorno))
                    Console.WriteLine("Error. Debe ingresar un "+mensaje+". Reintente.");
                if (retorno < min || retorno > max)
                    Console.WriteLine("Error. El numero debe estar entre " + min + " y " + max + ". Reintente.");
            } while (retorno < min || retorno > max);

            return retorno;
        }
        public static double Importe(string mensaje, double min, double max)
        {
            double retorno;
            do
            {
                Console.Write("Ingresar " + mensaje + ":");
                if (!double.TryParse(Console.ReadLine(), out retorno))
                    Console.WriteLine("Error. Debe ingresar un " + mensaje + ". Reintente.");
                if (retorno < min || retorno > max)
                    Console.WriteLine("Error. El numero debe estar entre " + min + " y " + max + ". Reintente.");
            } while (retorno < min || retorno > max);

            return retorno;
        }
    }
}
