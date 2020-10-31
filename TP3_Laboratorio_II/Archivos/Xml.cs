using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Xml;
using Excepciones;

namespace Archivos
{
    public class Xml<T> : IArchivo<T>
    {
        /// <summary>
        /// Serializa y Guarda datos en un archivo XML
        /// </summary>
        /// <param name="archivo">Ruta donde se guardara el archivo</param>
        /// <param name="datos">Datos de lo que se quiere guardar</param>
        /// <returns>Retorna true si guarda correctamente. Caso contrario lanzara una excepcion</returns>
        /// <exception cref="ArchivosException"></exception>
        public bool Guardar(string archivo, T datos)
        {
            bool retorno = false;

            try
            {
                using(XmlTextWriter writer = new XmlTextWriter(archivo, Encoding.UTF8))
                {
                    XmlSerializer xmlSer = new XmlSerializer(typeof(T));

                    xmlSer.Serialize(writer, datos);
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
        /// Lee datos de un archivo XML y a traves de la variable pasado por parametro, retorna un objeto del mismo tipo. 
        /// </summary>
        /// <param name="archivo">Ruta donde se leera el archivo</param>
        /// <param name="datos">Variable donde se quiere guardar los datos leidos</param>
        /// <returns>Retorna true si lee el archivo correctamente. Caso contrario lanzara una excepcion</returns>
        /// <exception cref="ArchivosException"></exception>
        public bool Leer(string archivo, out T datos)
        {
            bool retorno = false;

            try
            {
                using(XmlTextReader reader = new XmlTextReader(archivo))
                {
                    XmlSerializer xmlSer = new XmlSerializer(typeof(T));

                    datos = (T)xmlSer.Deserialize(reader);
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
