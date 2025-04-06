namespace TestArbolesBinarios1
{
    [TestClass]
    public sealed class Test1
    {
        [TestMethod]
        public void TestMethod1()
        {

        }
    }
}

using Xunit;
using ArbolBinarioBusqueda; // Asegúrate de que el namespace coincida

namespace ArbolBinarioBusqueda.Tests
{
    public class ArbolBinarioBusquedaTests
    {
        private readonly ArbolBinarioBusqueda _arbol;

        public ArbolBinarioBusquedaTests()
        {
            _arbol = new ArbolBinarioBusqueda();
            // Árbol de ejemplo para pruebas:
            //       50
            //     /    \
            //    30     70
            //   / \    / \
            //  20  40 60  80
            _arbol.Insertar(50);
            _arbol.Insertar(30);
            _arbol.Insertar(20);
            _arbol.Insertar(40);
            _arbol.Insertar(70);
            _arbol.Insertar(60);
            _arbol.Insertar(80);
        }

        // ----- Pruebas de Inserción -----
        [Fact]
        public void Insertar_ValorNuevo_DeberiaExistirEnArbol()
        {
            _arbol.Insertar(55);
            Assert.True(_arbol.Buscar(55));
        }

        [Fact]
        public void Insertar_ValorDuplicado_NoDeberiaLanzarExcepcion()
        {
            var ex = Record.Exception(() => _arbol.Insertar(50));
            Assert.Null(ex); // No debe lanzar excepción
        }

        // ----- Pruebas de Búsqueda -----
        [Fact]
        public void Buscar_ValorExistente_DeberiaRetornarTrue()
        {
            Assert.True(_arbol.Buscar(40));
        }

        [Fact]
        public void Buscar_ValorInexistente_DeberiaRetornarFalse()
        {
            Assert.False(_arbol.Buscar(100));
        }

        // ----- Pruebas de Eliminación -----
        [Fact]
        public void Eliminar_NodoSinHijos_DeberiaEliminarloCorrectamente()
        {
            _arbol.Eliminar(20);
            Assert.False(_arbol.Buscar(20));
        }

        [Fact]
        public void Eliminar_NodoConUnHijo_DeberiaReemplazarloConSuHijo()
        {
            _arbol.Eliminar(20); // Elimina nodo izquierdo de 30
            _arbol.Eliminar(30); // 30 tiene solo hijo derecho (40)
            Assert.False(_arbol.Buscar(30));
            Assert.True(_arbol.Buscar(40));
        }

        [Fact]
        public void Eliminar_NodoConDosHijos_DeberiaReemplazarloConSucesorInorden()
        {
            _arbol.Eliminar(50); // Sucesor inorden: 60
            Assert.False(_arbol.Buscar(50));
            Assert.True(_arbol.Buscar(60));
        }

        // ----- Pruebas de Recorridos -----
        [Fact]
        public void Inorden_DeberiaRetornarValoresOrdenados()
        {
            var output = new System.IO.StringWriter();
            Console.SetOut(output);
            _arbol.Inorden();
            Assert.Equal("20 30 40 50 60 70 80 \n", output.ToString());
        }

        [Fact]
        public void Preorden_DeberiaRetornarRaizPrimero()
        {
            var output = new System.IO.StringWriter();
            Console.SetOut(output);
            _arbol.Preorden();
            Assert.Equal("50 30 20 40 70 60 80 \n", output.ToString());
        }

        [Fact]
        public void Postorden_DeberiaRetornarRaizAlFinal()
        {
            var output = new System.IO.StringWriter();
            Console.SetOut(output);
            _arbol.Postorden();
            Assert.Equal("20 40 30 60 80 70 50 \n", output.ToString());
        }
    }
}