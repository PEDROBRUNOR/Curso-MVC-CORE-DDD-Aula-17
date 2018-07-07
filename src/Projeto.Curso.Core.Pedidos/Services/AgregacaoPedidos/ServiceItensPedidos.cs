using Projeto.Curso.Core.Domain.Pedido.AgregacaoPedidos;
using Projeto.Curso.Core.Domain.Pedido.Interfaces.Repository.AgregacaoPedidos;
using Projeto.Curso.Core.Domain.Pedido.Interfaces.Services.AgregacaoPedidos;
using System;
using System.Collections.Generic;

namespace Projeto.Curso.Core.Domain.Pedido.Services.AgregacaoPedidos
{
    public class ServiceItensPedidos : IServiceItensPedidos
    {
        private readonly IRepositoryPedidos repopedidos;

        public ServiceItensPedidos(IRepositoryPedidos _repopedidos)
        {
            repopedidos = _repopedidos;
        }

        public ItensPedidos AdicionarItensPedidos(ItensPedidos item)
        {
            repopedidos.AdicionarItensPedidos(item);
            return item;
        }

        public ItensPedidos AtulizarItensPedidos(ItensPedidos item)
        {
            repopedidos.AtulizarItensPedidos(item);
            return item;
        }

        public ItensPedidos RemoverItensPedidos(ItensPedidos item)
        {
            repopedidos.RemoverItensPedidos(item);
            return item;
        }



        public IEnumerable<ItensPedidos> ObterItensPedido(int idpedido)
        {
            return repopedidos.ObterItensPedido(idpedido);
        }


        public ItensPedidos ObterItensPedidosPorId(int id)
        {
            return ObterItensPedidosPorId(id);
        }

        public void Dispose()
        {
            repopedidos.Dispose();
            GC.SuppressFinalize(this);
        }

    }
}
