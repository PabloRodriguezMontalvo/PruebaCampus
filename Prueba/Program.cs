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
            Console.WriteLine("Introduzca opción: ");
            var opcion = Console.ReadLine();
            while (opcion.ToUpper()!="EXIT")
            { 

                if (opcion.ToUpper() == "SUM")
                {
                    Console.WriteLine("Introduzca argumentos para la suma separados por coma y pulse intro ");
                    var numeros = Console.ReadLine();
                    if (!ContieneLetras(numeros))
                    {
                        var milista = formateoNumeros(numeros);
                        if (milista.Any())
                            Suma(milista);
                    }
                    else
                    {
                        Console.WriteLine("Error formatting arguments. La cadena de entrada no tiene el formato correcto");
                    }
                   
                }
               else if (opcion.ToUpper() == "DIV")
                {
                    Console.WriteLine("Introduzca argumentos para la división separados por coma y pulse intro ");
                    var numeros = Console.ReadLine();
                    if (ContieneLetras(numeros))
                    {
                        var milista = formateoNumeros(numeros);
                        bool correcto=true;
                        if(milista.Any())
                        {
                           foreach(float num in milista)
                        {
                            if(MenorQueCero(num))
                            {
                                correcto=false;
                                break;
                            }
                        }
                        if(correcto==true)
                        Division(milista);
                        else
                        Console.Writeline("La división no es posible realizarla con numeros menores que cero")
                        }
                    }
                    else
                    {
                        Console.WriteLine("Error formatting arguments. La cadena de entrada no tiene el formato correcto");
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
        private static bool ContieneLetras(String str)
        {
            return Regex.IsMatch(str, @"^[a-zA-Z]+$");
        }
        static List<float> formateoNumeros(string numeros_sin_formatear)
        {
           
            var resultado= new List<float>();
         
            var numeros_formateados = numeros_sin_formatear.Split(',').ToList();
           
            foreach (var numero in numeros_formateados)

            {
                try
                {
                  var num=  Convertir_Cultura(numero);
                    resultado.Add(num);
                }
                catch (FormatException ex)
                {
                    
                    Console.WriteLine(ex.Message);
                    break;

                }
               
            }
          
            return resultado;
        }

        private static float Convertir_Cultura(string numero)
        {
            var num = 0f;
            var style = NumberStyles.Float;
            var culture = CultureInfo.CreateSpecificCulture("en-EN");
            float.TryParse(numero, style, culture, out num);
            return num;
        }
        static bool MenorQueCero(float numero)
        {
            if(numero<=0)
            return true;
            else
            return false;
        }
        static void Suma(List<float> numeros_decimales)
        {
            var sum = 0f;
            foreach (var numerosDecimale in numeros_decimales)
            {
                sum += numerosDecimale;
            }
            Console.WriteLine("La suma de los operandos es " + sum);
        }
        static void Division(List<float> numeros_decimales)
        {
            if (numeros_decimales.Count == 2)
            {
                Console.WriteLine("Por favor, introduzca SOLO dos números");
            }
            else
            {
                var resultado = numeros_decimales[0]/numeros_decimales[1];
                Console.WriteLine("La division de los operandos es " + resultado);

            }


        }
    }
}
