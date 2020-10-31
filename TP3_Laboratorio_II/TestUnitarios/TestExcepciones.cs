using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EntidadesAbstractas;
using ClasesInstanciables;
using Archivos;
using Excepciones;

namespace TestUnitarios
{
    [TestClass]
    public class TestExcepciones
    {

        [TestMethod]
        [ExpectedException(typeof(DniInvalidoException))]
        public void TestDniInvalidoException()
        {
            Alumno alumno = new Alumno(1, "Nicolas", "Arakaki", "321A3212", Persona.ENacionalidad.Argentino,
                Universidad.EClases.Laboratorio, Alumno.EEstadoCuenta.AlDia);

        }

        [TestMethod]
        [ExpectedException(typeof(NacionalidadInvalidaException))]
        public void TestNacionalidadInvalidaException()
        {
            Alumno alumno = new Alumno(1, "Nicolas", "Arakaki", "99999999", Persona.ENacionalidad.Argentino,
                Universidad.EClases.Laboratorio, Alumno.EEstadoCuenta.AlDia);
        }

        [TestMethod]
        [ExpectedException(typeof(AlumnoRepetidoException))]
        public void TestAlumnoRepetidoException()
        {
            Universidad universidad = new Universidad();

            Alumno alumno1 = new Alumno(111, "Nicolas", "Arakaki", "99999999", Persona.ENacionalidad.Extranjero,
                Universidad.EClases.Laboratorio, Alumno.EEstadoCuenta.AlDia);
            Alumno alumno2 = new Alumno(111, "Pepe", "Gonzales", "44444444", Persona.ENacionalidad.Argentino,
                Universidad.EClases.Laboratorio, Alumno.EEstadoCuenta.AlDia);

            universidad += alumno1;
            universidad += alumno2;
        }

        [TestMethod]
        [ExpectedException(typeof(SinProfesorException))]
        public void TestSinProfesorExcetion()
        {
            Universidad universidad = new Universidad();

            universidad += Universidad.EClases.Laboratorio;
        }

        [TestMethod]
        [ExpectedException(typeof(ArchivosException))]
        public void TestArchivosException()
        {
            string ruta = string.Format("Jornada?.txt");
            Texto texto = new Texto();

            texto.Guardar(ruta, "EXPLOTA");
        }

    }
}
