using Dominio.Entidades;
using Infra.Interfaces.Repository;
using Infra.Repository;
using System.Collections.Generic;
using System.Linq;

namespace Servico
{
    public class PedidoServico
    {
        private IUnitOfWork _uow;
        private PedidoRepository _repository;

        public PedidoServico()
        {
            _uow = new UnitOfWork();
            _repository = new PedidoRepository(_uow);
        }

        public Pedido ObterCliente(Pedido obj)
        {
            return _repository.SingleOrDefault(obj.ClienteId);
        }

        public void Inserir(Pedido obj)
        {
            _repository.Insert(obj);
        }

        public void Atualizar(Pedido obj)
        {
            var _obj = _repository.SingleOrDefault(obj.PedidoId);
            //_obj.Nome = obj.Nome;
            _repository.Update(_obj);
        }

        public void Excluir(Pedido obj)
        {
            var _obj = _repository.SingleOrDefault(obj.ClienteId);
            _repository.Delete(_obj);
        }

        public IList<Pedido> ObterListaClientes()
        {
            var listaPedido = _repository.GetAll();

            return listaPedido.ToList();
        }
    }
}
