using System;
using System.Collections.Generic;
using Libreria.Data.DataComposite;
using Libreria.Entity.EntityComposite;

namespace Libreria.Business.BusinessComposite
{
    public class PermisoBusiness
    {
        private readonly PermisoData permisoData;

        public PermisoBusiness()
        {
            this.permisoData = new PermisoData();
        }

        public List<Permiso> ConsultarPermisos()
        {
            try
            {
                return permisoData.ConsultarPermisos();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
