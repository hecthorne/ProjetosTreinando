using Dominio.Entidades;
using Infra.Interfaces.Repository;
using Infra.Repository;
using System.Collections.Generic;
using System.Linq;

namespace Servico
{
    public class ClienteServico
    {
        private IUnitOfWork _uow;
        private ClienteRepository _repository;

        public ClienteServico()
        {
            _uow = new UnitOfWork();
            _repository = new ClienteRepository(_uow);
        }

        public Cliente ObterCliente(Cliente obj)
        {
            return _repository.SingleOrDefault(obj.ClienteId);             
        }

        public Cliente ObterCliente(int? id)
        {
            return _repository.SingleOrDefault(id);
        }

        public void Inserir(Cliente obj)
        {
            _repository.Insert(obj);
        }

        public void Atualizar(Cliente obj)
        {
            var _obj = _repository.SingleOrDefault(obj.ClienteId);
            _obj.Nome = obj.Nome;
            _repository.Update(_obj);
        }

        public void Excluir(Cliente obj)
        {
            var _obj = _repository.SingleOrDefault(obj.ClienteId);
            _repository.Delete(_obj);
        }

        public IList<Cliente> ObterListaClientes()
        {
            var listaCliente = _repository.GetAll();

            return listaCliente.ToList();
        }
        
    }
}
