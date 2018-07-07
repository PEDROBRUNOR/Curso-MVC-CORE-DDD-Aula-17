using Projeto.Curso.Core.Domain.Pedido.AgregacaoPedidos;
using System;
using System.Collections.Generic;

namespace Projeto.Curso.Core.Domain.Pedido.Interfaces.Services.AgregacaoPedidos
{
    public interface IServicePedidos : IDisposable
    {
        Pedidos Adicionar(Pedidos pedido);
        Pedidos Atualizar(Pedidos pedido);
        Pedidos Remover(Pedidos pedido);
        IEnumerable<Pedidos> ObterTodos();
        Pedidos ObterPorId(int id);
    }
}
