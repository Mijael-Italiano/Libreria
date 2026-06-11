namespace Libreria.Entity.EntityComposite
{
    public abstract class Componente
    {
        public int Id { get; set; }
        public string Nombre { get; set; }

        protected Componente(int id, string nombre)
        {
            this.Id = id;
            this.Nombre = nombre;
        }

        public abstract void AgregarHijo(Componente componente);

        public abstract List<Componente> ObtenerHijos();
    }
}
