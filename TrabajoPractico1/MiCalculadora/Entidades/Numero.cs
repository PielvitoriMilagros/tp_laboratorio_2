using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Numero
    {
        private double numero;

        #region Constructores
        public Numero()
        {
            this.numero = 0;
        }

        public Numero(double numero)
        {
            this.numero = numero;
        }


        public Numero(string strNumero)
        {
            this.SetNumero = strNumero;
        }

        #endregion


        public string SetNumero
        {
            set { this.numero = ValidarNumero(value); }
        }


        private double ValidarNumero(string strNumero)
        {
            double resultado;
            if (double.TryParse(strNumero, out resultado))
                return resultado;
            return 0;
        }

        #region Sobrecarga de Operadores

        public static double operator -(Numero n1, Numero n2)
        {
            return n1.numero - n2.numero;
        }

        public static double operator +(Numero n1, Numero n2)
        {
            return n1.numero+ n2.numero;
        }

        public static double operator *(Numero n1, Numero n2)
        {
            return n1.numero * n2.numero;
        }

        public static double operator /(Numero n1, Numero n2)
        {
            if (n2.numero == 0)
                return double.MinValue;
            return n1.numero / n2.numero;
        }

        #endregion


        public string BinarioDecimal(string binario)
        {
            double aux = 0;
            int x = 1;
            string numdec = "";
            for (int i = binario.Length - 1; i >= 0; i--)
            {
                if (binario[i] != '1' && binario[i] != '0')
                    return "Valor Inválido";
                numdec += binario[i];
            }
            for (int i = 0; i < numdec.Length; i++)
            {
                x = Convert.ToInt32(numdec[i]);
                if (x == 49)
                    aux += Math.Pow(2, i);
            }
            return Convert.ToString(aux);
        }

        public string DecimalBinario(double numero)
        {
            string num = Convert.ToString(numero);
            return DecimalBinario(num);
        }


        public string DecimalBinario(string numero)
        {
            int num;
            if (int.TryParse(numero, out num) == false)
                return "Valor Inválido";
            string binario = "";
            if (num > 0)
            {
                while (num > 0)
                {
                    if (num % 2 == 0)
                    {
                        binario = "0" + binario;
                    }
                    else
                    {
                        binario = "1" + binario;
                    }
                    num = num / 2;
                }
            }
            else if (num == 0)
            {
                binario = "0";
            }
            else
            {
                binario = "Valor inválido";
            }
            return binario;

        }



    }
}
