using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;

namespace EntidadesAbstractas
{
    public abstract class Persona
    {

        #region Atributos y Enum

        private string apellido;
        private int dni;
        private ENacionalidad nacionalidad;
        private string nombre;

        public enum ENacionalidad
        {
            Argentino, Extranjero
        }

        #endregion


        #region Propiedades

        public string Apellido
        {
            get
            {
                return this.apellido;
            }
            set
            {
                this.apellido = ValidarNombreApellido(value);
            }
        }

        public int DNI
        {
            get
            {
                return this.dni;
            }
            set
            {
                this.dni = ValidarDni(this.nacionalidad, value);
            }
        }

        public ENacionalidad Nacionalidad
        {
            get
            {
                return this.nacionalidad;
            }
            set
            {
                this.nacionalidad = value;
            }
        }

        public string Nombre
        {
            get
            {
                return this.nombre;
            }
            set
            {
                this.nombre = ValidarNombreApellido(value);
            }
        }

        public string StringToDNI
        {
            set
            {
                this.dni = ValidarDni(this.nacionalidad, value);
            }
        }

        #endregion


        #region Constructores

        public Persona()
        {

        }

        public Persona(string nombre, string apellido, ENacionalidad nacionalidad)
        {
            this.Apellido = apellido;
            this.Nombre = nombre;
            this.nacionalidad = nacionalidad;
        }

        public Persona(string nombre, string apellido, int dni, ENacionalidad nacionalidad)
            : this(nombre, apellido, nacionalidad)
        {
            this.DNI = dni;
        }

        public Persona(string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            : this(nombre, apellido, nacionalidad)
        {
            this.StringToDNI = dni;
        }

        #endregion


        #region Metodos

        /// <summary>
        /// Valida que el DNI sea correcto, teniendo en cuenta su nacionalidad. 
        /// Arg: (1 - 89999999) / Extranjero: (90000000 - 99999999)
        /// </summary>
        /// <param name="nacionalidad">Tipo de nacionalidad del enum Personas.ENacionalidad</param>
        /// <param name="dato">Numero de DNI de tipo int</param>
        /// <returns> Retorna el DNI si es valido </returns>
        /// <exception cref="DniInvalidoException">Si se ingresa un DNI incorrecto</exception>
        /// <exception cref="NacionalidadInvalidaException">Si el DNI ingresado no coincide con el rango de la nacionalidad</exception>
        private int ValidarDni(ENacionalidad nacionalidad, int dato)
        {
            if (dato >= 100000000)
            {
                throw new DniInvalidoException("El DNI ingresado es incorrecto");
            }

            switch (nacionalidad)
            {
                case ENacionalidad.Argentino:

                    if (dato < 1 || dato >= 90000000)
                    {
                        throw new NacionalidadInvalidaException("La nacionalidad no coincide con el numero de DNI");
                    }
                    break;

                case ENacionalidad.Extranjero:

                    if (dato < 90000000 || dato > 99999999)
                    {
                        throw new NacionalidadInvalidaException("La nacionalidad no coincide con el numero de DNI");
                    }
                    break;
            }

            return dato;

        }

        /// <summary>
        /// Valida que el DNI sea correcto, teniendo en cuenta su nacionalidad. 
        /// Arg: (1 - 89999999) / Extranjero: (90000000 - 99999999)
        /// </summary>
        /// <param name="nacionalidad">Tipo de nacionalidad del enum Personas.ENacionalidad</param>
        /// <param name="dato">Numero de DNI de tipo string</param>
        /// <exception cref="DniInvalidoException">Si se ingresa un DNI incorrecto</exception>
        /// <exception cref="NacionalidadInvalidaException">Si el DNI ingresado no coincide con el rango de la nacionalidad</exception>
        private int ValidarDni(ENacionalidad nacionalidad, string dato)
        {
            int auxDato;

            if (!int.TryParse(dato, out auxDato) || dato.Length > 8)
            {
                throw new DniInvalidoException("El DNI ingresado es incorrecto");
            }
            else
            {
                return ValidarDni(nacionalidad, auxDato);
            }

        }

        /// <summary>
        /// Valida que los los nombres sean cadenas con caracteres validos para nombres o apellidos.
        /// </summary>
        /// <param name="dato">Nombre o Apellido a validar</param>
        /// <returns>Retorna el nombre o apellido si es valido; caso contrario se cargara un string vacio</returns>
        private string ValidarNombreApellido(string dato)
        {
            string retorno = string.Empty;
            bool flag = true;

            foreach (char caracter in dato)
            {
                if (!(caracter >= 'a' && caracter <= 'z' || caracter >= 'A' && caracter <= 'Z'))
                {
                    flag = false;
                    break;
                }
            }

            if (flag)
            {
                retorno = dato;
            }

            return retorno;
        }

        /// <summary>
        /// Retorna los datos de la Persona
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"NOMBRE COMPLETO: {this.Apellido} {this.Nombre}");
            sb.AppendLine($"NACIONALIDAD: {this.Nacionalidad}");

            return sb.ToString();
        }

        #endregion

    }
}
