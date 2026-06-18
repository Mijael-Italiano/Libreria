using Libreria.Entity;

namespace Libreria.Sesion
{
    public static class SesionActual
    {
        public static Usuario? Usuario { get; private set; }

        public static bool HayUsuario => Usuario != null;

        public static void Iniciar(Usuario usuario)
        {
            Usuario = usuario;
        }

        public static void Cerrar()
        {
            Usuario = null;
        }
    }
}
