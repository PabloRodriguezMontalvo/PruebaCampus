using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;

namespace Prueba
{
    public  class Calc
    {
        private List<float> _numbers;

        public List<float> numbers
        {
            get { return _numbers; }
            set { _numbers = numbers; } 
        }
        public void formateoNumeros(string numeros_sinformatear)
        {


            var milista = new List<float>();
           var numeros_formateados = numeros_sinformatear.Split(',').ToList();

            foreach (var numero in numeros_formateados)

            {
                try
                {
                    var num = Convertir_Cultura(numero);
                   
                    milista.Add(num);
                }
                catch (FormatException ex)
                {

                    Console.WriteLine(ex.Message);
                    break;

                }
              


            }
            _numbers = milista;


        }

        private static float Convertir_Cultura(string numero)
        {
            var num = 0f;
            var style = NumberStyles.Float;
            var culture = CultureInfo.CreateSpecificCulture("en-EN");
            float.TryParse(numero, style, culture, out num);
            return num;
        }

        public void AddFun()
        {
            var result = 0F;

            foreach (var number in _numbers)
            {
                result += number;
            }
            Console.WriteLine(result);
        }
        public void DivFun()
        {
            if (_numbers.Count == 2 )
            {
                if (_numbers.Last() == 0l)
                {
                    Console.WriteLine("No se puede dividir entre cero");
                }
                var result = _numbers.First()/_numbers.Last();

                Console.WriteLine(result);
            }
         
            else
            {
                Console.WriteLine("Por favor, introduzca SOLO dos números");
            }
        }
       
        
        
        public  bool ContieneLetras(String str)
        {
            return Regex.IsMatch(str, @"^[a-zA-Z]+$");
        }
        public bool ValidateAll(object[] numbers)
        {
          var  result = true;

            foreach (var number in numbers)
            {
                if (ContieneLetras(number.ToString()))
                {
                    result = false;
                } 
            }
            return result;
            
        }

    }
}
