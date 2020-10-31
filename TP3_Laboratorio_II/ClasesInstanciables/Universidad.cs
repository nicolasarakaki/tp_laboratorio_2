using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Excepciones;
using Archivos;

namespace ClasesInstanciables
{
    public class Universidad
    {

        #region Atributos y Enum

        private List<Alumno> alumnos;
        private List<Jornada> jornada;
        private List<Profesor> profesores;

        public enum EClases
        {
            Programacion, Laboratorio, Legislacion, SPD
        }

        #endregion


        #region Propiedades e Indexadores

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

        public List<Profesor> Instructores
        {
            get
            {
                return this.profesores;
            }
            set
            {
                this.profesores = value;
            }
        }

        public List<Jornada> Jornadas
        {
            get
            {
                return this.jornada;
            }
            set
            {
                this.jornada = value;
            }
        }

        public Jornada this[int i]
        {
            get
            {
                return this.jornada[i];
            }
            set
            {
                this.jornada[i] = value;
            }
        }

        #endregion


        #region Constructores

        public Universidad()
        {
            this.alumnos = new List<Alumno>();
            this.profesores = new List<Profesor>();
            this.jornada = new List<Jornada>();
        }

        #endregion


        #region Metodos

        /// <summary>
        /// Retorna todos los datos de la Universidad
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return MostrarDatos(this);
        }

        /// <summary>
        /// Retorna los datos de la Universidad para hacerlo publico mediante el ToString()
        /// </summary>
        /// <param name="uni">Objeto del tipo Universidad</param>
        /// <returns></returns>
        private static string MostrarDatos(Universidad uni)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("JORNADA:");
            foreach (Jornada jornada in uni.jornada)
            {
                sb.Append(jornada.ToString());
                sb.AppendLine("<----------------------------------------------------->\n");
            }

