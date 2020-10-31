using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesAbstractas
{
    public abstract class Universitario : Persona
    {

        #region Atributos

        private int legajo;

        #endregion


        #region Constructores

        public Universitario()
        {

        }

        public Universitario(int legajo, string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            : base(nombre, apellido, dni, nacionalidad)
        {
            this.legajo = legajo;
        }

        #endregion


        #region Metodos

        /// <summary>
        /// Retorna datos del Universitario
        /// </summary>
        /// <returns></returns>
        protected virtual string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(base.ToString());
            sb.Append($"LEGAJO NUMERO: {this.legajo}");

            return sb.ToString();
        }

        protected abstract string ParticiparEnClase();

        /// <summary>
        /// Determina si el objeto actual con el objeto por parametro son del mismo Tipo y su Legajo o DNI son iguales.
        /// </summary>
        /// <param name="obj">Objeto a comparar con el objeto actual</param>
        /// <returns>Retorna true si es correcto, false si es incorrecto</returns>
        public override bool Equals(object obj)
        {
            bool retorno = false;
            if (obj is Universitario)
            {
                if ((this.DNI == ((Universitario)obj).DNI) || (this.legajo == ((Universitario)obj).legajo))
                {
                    retorno = true;
                }
            }
            return retorno;
        }

        #endregion


        #region Sobrecarga de Operadores

        /// <summary>
        /// Determina si los dos objetos tipo Universitarios son iguales
        /// </summary>
        /// <param name="pg1">Primer objeto a comparar</param>
        /// <param name="pg2">Segundo objeto a comparar</param>
        /// <returns>Retorna true si son iguales; false en caso contrario</returns>
        public static bool operator ==(Universitario pg1, Universitario pg2)
        {
            bool retorno = false;
            if (pg1.Equals(pg2))
            {
                retorno = true;
            }
            return retorno;
        }

        /// <summary>
        /// Determina si los dos objetos tipo Universitarios son distintos
        /// </summary>
        /// <param name="pg1">Primer objeto a comparar</param>
        /// <param name="pg2">Segundo objeto a comparar</param>
        /// <returns>Retorna true si son distintos; false en caso contrario</returns>
        public static bool operator !=(Universitario pg1, Universitario pg2)
        {
            return !(pg1 == pg2);
        }

        #endregion


    }
}
