using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Archivos;
using Excepciones;

namespace ClasesInstanciables
{
    public class Jornada
    {

        #region Atributos

        private List<Alumno> alumnos;
        private Universidad.EClases clase;
        private Profesor instructor;

        #endregion


        #region Propiedades

        public List<Alumno> Alumnos
        {
            get
            {
                return this.alumnos;
            }
            set
            {
                this.alumnos = value;
            }
        }

        public Universidad.EClases Clase
        {
            get
            {
                return this.clase;
            }
            set
            {
                this.clase = value;
            }
        }

        public Profesor Instructor
        {
            get
            {
                return this.instructor;
            }
            set
            {
                this.instructor = value;
            }
        }

        #endregion


        #region Constructores

        private Jornada()
        {
            this.alumnos = new List<Alumno>();
        }

        public Jornada(Universidad.EClases clase, Profesor instrutor) : this()
        {
            this.Clase = clase;
            this.Instructor = instrutor;
        }

        #endregion


        #region Metodos

        /// <summary>
        /// Retorna todos los datos de la Jornada
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"CLASE DE: {this.clase} POR {this.instructor.ToString()}");
            sb.AppendLine($"ALUMNOS:");
            foreach (Alumno alumno in this.alumnos)
            {
                sb.Append(alumno.ToString());
            }

            return sb.ToString();
        }

        /// <summary>
        /// Guarda un objeto del tipo Jornada en un archivo de texto
        /// </summary>
        /// <param name="jornada">Objeto de tipo Jornada a guardar</param>
        /// <returns>Retorna true si se realizo correctamente; caso contrario lanzara una Excepcion</returns>
        /// <exception cref="ArchivosException"></exception>
        public static bool Guardar(Jornada jornada)
        {
            bool retorno = false;
            Texto archivoTxt = new Texto();
            string ruta = string.Format($"{AppDomain.CurrentDomain.BaseDirectory}Jornada.txt");

            if(archivoTxt.Guardar(ruta, jornada.ToString()))
            {
                retorno = true;
            }

            return retorno;
        }

        /// <summary>
        /// Retorna los datos de la Jornada como texto
        /// </summary>
        /// <returns></returns>
        /// /// <exception cref="ArchivosException"></exception>
        public static string Leer()
        {
            string retorno;
            string auxDato = string.Empty;
            Texto archivoTxt = new Texto();
            string ruta = string.Format($"{AppDomain.CurrentDomain.BaseDirectory}Jornada.txt");

            if (File.Exists(ruta) && archivoTxt.Leer(ruta, out auxDato))
            {
                retorno = auxDato;
            }
            else
            {
                retorno = string.Format("No existe el archivo a leer");
            }

            return retorno;
        }

        #endregion


        #region Sobrecarga de Operadores

        /// <summary>
        /// Determina si el objeto alumno se encuentra en la Jornada
        /// </summary>
        /// <param name="j">Objeto del tipo Jornada</param>
        /// <param name="a">Objeto del tipo Alumno</param>
        /// <returns>Retorna true si existe alumno en la Jornada; caso contrario false</returns>
        public static bool operator ==(Jornada j, Alumno a)
        {
            bool retorno = false;

            foreach (Alumno alumno in j.alumnos)
            {
                if (alumno == a)
                {
                    retorno = true;
                }
            }

            return retorno;
        }

        /// <summary>
        /// Determina si el objeto alumno NO se encuentra en la Jornada
        /// </summary>
        /// <param name="j">Objeto del tipo Jornada</param>
        /// <param name="a">Objeto del tipo Alumno</param>
        /// <returns>Retorna true si NO existe alumno en la Jornada; caso contrario false</returns>
        public static bool operator !=(Jornada j, Alumno a)
        {
            return !(j == a);
        }

        /// <summary>
        /// Agrega en Jornada un Alumno si la misma no existe dentro de la Jornada
        /// </summary>
        /// <param name="j">Objeto del tipo Jornada</param>
        /// <param name="a">Objeto del tipo Alumno</param>
        /// <returns>Retorna la Jornada con el Alumno, si el Alumno no estaba cargado; caso contrario devuelve la Jornada sin modificaciones</returns>
        public static Jornada operator +(Jornada j, Alumno a)
        {
            if (j != a)
            {
                j.alumnos.Add(a);
            }

            return j;
        }

        #endregion

    }
}
