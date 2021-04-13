using System.Collections.Generic;
using System;
using A827141.Actividad02.Helper;
using A827141.Actividad02.Model;

namespace A827141.Actividad02
{
    class Program
    {
        private static Operadores operadores;
        private static Ordenes ordenes;
        static void Main(string[] args)
        {
            /*
             Una empresa de cable necesita una aplicación para encolar las órdenes de instalación recibidas y asignarlas a los técnicos que las realizarán. Para ello se le solicita una aplicación que permita:
            */

            /* o A) El ingreso de una cantidad de operadores (identificados por un número de operador).
            */
            operadores = CustomInput.IngresoOperadores();

            /* o B) El ingreso de una cantidad de órdenes de trabajo (identificadas por un número de órden).
            */
            ordenes = CustomInput.IngresoOrdenes();

            /* o C) La asignación de una orden a un operador. Para ello, el usuario indicará un número de operador y el sistema le asignará la próxima orden de trabajo no asignada, teniendo en cuenta el orden de carga del punto A), dando por terminada la asignación anterior en caso de existir una. Este proceso se repetirá tantas veces como indique el usuario.
            */

            CustomInput.AsignarOrden(ordenes, operadores);

            /* o D) Al terminar, reporte: cuántas órdenes cumplió cada operador, qué órdenes quedaron pendientes de asignar.
            */
            Console.Clear();

            CustomInput.Reporte(ordenes);

            Input.PresionaUnaTeclaParaContinuar();
        }
    }
}
