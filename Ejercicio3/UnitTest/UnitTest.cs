using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Ejercicio3;

namespace UnitTest
{
    [TestClass]
    public class UnitTest
    {
        [TestMethod]
        public void TestEjercicio1()
        {
            //Arrange
            Metodos metodo = new Metodos();
            int num = 40;
            bool resultado;
            //Act
            resultado = metodo.DivisionXCero(num);

            //Assert
            Assert.IsFalse(resultado);
        }

        [TestMethod]
        public void TestEjercicio2()
        {
            //Arrange
            Metodos metodo = new Metodos();
            int num1 = 40;
            int num2 = 0;
            bool resultado;
            //Act
            resultado = metodo.DivisionXCero2(num1,num2);
            
            //Assert
            Assert.IsFalse(resultado);
        }

    }
}
