using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public static class Calculadora
    {
        #region Métodos

        /// <summary>
        /// Realiza una operación entre dos números con el operador de tipo string que reciba por parámetro
        /// </summary>
        /// <param name="num1">Valor de tipo Numero que representa el primer operando</param>
        /// <param name="num2">Valor de tipo Numero que representa el segundo operando</param>
        /// <param name="operador">Valor de tipo string que representa el operador para realizar el cálculo</param>
        /// <returns>Devuelve el resultado de tipo double de la operación entre los dos números recibidos.
        /// En el caso de la división por cero, devuelve double.MinValue </returns>
        public static double Operar(Numero num1, Numero num2, string operador)
        {
            double retorno = 0;

            switch(ValidarOperador(operador))
            {
                case "+":
                    retorno = num1 + num2;
                    break;

                case "-":
                    retorno = num1 - num2;
                    break;

                case "*":
                    retorno = num1 * num2;
                    break;

                case "/":
                    retorno = num1 / num2;
                    break;
            }
            return retorno;
        }


        /// <summary>
        /// Valida que el valor de tipo string recibido sea un símbolo de operador
        /// </summary>
        /// <param name="operador">Valor de tipo string que se debe validar</param>
        /// <returns>Devuelve el símbolo recibido. En caso contrario devuelve el símbolo + (suma)</returns>
        private static string ValidarOperador(string operador)
        {
            if(operador == "+" || operador == "-" || operador == "*" || operador == "/")
            {
                return operador;
            }
            else
            {
                return "+";
            }
        }

        #endregion
    }
}
