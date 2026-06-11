namespace Libreria.Entity.EntityComposite
{
    public class Rol : Componente
    {
        private readonly List<Componente> hijos;

        public Rol(int id, string nombre)
            : base(id, nombre)
        {
            this.hijos = new List<Componente>();
        }

        public override void AgregarHijo(Componente componente)
        {
            try
            {
                hijos.Add(componente);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public override List<Componente> ObtenerHijos()
        {
            try
            {
                return hijos;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
