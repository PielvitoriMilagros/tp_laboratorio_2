using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public static class Calculadora
    {
        private static string ValidarOperador(string operador)
        {
            if (operador != "+" && operador != "-" && operador != "/" && operador != "*")
                return "+";
            return operador;
        }

        public static double Operar(Numero num1,Numero num2,string operador)
        {
            double resultado=0;
            switch(ValidarOperador(operador))
            {
                case "+":
                    {
                        resultado = num1 + num2;
                        break;
                    }
                case "-":
                    {
                        resultado = num1 - num2;
                        break;
                    }
                case "*":
                    {
                        resultado = num1 * num2;
                        break;
                    }
                case "/":
                    {
                        resultado = num1 / num2;
/*                        if(num2==0)
                        {
                            resultado = double.MinValue;
                        } else { resultado = num1/num2; }
*/                        break;
                    }
            }
            return resultado;
        }

    }
}
