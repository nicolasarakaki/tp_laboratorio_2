using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas;

namespace ClasesInstanciables
{
    public sealed class Profesor : Universitario
    {

        #region Atributos

        private Queue<Universidad.EClases> clasesDelDia;
        private static Random random;

        #endregion


        #region Constructores

        static Profesor()
        {
            random = new Random();
        }

        public Profesor()
        {

        }


        public Profesor(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            : base(id, nombre, apellido, dni, nacionalidad)
        {
            this.clasesDelDia = new Queue<Universidad.EClases>();
            this._randomClases();
        }

        #endregion


        #region Metodos

        /// <summary>
        /// Asigna dos clases de forma aleatoria del tipo EClases a la lista de clasesDelDia del Profesor
        /// </summary>
        private void _randomClases()
        {
            for (int i = 0; i < 2; i++)
            {
                int clase = random.Next(0, 4);
                this.clasesDelDia.Enqueue((Universidad.EClases)clase);
            }
        }

        /// <summary>
        /// Retorna los datos del Profesor
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return this.MostrarDatos();
        }

        /// <summary>
        /// Retorna los datos del Profesor para hacerlo publico con ToString()
        /// </summary>
        /// <returns></returns>
        protected override string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(base.MostrarDatos());
            sb.Append(this.ParticiparEnClase());

            return sb.ToString();
        }

        /// <summary>
        /// Retorna la cadena "CLASES DEL DÍA" junto al nombre de las clases que da.
        /// </summary>
        /// <returns></returns>
        protected override string ParticiparEnClase()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("CLASES DEL DÍA:");

            foreach (Universidad.EClases clases in this.clasesDelDia)
            {
                sb.AppendLine(clases.ToString());
            }

            return sb.ToString();
        }

        #endregion


        #region Sobrecarga de Operadores

        /// <summary>
        /// Determina si el Profesor tiene la clase a comparar.
        /// </summary>
        /// <param name="i">Objeto del tipo Profesor</param>
        /// <param name="clase">Enum de EClases</param>
        /// <returns>Retorna true si es correcto; caso contrario false</returns>
        public static bool operator ==(Profesor i, Universidad.EClases clase)
        {
            bool retorno = false;

            foreach (Universidad.EClases claseDelProfe in i.clasesDelDia)
            {
                if (claseDelProfe == clase)
                {
                    retorno = true;
                    break;
                }
            }

            return retorno;
        }

        /// <summary>
        /// Determina si el Profesor NO tiene la clase a comparar.
        /// </summary>
        /// <param name="i">Objeto del tipo Profesor</param>
        /// <param name="clase">Enum de EClases</param>
        /// <returns>Retorna true si es correcto; caso contrario false</returns>
        public static bool operator !=(Profesor i, Universidad.EClases clase)
        {
            return !(i == clase);
        }

        #endregion

    }
}
