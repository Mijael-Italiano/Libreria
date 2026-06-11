namespace Libreria.Entity.EntityComposite
{
    public class Permiso : Componente
    {
        public Permiso(int id, string nombre)
            : base(id, nombre)
        {
        }

        public override void AgregarHijo(Componente componente)
        {
            try
            {
                throw new Exception("Error: No se puede agregar un permiso o rol a un permiso.");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override List<Componente> ObtenerHijos()
        {
            try
            {
                throw new Exception("Error: No se puede listar los hijos de un permiso.");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
