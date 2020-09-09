using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Numero
    {
        #region Atributos

        private double numero;

        #endregion

        #region Constructores
        public Numero()
        {
            numero = 0;
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

        #region Propiedades
        
        private string SetNumero
        {
            set
            {
                numero = ValidarNumero(value);
            }
        }

        #endregion

        #region Métodos

        /// <summary>
        /// Valida si la cadena recibida es un string de caracteres numéricos
        /// </summary>
        /// <param name="strNumero">Cadena a validar</param>
        /// <returns>Devuelve la cadena convertido en numero double, de lo contrario devuelve 0 (cero)</returns>
        private static double ValidarNumero(string strNumero)
        {
            if(strNumero.Contains("."))
            {
                strNumero = strNumero.Replace(".", ",");
            }

            if(double.TryParse(strNumero, out double numDouble))
            {
                return numDouble;
            }
            else
            {
                return 0;
            }
        }

        /// <summary>
        /// Convierte el número binario recibido en un número decimal de tipo string
        /// </summary>
        /// <param name="binario">Valor tipo string que se quiere convertir</param>
        /// <returns>Devuelve el número convertido a decimal en forma de cadena, de lo contrario devuelve 
        /// un mensaje de error </returns>
        /// 
        public static string BinarioDecimal(string binario)
        {
            char caracterStr;
            bool todoOk = false;
            int auxNum;
            int sumatoria = 0;
            double auxDouble;
            
            for(int i=0; i<binario.Length; i++)
            {
                caracterStr = binario[i];
                if (char.IsNumber(binario, i) && caracterStr.CompareTo('1')==0 || caracterStr.CompareTo('0')==0)
                {
                    todoOk = true;
                }
                else
                {
                    todoOk = false;
                    break;
                }
            }

            if(todoOk)
            {
                for(int i=binario.Length; i>0; i--)
                {
                    caracterStr = binario[i-1];
                    auxNum = (int)char.GetNumericValue(caracterStr);
                    auxDouble = Math.Pow(2, (binario.Length - i));
                    sumatoria += (auxNum * (int)auxDouble);
                }
                return sumatoria.ToString();
            }
            else
            {
                if (binario.CompareTo("0") == 0)
                {
                    return "0";
                }
                else
                {
                    return "Valor inválido";
                }
            }

        }

        /// <summary>
        /// Convierte el número decimal recibido en una cadena de números binarios
        /// </summary>
        /// <param name="numero">Valor tipo double que se quiere convertir</param>
        /// <returns>Devuelve una cadena de números binarios, de lo contrario devuelve un mensaje de error</returns>
        public static string DecimalBinario(double numero)
        {
            int auxNum;
            string strBinario = "";
            if (numero > 0)
            {
                auxNum = (int)numero;
                while (auxNum > 0)
                {
                    if (auxNum % 2 == 0)
                    {
                        strBinario = "0" + strBinario;
                    }
                    else
                    {
                        strBinario = "1" + strBinario;
                    }
                    auxNum = auxNum / 2;
                }
                return strBinario;
            }
            else
            {
                if(numero == 0)
                {
                    return "0";
                }
                else
                {
                    return "Valor inválido";
                }
            }
        }

        /// <summary>
        /// Convierte el número decimal recibido en una cadena de números binarios
        /// </summary>
        /// <param name="strNumero">Valor tipo string que se quiere convertir</param>
        /// <returns>Devuelve el numero convertido a binario en forma de cadena, de lo contrario devuelve 
        /// un mensaje de error </returns>
        public static string DecimalBinario(string strNumero)
        {
            double numDouble = ValidarNumero(strNumero);

            if(strNumero.CompareTo("0")==0)
            {
                return "0";
            }

            if(numDouble != 0)
            {
                return DecimalBinario(numDouble);
            }
            else
            {
                return "Valor inválido";
            }
        }

        #endregion

        #region Operadores
        
        public static double operator + (Numero n1, Numero n2)
        {
            return n1.numero + n2.numero;
        }

        public static double operator - (Numero n1, Numero n2)
        {
            return n1.numero - n2.numero;
        }

        public static double operator * (Numero n1, Numero n2)
        {
            return n1.numero * n2.numero;
        }

        public static double operator / (Numero n1, Numero n2)
        {
            if(n2.numero == 0)
            {
                return double.MinValue;
            }
            else
            {
                return n1.numero / n2.numero;
            }
            
        }
        #endregion
    }
}