            return sb.ToString();
        }

        /// <summary>
        /// Serializa y Guarda los datos de un objeto del tipo Universidad en un archivo XML, incluyendo datos de los 
        /// Profesores, Alumnos y Jornadas.
        /// </summary>
        /// <param name="uni">Objeto del tipo Universidad</param>
        /// <returns>Retorna true si se realizo correctamente; caso contrario lanzara una excepcion</returns>
        /// <exception cref="ArchivosException"></exception>
        public static bool Guardar(Universidad uni)
        {
            bool retorno = false;
            string ruta = string.Format($"{AppDomain.CurrentDomain.BaseDirectory}Universidad.xml");
            Xml<Universidad> archivoXml = new Xml<Universidad>();

            if (archivoXml.Guardar(ruta, uni))
            {
                retorno = true;
            }

            return retorno;
        }

        /// <summary>
        /// Lee los datos de un archivo XML previamente serializado.
        /// </summary>
        /// <returns>
        /// Retorna un objeto del tipo Universidad si se pudo leer correctamente; caso contrario
        /// lanzara una excepcion
        /// </returns>
        /// <exception cref="ArchivosException"></exception>
        public static Universidad Leer()
        {
            Universidad universidad;

            string ruta = string.Format($"{AppDomain.CurrentDomain.BaseDirectory}Universidad.xml");
            Xml<Universidad> archivoXml = new Xml<Universidad>();

            if (File.Exists(ruta) && archivoXml.Leer(ruta, out universidad))
            {
                return universidad;
            }
            else
            {
                return null;
            }
        }

        #endregion


        #region Sobrecarga de Operadores

        /// <summary>
        /// Determina si un objeto Universidad tiene guardado un objeto del tipo Alumno.
        /// </summary>
        /// <param name="g">Objeto del tipo Universidad</param>
        /// <param name="a">Objeto del tipo Alumno</param>
        /// <returns>Retorna true si existe Alumno en Universidad; caso contrario false</returns>
        public static bool operator ==(Universidad g, Alumno a)
        {
            bool retorno = false;

            foreach (Alumno alumno in g.alumnos)
            {
                if (alumno == a)
                {
                    retorno = true;
                    break;
                }
            }

            return retorno;
        }

        /// <summary>
        /// Determina si un objeto Universidad NO tiene guardado un objeto del tipo Alumno.
        /// </summary>
        /// <param name="g">Objeto del tipo Universidad</param>
        /// <param name="a">Objeto del tipo Alumno</param>
        /// <returns>Retorna true si NO existe Alumno en Universidad; caso contrario false</returns>
        public static bool operator !=(Universidad g, Alumno a)
        {
            return !(g == a);
        }

        /// <summary>
        /// Determina si un objeto Universidad tiene guardado un objeto del tipo Profesor.
        /// </summary>
        /// <param name="g">Objeto del tipo Universidad</param>
        /// <param name="i">Objeto del tipo Profesor</param>
        /// <returns>Retorna true si existe Profesor en Universidad; caso contrario false</returns>
        public static bool operator ==(Universidad g, Profesor i)
        {
            bool retorno = false;

            foreach (Profesor profesor in g.profesores)
            {
                if (profesor == i)
                {
                    retorno = true;
                    break;
                }
            }

            return retorno;
        }

        /// <summary>
        /// Determina si un objeto Universidad NO tiene guardado un objeto del tipo Profesor.
        /// </summary>
        /// <param name="g">Objeto del tipo Universidad</param>
        /// <param name="i">Objeto del tipo Profesor</param>
        /// <returns>Retorna true si NO existe Profesor en Universidad; caso contrario false</returns>
        public static bool operator !=(Universidad g, Profesor i)
        {
            return !(g == i);
        }

        /// <summary>
        /// Determina si en la lista del tipo Profesor de Universidad existe un Profesor 
        /// que tenga el objeto EClase pasado por parametro.
        /// </summary>
        /// <param name="u">Objeto del tipo Universidad</param>
        /// <param name="clase">Enum de EClase</param>
        /// <returns>
        /// Si existe, devuelve el primer objeto del tipo Profesor que encuentra. Caso contrario
        /// lanzara una excepcion.
        /// </returns>
        /// <exception cref="SinProfesorException"></exception>
        public static Profesor operator ==(Universidad u, EClases clase)
        {
            bool retorno = false;
            Profesor profesor = null;

            foreach (Profesor auxProfe in u.profesores)
            {
                if (auxProfe == clase)
                {
                    profesor = auxProfe;
                    retorno = true;
                    break;
                }
            }

            if (!retorno)
            {
                throw new SinProfesorException();
            }

            return profesor;
        }

        /// <summary>
        /// Determina si en la lista del tipo Profesor de Universidad existe un Profesor 
        /// que NO tenga el objeto EClase pasado por parametro.
        /// </summary>
        /// <param name="u">Objeto del tipo Universidad</param>
        /// <param name="clase">Enum de EClase</param>
        /// <returns>
        /// Si existe, devuelve el primer objeto del tipo Profesor que encuentra. Caso contrario
        /// lanzara una excepcion.
        /// </returns>
        /// <exception cref="SinProfesorException"></exception>
        public static Profesor operator !=(Universidad u, EClases clase)
        {
            bool retorno = false;
            Profesor profesor = null;

            foreach (Profesor auxProfe in u.profesores)
            {
                if (auxProfe != clase)
                {
                    profesor = auxProfe;
                    retorno = true;
                    break;
                }
            }

            if (!retorno)
            {
                throw new SinProfesorException();
            }

            return profesor;
        }

        /// <summary>
        /// Genera y Agrega un objeto del tipo Jornada con: el tipo EClase pasado por parametro, un objeto del tipo
        /// Profesor que tenga esa EClase y los objetos del tipo Alumno que tengan esa EClase.
        /// </summary>
        /// <param name="g">Objeto del tipo Universidad</param>
        /// <param name="clase">Enum de EClase</param>
        /// <returns>
        /// Retorna la Universidad con la Jornada agregada. Caso contrario lanzara
        /// una excepcion.
        /// </returns>
        /// <exception cref="SinProfesorException"></exception>
        public static Universidad operator +(Universidad g, EClases clase)
        {
            Jornada jornada = new Jornada(clase, (g == clase));

            foreach (Alumno alumno in g.alumnos)
            {
                if (alumno == clase)
                {
                    jornada += alumno;
                }
            }

            g.jornada.Add(jornada);

            return g;
        }

        /// <summary>
        /// Agrega en Universidad objetos del tipo Alumno, validando que no este agregado previamente.
        /// </summary>
        /// <param name="u">Objeto del tipo Universidad</param>
        /// <param name="a">Objeto del tipo Alumno</param>
        /// <returns>Retorna la Universidad con el Alumno cargado. Caso contrario lanzara una excepcion</returns>
        /// <exception cref="AlumnoRepetidoException"></exception>
        public static Universidad operator +(Universidad u, Alumno a)
        {
            if (u != a)
            {
                u.alumnos.Add(a);
            }
            else
            {
                throw new AlumnoRepetidoException();
            }

            return u;
        }

        /// <summary>
        /// Agrega en Universidad objetos del tipo Profesor, validando que no este agregado previamente.
        /// </summary>
        /// <param name="u">Objeto del tipo Universidad</param>
        /// <param name="i">Objeto del tipo Profesor</param>
        /// <returns>
        /// Retorna la Universidad con el Profesor cargado. Caso contrario retorna la Universidad sin 
        /// la carga del Profesor
        /// </returns>
        public static Universidad operator +(Universidad u, Profesor i)
        {
            if (u != i)
            {
                u.profesores.Add(i);
            }

            return u;
        }

        #endregion
    }
}
