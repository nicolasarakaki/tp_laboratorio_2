using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas;

namespace ClasesInstanciables
{
    public sealed class Alumno : Universitario
    {


        #region Atributos y Enum

        private Universidad.EClases claseQueToma;
        private EEstadoCuenta estadoCuenta;

        public enum EEstadoCuenta
        {
            AlDia, Deudor, Becado
        }

        #endregion


        #region Constructores

        public Alumno()
        {

        }

        public Alumno(int id, string nombre, string apellido, string dni, 
            ENacionalidad nacionalidad, Universidad.EClases claseQueToma) 
            : base(id, nombre, apellido, dni, nacionalidad)
        {
            this.claseQueToma = claseQueToma; 
        }

        public Alumno(int id, string nombre, string apellido, string dni, 
            ENacionalidad nacionalidad, Universidad.EClases clasQueToma, EEstadoCuenta estadoCuenta)
            : this(id, nombre, apellido, dni, nacionalidad, clasQueToma)
        {
            this.estadoCuenta = estadoCuenta;
        }

        #endregion


        #region Metodos

        /// <summary>
        /// Retorna los datos del Alumno
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return this.MostrarDatos();
        }

        /// <summary>
        /// Retorna los datos del Alumno para hacerlo publico con ToString()
        /// </summary>
        /// <returns></returns>
        protected override string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(base.MostrarDatos());
            sb.AppendLine("");
            if(this.estadoCuenta == EEstadoCuenta.AlDia)
            {
                sb.AppendLine($"ESTADO DE CUENTA: Cuota al dia");
            }
            else
            {
                sb.AppendLine($"ESTADO DE CUENTA: {this.estadoCuenta}");
            }
            sb.Append(this.ParticiparEnClase());

            return sb.ToString();
        }

        /// <summary>
        /// Retorna la cadena "TOMA CLASES DE " junto al nombre de la clase que toma.
        /// </summary>
        /// <returns></returns>
        protected override string ParticiparEnClase()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"TOMA CLASES DE {this.claseQueToma}");

            return sb.ToString();
        }

        #endregion


        #region Sobrecarga de Operadores

        /// <summary>
        /// Determina si un Alumno tiene la clase de EClases y su estado de cuenta no es Deudor
        /// </summary>
        /// <param name="a">Objeto del tipo Alumno</param>
        /// <param name="clase">Enum de EClases</param>
        /// <returns>Retorna true si es correcto; caso contrario false</returns>
        public static bool operator ==(Alumno a, Universidad.EClases clase)
        {
            bool retorno = false;

            if (a.claseQueToma == clase && a.estadoCuenta != EEstadoCuenta.Deudor)
            {
                retorno = true;
            }

            return retorno;
        }

        /// <summary>
        /// Determina si un Alumno NO tiene la clase de EClases y su estado de cuenta no es Deudor
        /// </summary>
        /// <param name="a">Objeto del tipo Alumno</param>
        /// <param name="clase">Enum de EClases</param>
        /// <returns>Retorna true si es correcto; caso contrario false</returns>
        public static bool operator !=(Alumno a, Universidad.EClases clase)
        {
            return !(a == clase);
        }

        #endregion


    }
}
