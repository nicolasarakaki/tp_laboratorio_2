using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Excepciones;

namespace Archivos
{
    public class Texto : IArchivo<string>
    {
        /// <summary>
        /// Guarda datos en un archivo TXT
        /// </summary>
        /// <param name="archivo">Ruta donde se guardara el archivo</param>
        /// <param name="datos">Datos de lo que se quiere guardar</param>
        /// <returns>Retorna true si guarda correctamente. Caso contrario lanzara una excepcion</returns>
        /// <exception cref="ArchivosException"></exception>
        public bool Guardar(string archivo, string datos)
        {
            bool retorno = false;

            try
            {
                using (StreamWriter sw = new StreamWriter(archivo))
                {
                    sw.WriteLine(datos);
                }
                retorno = true;
            }
            catch (Exception ex)
            {
                throw new ArchivosException(ex.InnerException);
            }

            return retorno;
        }

        /// <summary>
        /// Lee datos de un archivo TXT y los retorna en formato string a traves de la variable pasado por parametro.
        /// </summary>
        /// <param name="archivo">Ruta donde se leera el archivo</param>
        /// <param name="datos">Variable donde se quiere guardar los datos leidos</param>
        /// <returns>Retorna true si lee el archivo correctamente. Caso contrario lanzara una excepcion</returns>
        /// <exception cref="ArchivosException"></exception>
        public bool Leer(string archivo, out string datos)
        {
            bool retorno = false;

            try
            {
                string linea = string.Empty;
                string auxdato = string.Empty;

                using (StreamReader sr = new StreamReader(archivo))
                {
                    while((linea = sr.ReadLine()) != null)
                    {
                        auxdato += string.Format($"{linea}\n");
                    }
                    datos = auxdato;
                }
                retorno = true;
            }
            catch (Exception ex)
            {
                throw new ArchivosException(ex.InnerException);
            }

            return retorno;
        }
    }
}
