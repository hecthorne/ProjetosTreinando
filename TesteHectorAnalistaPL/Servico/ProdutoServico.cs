using Dominio.Entidades;
using Infra.Interfaces.Repository;
using Infra.Repository;
using System.Collections.Generic;
using System.Linq;

namespace Servico
{
    public class ProdutoServico
    {
        private IUnitOfWork _uow;
        private ProdutoRepository _repository;

        public ProdutoServico()
        {
            _uow = new UnitOfWork();
            _repository = new ProdutoRepository(_uow);
        }

        public Produto ObterProduto(Produto obj)
        {
            return _repository.SingleOrDefault(obj.ProdutoId);
        }

        public void Inserir(Produto obj)
        {   
            _repository.Insert(obj);
        }

        public void Atualizar(Produto obj)
        {
            var _obj = _repository.SingleOrDefault(obj.ProdutoId);
            _obj.Descricao = _obj.Descricao;
            _obj.Valor = _obj.Valor;

            _repository.Update(_obj);
        }

        public void Excluir(Produto obj)
        {
            var _obj = _repository.SingleOrDefault(obj.ProdutoId);
            _repository.Delete(_obj);
        }

        public IList<Produto> ObterLista()
        {
            var listaEndereco = _repository.GetAll();

            return listaEndereco.ToList();
        }
    }
}
