using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Prueba
{
    class Program
    {
        static void Main(string[] args)
        {
            Calc mi_calc = new Calc();
            Console.WriteLine("Introduzca opción: ");
            var opcion = Console.ReadLine();
            while (opcion.ToUpper() != "EXIT")
            {

                if (opcion.ToUpper() == "SUM")
                {
                    Console.WriteLine("Introduzca argumentos para la suma separados por coma y pulse intro ");
                    var numeros = Console.ReadLine();



                    if (!mi_calc.ContieneLetras(numeros))
                    {
                        mi_calc.formateoNumeros(numeros);
                        if (mi_calc.numbers.Any())

                            mi_calc.AddFun();

                    }
                    else
                    {
                        Console.WriteLine(
                            "Error formatting arguments. La cadena de entrada no tiene el formato correcto");
                    }

                }
                else if (opcion.ToUpper() == "DIV")
                {
                    Console.WriteLine("Introduzca argumentos para la división separados por coma y pulse intro ");
                    var numeros = Console.ReadLine();
                    if (!mi_calc.ContieneLetras(numeros))
                    {
                        mi_calc.formateoNumeros(numeros);
                        if (mi_calc.numbers.Any())
                            mi_calc.DivFun();
                    }
                    else
                    {


                    }
                }
                else
                {
                    Console.WriteLine("Opción " + opcion + " No valida");
                }
                Console.WriteLine("Introduzca opción: ");
                opcion = Console.ReadLine();
            }

        }
    }
}
