using Projeto.Curso.Core.Domain.Pedido.Entidades;
using Projeto.Curso.Core.Domain.Pedido.Interfaces.Repository;
using Projeto.Curso.Core.Domain.Pedido.Interfaces.Services;
using System;
using System.Collections.Generic;

namespace Projeto.Curso.Core.Domain.Pedido.Services
{
    public class ServiceClientes : IServiceClientes
    {
        private readonly IRepositoryClientes repoclientes;

        public ServiceClientes(IRepositoryClientes _repoclientes)
        {
            repoclientes = _repoclientes;
        }


        public Clientes Adicionar(Clientes cliente)
        {
            repoclientes.Adicionar(cliente);
            return cliente;
        }

        public Clientes Atualizar(Clientes cliente)
        {
            repoclientes.Atualizar(cliente);
            return cliente;
        }

        public Clientes Remover(Clientes cliente)
        {
            repoclientes.Remover(cliente);
            return cliente;
        }

        public IEnumerable<Clientes> ObterTodos()
        {
            return repoclientes.ObterTodos();
        }

        public Clientes ObterPorId(int id)
        {
            return repoclientes.ObterPorId(id);
        }

        public Clientes ObterPorApelido(string apelido)
        {
            return repoclientes.ObterPorApelido(apelido);
        }

        public Clientes ObterPorCpfCnpj(string cpfcnpj)
        {
            return repoclientes.ObterPorCpfCnpj(cpfcnpj);
        }

        public void Dispose()
        {
            repoclientes.Dispose();
            GC.SuppressFinalize(this);
        }

    }
}
