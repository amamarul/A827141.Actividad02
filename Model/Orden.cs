namespace A827141.Actividad02.Model
{
    public class Orden
    {
        public int NumeroOrden { get; }
        public Operador Operador { get; set; }
        
        public Orden(int numeroOrden)
        {
            this.NumeroOrden = numeroOrden;
        }
    }
}