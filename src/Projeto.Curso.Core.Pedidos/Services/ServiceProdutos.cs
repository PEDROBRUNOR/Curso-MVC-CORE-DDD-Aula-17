using Projeto.Curso.Core.Domain.Pedido.Entidades;
using Projeto.Curso.Core.Domain.Pedido.Interfaces.Repository;
using Projeto.Curso.Core.Domain.Pedido.Interfaces.Services;
using System;
using System.Collections.Generic;

namespace Projeto.Curso.Core.Domain.Pedido.Services
{
    public class ServiceProdutos : IServiceProdutos
    {

        private readonly IRepositoryProdutos repoprodutos;

        public ServiceProdutos(IRepositoryProdutos _repoprodutos)
        {
            repoprodutos = _repoprodutos;
        }

        public Produtos Adicionar(Produtos produto)
        {
            repoprodutos.Adicionar(produto);
            return produto;
        }

        public Produtos Atualizar(Produtos produto)
        {
            repoprodutos.Atualizar(produto);
            return produto;
        }

        public Produtos Remover(Produtos produto)
        {
            repoprodutos.Remover(produto);
            return produto;
        }

        public IEnumerable<Produtos> ObterTodos()
        {
            return repoprodutos.ObterTodos();
        }

        public Produtos ObterPorId(int id)
        {
            return repoprodutos.ObterPorId(id);
        }

        public Produtos ObterPorApelido(string apelido)
        {
            return repoprodutos.ObterPorApelido(apelido);
        }
        public Produtos ObterPorNome(string nome)
        {
            return repoprodutos.ObterPorNome(nome);
        }

        public void Dispose()
        {
            repoprodutos.Dispose();
            GC.SuppressFinalize(this);
        }

    }
}
