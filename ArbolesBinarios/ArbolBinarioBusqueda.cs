﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArbolesBinarios
{
    // Nodo del árbol
    public class Nodo
    {
        public int Valor { get; set; }
        public Nodo Izquierdo { get; set; }
        public Nodo Derecho { get; set; }

        public Nodo(int valor)
        {
            Valor = valor;
            Izquierdo = null;
            Derecho = null;
        }
    }
    // Clase del Árbol Binario de Búsqueda
    public class ArbolBinarioBusqueda
    {
        private Nodo Raiz { get; set; }

        // Insertar un valor en el árbol
        public void Insertar(int valor)
        {
            Raiz = InsertarRecursivo(Raiz, valor);
        }

        private Nodo InsertarRecursivo(Nodo nodo, int valor)
        {
            if (nodo == null)
            {
                return new Nodo(valor);
            }

            if (valor < nodo.Valor)
            {
                nodo.Izquierdo = InsertarRecursivo(nodo.Izquierdo, valor);
            }
            else if (valor > nodo.Valor)
            {
                nodo.Derecho = InsertarRecursivo(nodo.Derecho, valor);
            }

            return nodo;
        }

        // Buscar un valor en el árbol
        public bool Buscar(int valor)
        {
            return BuscarRecursivo(Raiz, valor);
        }

        private bool BuscarRecursivo(Nodo nodo, int valor)
        {
            if (nodo == null)
            {
                return false;
            }

            if (valor == nodo.Valor)
            {
                return true;
            }

            return valor < nodo.Valor
                ? BuscarRecursivo(nodo.Izquierdo, valor)
                : BuscarRecursivo(nodo.Derecho, valor);
        }

        // Eliminar un valor del árbol
        public void Eliminar(int valor)
        {
            Raiz = EliminarRecursivo(Raiz, valor);
        }

        private Nodo EliminarRecursivo(Nodo nodo, int valor)
        {
            if (nodo == null)
            {
                return null;
            }

            if (valor < nodo.Valor)
            {
                nodo.Izquierdo = EliminarRecursivo(nodo.Izquierdo, valor);
            }
            else if (valor > nodo.Valor)
            {
                nodo.Derecho = EliminarRecursivo(nodo.Derecho, valor);
            }
            else
            {
                // Caso 1: Nodo sin hijos o con un solo hijo
                if (nodo.Izquierdo == null)
                {
                    return nodo.Derecho;
                }
                else if (nodo.Derecho == null)
                {
                    return nodo.Izquierdo;
                }

                // Caso 2: Nodo con dos hijos (se busca el sucesor inorden)
                nodo.Valor = MinValor(nodo.Derecho);
                nodo.Derecho = EliminarRecursivo(nodo.Derecho, nodo.Valor);
            }

            return nodo;
        }

        private int MinValor(Nodo nodo)
        {
            int min = nodo.Valor;
            while (nodo.Izquierdo != null)
            {
                min = nodo.Izquierdo.Valor;
                nodo = nodo.Izquierdo;
            }
            return min;
        }

        // Recorridos del árbol
        public string Inorden()
        {
            using (var writer = new StringWriter())
            {
                InordenRecursivo(Raiz, writer);
                return writer.ToString().Trim();
            }
        }

        private void InordenRecursivo(Nodo nodo, TextWriter writer)
        {
            if (nodo != null)
            {
                InordenRecursivo(nodo.Izquierdo, writer);
                writer.Write(nodo.Valor + " ");
                InordenRecursivo(nodo.Derecho, writer);
            }
        }

        // Similar para Preorden y Postorden
        public string Preorden()
        {
            using (var writer = new StringWriter())
            {
                PreordenRecursivo(Raiz, writer);
                return writer.ToString().Trim();
            }
        }

        private void PreordenRecursivo(Nodo nodo, TextWriter writer)
        {
            if (nodo != null)
            {
                writer.Write(nodo.Valor + " ");
                PreordenRecursivo(nodo.Izquierdo, writer);
                PreordenRecursivo(nodo.Derecho, writer);
            }
        }

        public string Postorden()
        {
            using (var writer = new StringWriter())
            {
                PostordenRecursivo(Raiz, writer);
                return writer.ToString().Trim();
            }
        }

        private void PostordenRecursivo(Nodo nodo, TextWriter writer)
        {
            if (nodo != null)
            {
                PostordenRecursivo(nodo.Izquierdo, writer);
                PostordenRecursivo(nodo.Derecho, writer);
                writer.Write(nodo.Valor + " ");
            }
        }
    }
    
}
