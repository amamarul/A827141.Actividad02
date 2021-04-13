using System.Collections.Generic;
using System.Linq;

namespace A827141.Actividad02.Model
{
    public class Ordenes
    {
        private List<Orden> _ordenes;

        public Ordenes()
        {
            this._ordenes = new List<Orden> {};
        }

        public Ordenes(List<Orden> ordenes)
        {
            this._ordenes = ordenes;
        }

        public List<Orden> ListaDeOrdenes { 
            get => this._ordenes;
        }

        public void Orden(int Orden)
        {
            this._ordenes.Add(new Orden(Orden));
        }

        public void agregarOrden(int numeroOrden)
        {
            this._ordenes.Add(new Orden(numeroOrden));
        }

        public void agregarOrdenes(List<int> ordenes)
        {
            foreach (int Orden in ordenes)
            {
                this.Orden(Orden);
            }
        }

        public bool ExisteOrden(Orden orden)
        {
            return this._ordenes.Contains(orden);
        }

        public Orden buscarOrden(int numeroOrden)
        {
            return this._ordenes
                    .FirstOrDefault(
                        orden => orden.NumeroOrden == numeroOrden
                    );
        }

        public Orden ProximaOrdenNoAsignada()
        {
            return this._ordenes
                    .FirstOrDefault(
                        orden => orden.Operador == null 
                    );
        }

        public bool QuedanOrdenesSinAsignar()
        {
            return this._ordenes
                    .Count(
                        orden => orden.Operador == null 
                    ) > 0;
        }

        public List<IGrouping<Operador, Orden>> GroupByOperador()
        {
            Operador operadorSinAsignar = new Operador(-1);

            return this._ordenes
                    .GroupBy(
                        orden => orden.Operador == null 
                        ? operadorSinAsignar
                        : orden.Operador
                    ).ToList();
        }
    }
}