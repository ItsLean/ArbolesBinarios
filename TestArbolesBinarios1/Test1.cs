using ArbolesBinarios;

namespace TestArbolesBinarios1
{
    [TestClass]
    public class ArbolBinarioBusquedaTests
    {
        [TestMethod]
        //Crea primera raiz
        public void Insertar_ArbolVacio_()
        {
            // Arrange
            var arbol = new ArbolBinarioBusqueda();

            // Act
            arbol.Insertar(10);

            // Assert
            Assert.IsTrue(arbol.Buscar(10));
        }

        [TestMethod]
        //Inserta a la izquierdo
        public void Insertar_MenorQueRaiz_()
        {
            // Arrange
            var arbol = new ArbolBinarioBusqueda();
            arbol.Insertar(10);

            // Act
            arbol.Insertar(5);

            // Assert
            Assert.IsTrue(arbol.Buscar(5));
        }

        [TestMethod]
        //Inserta a la derecha
        public void Insertar_MayorQueRaiz_()
        {
            // Arrange
            var arbol = new ArbolBinarioBusqueda();
            arbol.Insertar(10);

            // Act
            arbol.Insertar(15);

            // Assert
            Assert.IsTrue(arbol.Buscar(15));
        }

        [TestMethod]
        //Retorna True
        public void Buscar_ElementoExistente_()
        {
            // Arrange
            var arbol = new ArbolBinarioBusqueda();
            arbol.Insertar(10);
            arbol.Insertar(5);
            arbol.Insertar(15);

            // Act & Assert
            Assert.IsTrue(arbol.Buscar(5));
            Assert.IsTrue(arbol.Buscar(10));
            Assert.IsTrue(arbol.Buscar(15));
        }

        [TestMethod]
        //Retorna False
        public void Buscar_ElementoNoExistente_RetornaFalse_()
        {
            // Arrange
            var arbol = new ArbolBinarioBusqueda();
            arbol.Insertar(10);
            arbol.Insertar(5);

            // Act & Assert
            Assert.IsFalse(arbol.Buscar(15));
            Assert.IsFalse(arbol.Buscar(0));
        }

        [TestMethod]
        //Elimina de forma correcta
        public void Eliminar_NodoSinHijose_()
        {
            // Arrange
            var arbol = new ArbolBinarioBusqueda();
            arbol.Insertar(10);
            arbol.Insertar(5);

            // Act
            arbol.Eliminar(5);

            // Assert
            Assert.IsFalse(arbol.Buscar(5));
            Assert.IsTrue(arbol.Buscar(10));
        }

        [TestMethod]
        //Elimina de forma Correcta
        public void Eliminar_NodoConUnHijo_()
        {
            // Arrange
            var arbol = new ArbolBinarioBusqueda();
            arbol.Insertar(10);
            arbol.Insertar(5);
            arbol.Insertar(2);

            // Act
            arbol.Eliminar(5);

            // Assert
            Assert.IsFalse(arbol.Buscar(5));
            Assert.IsTrue(arbol.Buscar(2));
            Assert.IsTrue(arbol.Buscar(10));
        }

        [TestMethod]
        //Elimina de forma Correcta
        public void Eliminar_NodoConDosHijos_()
        {
            // Arrange
            var arbol = new ArbolBinarioBusqueda();
            arbol.Insertar(10);
            arbol.Insertar(5);
            arbol.Insertar(2);
            arbol.Insertar(7);

            // Act
            arbol.Eliminar(5);

            // Assert
            Assert.IsFalse(arbol.Buscar(5));
            Assert.IsTrue(arbol.Buscar(2));
            Assert.IsTrue(arbol.Buscar(7));
            Assert.IsTrue(arbol.Buscar(10));
        }

        [TestMethod]
        //Elimina de forma Correcta
        public void Eliminar_RaizConDosHijos_()
        {
            // Arrange
            var arbol = new ArbolBinarioBusqueda();
            arbol.Insertar(10);
            arbol.Insertar(5);
            arbol.Insertar(15);

            // Act
            arbol.Eliminar(10);

            // Assert
            Assert.IsFalse(arbol.Buscar(10));
            Assert.IsTrue(arbol.Buscar(5));
            Assert.IsTrue(arbol.Buscar(15));
        }

        [TestMethod]
        public void Inorden_RecorridoCorrecto()
        {
            // Arrange
            var arbol = new ArbolBinarioBusqueda();
            arbol.Insertar(10);
            arbol.Insertar(5);
            arbol.Insertar(15);
            arbol.Insertar(3);
            arbol.Insertar(7);

            // Act
            var resultado = arbol.Inorden();

            // Assert
            Assert.AreEqual("3 5 7 10 15", resultado);
        }

        [TestMethod]
        public void Preorden_RecorridoCorrecto()
        {
            // Arrange
            var arbol = new ArbolBinarioBusqueda();
            arbol.Insertar(10);
            arbol.Insertar(5);
            arbol.Insertar(15);
            arbol.Insertar(3);
            arbol.Insertar(7);

            // Act
            var resultado = arbol.Preorden();

            // Assert
            Assert.AreEqual("10 5 3 7 15", resultado);
        }

        [TestMethod]
        public void Postorden_RecorridoCorrecto()
        {
            // Arrange
            var arbol = new ArbolBinarioBusqueda();
            arbol.Insertar(10);
            arbol.Insertar(5);
            arbol.Insertar(15);
            arbol.Insertar(3);
            arbol.Insertar(7);

            // Act
            var resultado = arbol.Postorden();

            // Assert
            Assert.AreEqual("3 7 5 15 10", resultado);
        }
    }

    // Clase auxiliar para capturar la salida de consola
    public class ConsoleOutput : IDisposable
    {
        private StringWriter stringWriter;
        private TextWriter originalOutput;

        public ConsoleOutput()
        {
            stringWriter = new StringWriter();
            originalOutput = Console.Out;
            Console.SetOut(stringWriter);
        }

        public string GetOutput()
        {
            return stringWriter.ToString();
        }

        public void Dispose()
        {
            Console.SetOut(originalOutput);
            stringWriter.Dispose();
        }
    }
}