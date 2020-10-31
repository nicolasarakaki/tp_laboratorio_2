using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EntidadesAbstractas;
using ClasesInstanciables;

namespace TestUnitarios
{
    [TestClass]
    public class TestEntidades
    {
        [TestMethod]
        public void TestInstanciarColeccionTipoAlumno()
        {
            Universidad universidad = new Universidad();

            Assert.IsNotNull(universidad.Alumnos);
        }

        [TestMethod]
        public void TestGuardarYLeerArchivoXML()
        {
            Universidad universidad1 = new Universidad();
            Profesor profesor = new Profesor(1, "Pepe", "Pepo", "12345678", Persona.ENacionalidad.Argentino);

            universidad1 += profesor;

            Universidad.Guardar(universidad1);
            Universidad universidad2 = Universidad.Leer();

            Assert.IsTrue(universidad1.Instructores[0] == universidad2.Instructores[0]);
        }

    }
}
