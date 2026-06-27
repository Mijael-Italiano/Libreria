using System;
using System.Collections.Generic;
using System.Linq;
using Libreria.Data.DataComposite;
using Libreria.Entity.EntityComposite;

namespace Libreria.Business.BusinessComposite
{
    public class RolPermisoBusiness
    {
        private readonly PermisoBusiness permisoBusiness;
        private readonly RolBusiness rolBusiness;
        private readonly RolPermisoData rolPermisoData;

        public RolPermisoBusiness()
        {
            this.permisoBusiness = new PermisoBusiness();
            this.rolBusiness = new RolBusiness();
            this.rolPermisoData = new RolPermisoData();
        }

        public void AsociarRolPermiso(int idRol, int idPermiso)
        {
            try
            {
                this.ValidarRolYPermiso(idRol, idPermiso);
                this.ValidarRelacionNoExistente(idRol, idPermiso);

                this.rolPermisoData.AsociarRolPermiso(idRol, idPermiso);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void DesasociarRolPermiso(int idRol, int idPermiso)
        {
            try
            {
                this.ValidarRolYPermiso(idRol, idPermiso);
                this.ValidarRelacionExistente(idRol, idPermiso);

                this.rolPermisoData.DesasociarRolPermiso(idRol, idPermiso);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Permiso> ConsultarPermisosPorRol(int idRol)
        {
            try
            {
                if (idRol <= 0)
                {
                    throw new Exception("Debe seleccionar un rol.");
                }

                Rol rol = this.rolBusiness
                    .ConsultarRoles()
                    .FirstOrDefault(rolExistente => rolExistente.Id == idRol)
                    ?? throw new Exception("El rol seleccionado no existe.");

                List<int> idsPermisos = this.rolPermisoData.ConsultarIdsPermisosPorRol(idRol);

                List<Permiso> permisos = this.permisoBusiness
                    .ConsultarPermisos()
                    .Where(permiso => idsPermisos.Contains(permiso.Id))
                    .ToList();

                foreach (Permiso permiso in permisos)
                {
                    rol.AgregarHijo(permiso);
                }

                return rol.ObtenerHijos()
                    .OfType<Permiso>()
                    .ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void ValidarRolYPermiso(int idRol, int idPermiso)
        {
            if (idRol <= 0)
            {
                throw new Exception("Debe seleccionar un rol.");
            }

            if (idPermiso <= 0)
            {
                throw new Exception("Debe seleccionar un permiso.");
            }

            bool existeRol = this.rolBusiness.ConsultarRoles().Any(rol => rol.Id == idRol);

            if (!existeRol)
            {
                throw new Exception("El rol seleccionado no existe.");
            }

            bool existePermiso = this.permisoBusiness.ConsultarPermisos().Any(permiso => permiso.Id == idPermiso);

            if (!existePermiso)
            {
                throw new Exception("El permiso seleccionado no existe.");
            }
        }

        private void ValidarRelacionNoExistente(int idRol, int idPermiso)
        {
            bool existeRelacion = this.rolPermisoData
                .ConsultarIdsPermisosPorRol(idRol)
                .Contains(idPermiso);

            if (existeRelacion)
            {
                throw new Exception("El rol ya tiene asignado ese permiso.");
            }
        }

        private void ValidarRelacionExistente(int idRol, int idPermiso)
        {
            bool existeRelacion = this.rolPermisoData
                .ConsultarIdsPermisosPorRol(idRol)
                .Contains(idPermiso);

            if (!existeRelacion)
            {
                throw new Exception("El rol no tiene asignado ese permiso.");
            }
        }
    }
}
