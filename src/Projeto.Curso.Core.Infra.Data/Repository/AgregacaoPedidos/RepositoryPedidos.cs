using Dapper;
using Microsoft.EntityFrameworkCore;
using Projeto.Curso.Core.Domain.Pedido.AgregacaoPedidos;
using Projeto.Curso.Core.Domain.Pedido.Entidades;
using Projeto.Curso.Core.Domain.Pedido.Interfaces.Repository.AgregacaoPedidos;
using Projeto.Curso.Core.Infra.Data.Context;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Projeto.Curso.Core.Infra.Data.Repository.AgregacaoPedidos
{
    public class RepositoryPedidos : Repository<Pedidos>, IRepositoryPedidos
    {
        public RepositoryPedidos(ContextEFPedidos context)
            : base(context)
        {

        }

        public override IEnumerable<Pedidos> ObterTodos()
        {
            StringBuilder query = new StringBuilder();
            query.AppendLine(@"SELECT * FROM pedidos P
                               INNER JOIN clientes C ON p.IdCliente = C.Id 
                               ORDER BY p.Id DESC");
            var pedidos = Db.Database.GetDbConnection().Query<Pedidos, Clientes, Pedidos>(query.ToString(),
                (p, c) =>
                {
                    p.Cliente = c;
                    return p;
                });

            foreach (var item in pedidos)
            {
                var itens = ObterItensPedido(item.Id);
                item.QtdProdutos = itens.Count();
                item.TotalProdutos = itens.Sum(x => x.Produto.Valor);
            }

            return pedidos;
        }

        public override Pedidos ObterPorId(int id)
        {
            StringBuilder query = new StringBuilder();
            query.AppendLine(@"SELECT * FROM pedidos P
                               INNER JOIN clientes C ON p.IdCliente = C.Id 
                               WHERE P.ID=@uID");
            var pedidos = Db.Database.GetDbConnection().Query<Pedidos, Clientes, Pedidos>(query.ToString(),
                (p, c) =>
                {
                    p.Cliente = c;
                    return p;
                }, new { uID = id });

            return pedidos.FirstOrDefault();
        }

        public IEnumerable<ItensPedidos> ObterItensPedido(int idpedido)
        {
            // return Db.ItensPedidos.Where(i => i.IdPedido == idpedido).OrderBy(i => i.Produto.Apelido);
            StringBuilder query = new StringBuilder();
            query.AppendLine(@"SELECT * FROM pedidos P
                               INNER JOIN clientes C ON p.IdCliente = C.Id 
                               INNER JOIN itenspedidos IT ON P.ID = IT.IdPedido
                               INNER JOIN produtos PD ON IT.IdProduto = PD.ID
                               INNER JOIN fornecedores F ON PD.IdFornecedor = F.ID
                               WHERE IT.IDPEDIDO=@uIDPEDIDO");
            var itenspedidos = Db.Database.GetDbConnection().Query<Pedidos, Clientes, ItensPedidos, Produtos, Fornecedores, ItensPedidos>(query.ToString(),
                (p, c, it, pd, f) =>
                {
                    p.Cliente = c;
                    it.Pedido = p;
                    pd.Fornecedor = f;
                    it.Produto = pd;
                    return it;
                }, new { @uIDPEDIDO = idpedido });
            return itenspedidos;
        }

        public ItensPedidos ObterItensPedidosPorId(int id)
        {
            // return Db.ItensPedidos.AsNoTracking().FirstOrDefault(i => i.Id == id);
            StringBuilder query = new StringBuilder();
            query.AppendLine(@"SELECT * FROM pedidos P
                               INNER JOIN clientes C ON p.IdCliente = C.Id 
                               INNER JOIN itenspedidos IT ON P.ID = IT.IdPedido
                               INNER JOIN produtos PD ON IT.IdProduto = PD.ID
                               INNER JOIN fornecedores F ON PD.IdFornecedor = F.ID
                               WHERE IT.ID=@uID");
            var itenspedidos = Db.Database.GetDbConnection().Query<Pedidos, Clientes, ItensPedidos, Produtos, Fornecedores, ItensPedidos>(query.ToString(),
                (p, c, it, pd, f) =>
                {
                    p.Cliente = c;
                    it.Pedido = p;
                    pd.Fornecedor = f;
                    it.Produto = pd;
                    return it;
                }, new { uID = id });

            return itenspedidos.FirstOrDefault();

        }

        public void AdicionarItensPedidos(ItensPedidos item)
        {
            Db.ItensPedidos.Add(item);
        }

        public void AtulizarItensPedidos(ItensPedidos item)
        {
            Db.ItensPedidos.Update(item);
        }

        public void RemoverItensPedidos(ItensPedidos item)
        {
            Db.ItensPedidos.Remove(item);
        }


    }
}
