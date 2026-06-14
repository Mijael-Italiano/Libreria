using System;
using System.Collections.Generic;
using System.Linq;
using Libreria.Data.DataComposite;
using Libreria.Entity.EntityComposite;

namespace Libreria.Business.BusinessComposite
{
    public class RolBusiness
    {
        private readonly RolData rolData;

        public RolBusiness()
        {
            this.rolData = new RolData();
        }

        public void AltaRol(string nombre)
        {
            try
            {
                this.Validar(nombre);

                int id = this.rolData.ObtenerProximoId();
                Rol rol = new Rol(id, nombre.Trim());

                this.rolData.AltaRol(rol);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Rol> ConsultarRoles()
        {
            try
            {
                return this.rolData.ConsultarRoles();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void ModificarRol(int id, string nombre)
        {
            try
            {
                if (id <= 0)
                {
                    throw new Exception("Debe seleccionar un rol.");
                }

                this.Validar(nombre, id);

                bool existeRol = this.rolData.ConsultarRoles().Any(rol => rol.Id == id);

                if (!existeRol)
                {
                    throw new Exception("El rol seleccionado no existe.");
                }

                Rol rol = new Rol(id, nombre.Trim());
                this.rolData.ModificarRol(rol);
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void Validar(string nombre)
        {
            this.Validar(nombre, 0);
        }

        private void Validar(string nombre, int idRolActual)
        {
            if (string.IsNullOrWhiteSpace(nombre))
            {
                throw new Exception("Debe ingresar un nombre para el rol.");
            }

            List<Rol> roles = this.rolData.ConsultarRoles();

            bool existe = roles.Any(rol =>
                rol.Nombre.Equals(nombre.Trim(), StringComparison.OrdinalIgnoreCase)
                && rol.Id != idRolActual
            );

            if (existe)
            {
                throw new Exception("Ya existe un rol con ese nombre.");
            }
        }
    }
}
