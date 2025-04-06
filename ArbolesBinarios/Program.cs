using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArbolesBinarios;
class Program
{
    static void Main(string[] args)
    {
        var arbol = new ArbolBinarioBusqueda();

        // Insertar valores
        arbol.Insertar(50);
        arbol.Insertar(30);
        arbol.Insertar(20);
        arbol.Insertar(40);
        arbol.Insertar(70);
        arbol.Insertar(60);
        arbol.Insertar(80);

        // Recorridos
        Console.WriteLine("Recorrido Inorden (izq, raíz, der):");
        arbol.Inorden(); // 20 30 40 50 60 70 80

        Console.WriteLine("\nRecorrido Preorden (raíz, izq, der):");
        arbol.Preorden(); // 50 30 20 40 70 60 80

        Console.WriteLine("\nRecorrido Postorden (izq, der, raíz):");
        arbol.Postorden(); // 20 40 30 60 80 70 50

        // Buscar un valor
        Console.WriteLine("\n¿Existe el valor 40?: " + arbol.Buscar(40)); // True
        Console.WriteLine("¿Existe el valor 100?: " + arbol.Buscar(100)); // False

        // Eliminar un nodo
        arbol.Eliminar(20);
        Console.WriteLine("\nInorden después de eliminar 20:");
        arbol.Inorden(); // 30 40 50 60 70 80

        arbol.Eliminar(50);
        Console.WriteLine("\nInorden después de eliminar 50:");
        arbol.Inorden(); // 30 40 60 70 80
    }
}
