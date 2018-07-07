using System.Collections.Generic;
using Projeto.Curso.Core.Domain.Pedido.Entidades;
using Projeto.Curso.Core.Domain.Pedido.Interfaces.Repository;
using Projeto.Curso.Core.Domain.Pedido.Interfaces.Services;
using System;


namespace Projeto.Curso.Core.Domain.Pedido.Services
{
    public class ServiceFornecedores : IServiceFornecedores
    {
        private readonly IRepositoryFornecedores repofornecedor;

        public ServiceFornecedores(IRepositoryFornecedores _repofornecedor)
        {
            repofornecedor = _repofornecedor;
        }

        public Fornecedores Adicionar(Fornecedores fornecedor)
        {
            repofornecedor.Adicionar(fornecedor);
            return fornecedor;
        }

        public Fornecedores Atualizar(Fornecedores fornecedor)
        {
            repofornecedor.Atualizar(fornecedor);
            return fornecedor;
        }

        public Fornecedores Remover(Fornecedores fornecedor)
        {
            repofornecedor.Remover(fornecedor);
            return fornecedor;
        }

        public IEnumerable<Fornecedores> ObterTodos()
        {
            return repofornecedor.ObterTodos();
        }

        public Fornecedores ObterPorId(int id)
        {
            return repofornecedor.ObterPorId(id);
        }

        public Fornecedores ObterPorApelido(string apelido)
        {
            return repofornecedor.ObterPorApelido(apelido);
        }

        public Fornecedores ObterPorCpfCnpj(string cpfcnpj)
        {
            return ObterPorCpfCnpj(cpfcnpj);
        }

        public void Dispose()
        {
            repofornecedor.Dispose();
            GC.SuppressFinalize(this);
        }

    }
}
