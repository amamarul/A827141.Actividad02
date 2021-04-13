using System.Collections.Generic;
using System.Linq;

namespace A827141.Actividad02.Model
{
    public class Operadores
    {
        private List<Operador> _operadores;

        public Operadores()
        {
            this._operadores = new List<Operador> {};
        }

        public Operadores(List<Operador> operadores)
        {
            this._operadores = operadores;
        }

        public List<Operador> ListaDeOperadores { 
            get => this._operadores;
        }

        public void agregarOperador(int numeroOperador)
        {
            this._operadores.Add(new Operador(numeroOperador));
        }

        public void agregarOperadores(List<int> operadores)
        {
            foreach (int numeroOperador in operadores)
            {
                this.agregarOperador(numeroOperador);
            }
        }

        public bool ExisteOperador(Operador operador)
        {
            return this._operadores.Contains(operador);
        }

        public Operador buscarOperador(int numeroOperador)
        {
            return this._operadores
                    .FirstOrDefault(
                        operador => operador.NumeroOperador == numeroOperador
                    );
        }
    }
}