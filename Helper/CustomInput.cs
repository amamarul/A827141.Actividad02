using A827141.Actividad02.Model;
using System.Collections.Generic;
using System;
using System.Linq;

namespace A827141.Actividad02.Helper
{
    public class CustomInput
    {
        public static Operadores IngresoOperadores(
            int salida = 0, 
            string Mensaje = "Escribe el código del operador"
        ) {
            Console.WriteLine("\n");

            Operadores operadores = new Operadores();
            Operador operador;
            
            int input;
            bool existe;

            do
            {
                Console.WriteLine("\t" + Mensaje);

                Input.WriteRedLine("\to \""+ salida +"\" para no ingresar mas Operadores");

                input = Input.IngresoNumeroPositivo();

                operador = operadores.buscarOperador(input);

                existe = operadores.ExisteOperador(operador);

                if(existe) {
                    Input.WriteYellowLine("\tEl operadio con el código \""+ input +"\" ya existe.");
                }

                if (salida != input && !existe)
                {
                    operadores.agregarOperador(input);
                }
            } while (salida != input && !existe);

            return operadores;
        }

        public static Ordenes IngresoOrdenes(
            int salida = 0, 
            string Mensaje = "Escribe el código de la orden"
        ) {
            Console.WriteLine("\n");

            Ordenes ordenes = new Ordenes();
            Orden orden;
            
            int input;
            bool existe;

            do
            {
                Console.WriteLine("\t" + Mensaje);

                Input.WriteRedLine("\to \""+ salida +"\" para no ingresar mas ordenes");

                input = Input.IngresoNumeroPositivo();

                orden = ordenes.buscarOrden(input);

                existe = ordenes.ExisteOrden(orden);

                if(existe) {
                    Input.WriteYellowLine("\tEl operario con el código \""+ input +"\" ya existe.");
                }

                if (salida != input && !existe)
                {
                    ordenes.agregarOrden(input);
                }
            } while (salida != input);

            return ordenes;
        }

        public static Operador IngresarOperador(Operadores operadores)
        {
            Operador operador;
            int input;

            do
            {
                Console.WriteLine("\tIngrese un código de operador válido.");

                input = Input.IngresoNumeroPositivo();

                operador = operadores.buscarOperador(input);

                if (operadores.ExisteOperador(operador))
                {
                    break;
                }
            } while (true);

            return operador;
        }

        public static void AsignarOrden(Ordenes ordenes, Operadores operadores)
        {
            Operador operador;
            Orden proximaOrden;
            bool salir = false;

            do
            {
                Console.WriteLine("\t:::Asignación de ordenes:::");

                operador = CustomInput.IngresarOperador(operadores);

                proximaOrden = ordenes.ProximaOrdenNoAsignada();

                proximaOrden.Operador = operador;

                Input.WriteYellowLine(string.Format(
                    "Orden {0} asignada al operador {1}\n",
                    proximaOrden.NumeroOrden,
                    operador.NumeroOperador
                ));

                if (!ordenes.QuedanOrdenesSinAsignar()) {
                    Input.WriteYellowLine("\nBuen trabajo!! Ya no quedan ordenes sin asignar");
                    break;
                } 

                salir = Input.IngresoVerdaderoFalso("¿Desea continuar asignando ordenes?");
            } while (salir);
        }

        public static void Reporte(Ordenes ordenes)
        {
            Input.WriteGreenLine(":::Reporte de Ordenes:::");

            List<IGrouping<Operador, Orden>> ordenesAgrupadas = ordenes.GroupByOperador();
            
            foreach (var grupo in ordenesAgrupadas)
            {
                Input.WriteYellowLine(
                    string.Format(
                        "{0} con {1} ordenes\n",
                        grupo.Key.NumeroOperador == -1 
                            ? "Sin Asignación quedaron" 
                            : string.Format(
                                "El operador {0} cumplió",
                                grupo.Key.NumeroOperador
                            ),
                        grupo.Count()
                    )
                );
            }

        }
    }
}