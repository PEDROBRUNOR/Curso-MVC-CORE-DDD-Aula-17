using System;
using System.Collections.Generic;
using Projeto.Curso.Core.Domain.Pedido.AgregacaoPedidos;
using Projeto.Curso.Core.Domain.Pedido.Interfaces.Repository.AgregacaoPedidos;
using Projeto.Curso.Core.Domain.Pedido.Interfaces.Services.AgregacaoPedidos;

namespace Projeto.Curso.Core.Domain.Pedido.Services.AgregacaoPedidos
{
    public class ServicePedidos : IServicePedidos
    {
        protected readonly IRepositoryPedidos repopedidos;

        public ServicePedidos(IRepositoryPedidos _repopedidos)
        {
            repopedidos = _repopedidos;
        }

        public Pedidos Adicionar(Pedidos pedido)
        {
            repopedidos.Adicionar(pedido);
            return pedido;
        }

        public Pedidos Atualizar(Pedidos pedido)
        {
            repopedidos.Atualizar(pedido);
            return pedido;

        }

        public Pedidos Remover(Pedidos pedido)
        {
            repopedidos.Remover(pedido);
            return pedido;
        }

        public IEnumerable<Pedidos> ObterTodos()
        {
            return repopedidos.ObterTodos();
        }


        public Pedidos ObterPorId(int id)
        {
            return repopedidos.ObterPorId(id);
        }
        public void Dispose()
        {
            repopedidos.Dispose();
            GC.SuppressFinalize(this);
        }

    }
}
