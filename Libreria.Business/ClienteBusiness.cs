using System;
using System.Collections.Generic;
using System.Linq;
using Libreria.Data;
using Libreria.Entity;

namespace Libreria.Business
{
    public class ClienteBusiness
    {
        private readonly ClienteData clienteData;

        public ClienteBusiness()
        {
            this.clienteData = new ClienteData();
        }

        public void AltaCliente(Cliente cliente)
        {
            try
            {
                this.Validar(cliente);

                int id = this.clienteData.ObtenerProximoId();
                cliente.Nombre = cliente.Nombre.Trim();
                cliente.Apellido = cliente.Apellido.Trim();
                cliente.Telefono = NormalizarTextoOpcional(cliente.Telefono);
                cliente.Mail = NormalizarTextoOpcional(cliente.Mail);
                cliente.Direccion = NormalizarTextoOpcional(cliente.Direccion);
                cliente.Departamento = NormalizarTextoOpcional(cliente.Departamento);
                cliente.FechaAlta = DateTime.Now;
                this.clienteData.AltaCliente(cliente, id);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Cliente> ConsultarClientes()
        {
            try
            {
                return this.clienteData.ConsultarClientes();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void ModificarCliente(Cliente cliente)
        {
            try
            {
                if (cliente.Id <= 0)
                {
                    throw new Exception("Debe seleccionar un cliente.");
                }

                this.Validar(cliente, cliente.Id);

                Cliente clienteActual = this.clienteData
                    .ConsultarClientes()
                    .FirstOrDefault(clienteExistente => clienteExistente.Id == cliente.Id)
                    ?? throw new Exception("El cliente seleccionado no existe.");

                if (!this.ClienteTieneCambios(clienteActual, cliente))
                {
                    throw new Exception("No se modifico ningun dato.");
                }

                cliente.Nombre = cliente.Nombre.Trim();
                cliente.Apellido = cliente.Apellido.Trim();
                cliente.Telefono = NormalizarTextoOpcional(cliente.Telefono);
                cliente.Mail = NormalizarTextoOpcional(cliente.Mail);
                cliente.Direccion = NormalizarTextoOpcional(cliente.Direccion);
                cliente.Departamento = NormalizarTextoOpcional(cliente.Departamento);
                cliente.FechaAlta = clienteActual.FechaAlta;
                this.clienteData.ModificarCliente(cliente);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void EliminarCliente(int id)
        {
            try
            {
                if (id <= 0)
                {
                    throw new Exception("Debe seleccionar un cliente.");
                }

                Cliente clienteActual = this.clienteData
                    .ConsultarClientes()
                    .FirstOrDefault(clienteExistente => clienteExistente.Id == id)
                    ?? throw new Exception("El cliente seleccionado no existe.");

                if (!clienteActual.Estado)
                {
                    throw new Exception("El cliente seleccionado ya esta dado de baja.");
                }

                this.clienteData.CambiarEstadoCliente(id, false);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void ReactivarCliente(int id)
        {
            try
            {
                if (id <= 0)
                {
                    throw new Exception("Debe seleccionar un cliente.");
                }

                Cliente clienteActual = this.clienteData
                    .ConsultarClientes()
                    .FirstOrDefault(clienteExistente => clienteExistente.Id == id)
                    ?? throw new Exception("El cliente seleccionado no existe.");

                if (clienteActual.Estado)
                {
                    throw new Exception("El cliente seleccionado ya esta activo.");
                }

                this.clienteData.CambiarEstadoCliente(id, true);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Cliente> BuscarClientes(
            string nombre,
            string apellido,
            string documento,
            bool incluirNoActivos)
        {
            try
            {
                nombre = nombre.Trim();
                apellido = apellido.Trim();
                documento = documento.Trim();

                if (!string.IsNullOrWhiteSpace(documento)
                    && !documento.All(char.IsDigit))
                {
                    throw new Exception("Debe ingresar un DNI valido.");
                }

                return this.clienteData.BuscarClientes(
                    nombre,
                    apellido,
                    documento,
                    incluirNoActivos
                );
            }
            catch (Exception)
            {
                throw;
            }
        }

        private bool ClienteTieneCambios(Cliente clienteActual, Cliente clienteModificado)
        {
            return clienteActual.Documento != clienteModificado.Documento
                || !clienteActual.Nombre.Equals(clienteModificado.Nombre.Trim(), StringComparison.Ordinal)
                || !clienteActual.Apellido.Equals(clienteModificado.Apellido.Trim(), StringComparison.Ordinal)
                || !NormalizarTextoOpcional(clienteActual.Telefono).Equals(NormalizarTextoOpcional(clienteModificado.Telefono), StringComparison.Ordinal)
                || !NormalizarTextoOpcional(clienteActual.Mail).Equals(NormalizarTextoOpcional(clienteModificado.Mail), StringComparison.Ordinal)
                || !NormalizarTextoOpcional(clienteActual.Direccion).Equals(NormalizarTextoOpcional(clienteModificado.Direccion), StringComparison.Ordinal)
                || !NormalizarTextoOpcional(clienteActual.Departamento).Equals(NormalizarTextoOpcional(clienteModificado.Departamento), StringComparison.Ordinal)
                || ObtenerFecha(clienteActual.FechaNacimiento) != ObtenerFecha(clienteModificado.FechaNacimiento)
                || clienteActual.Estado != clienteModificado.Estado;
        }

        private static DateTime? ObtenerFecha(DateTime? fecha)
        {
            return fecha?.Date;
        }

        private static string NormalizarTextoOpcional(string? valor)
        {
            string texto = valor?.Trim() ?? string.Empty;
            return string.IsNullOrWhiteSpace(texto) ? string.Empty : texto;
        }

        private void Validar(Cliente cliente)
        {
            this.Validar(cliente, 0);
        }

        private void Validar(Cliente cliente, int idClienteActual)
        {
            if (cliente == null)
            {
                throw new Exception("Debe informar un cliente.");
            }

            if (cliente.Documento <= 0)
            {
                throw new Exception("Debe ingresar un documento valido.");
            }

            if (string.IsNullOrWhiteSpace(cliente.Nombre))
            {
                throw new Exception("Debe ingresar un nombre.");
            }

            if (string.IsNullOrWhiteSpace(cliente.Apellido))
            {
                throw new Exception("Debe ingresar un apellido.");
            }

            List<Cliente> clientes = this.clienteData.ConsultarClientes();

            bool documentoExistente = clientes.Any(clienteExistente =>
                clienteExistente.Documento == cliente.Documento
                && clienteExistente.Id != idClienteActual
            );

            if (documentoExistente)
            {
                throw new Exception("Ya existe un cliente con ese documento.");
            }
        }
    }
}