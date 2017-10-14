using Dominio.Entidades;
using Infra.Interfaces.Repository;
using Infra.Repository;
using System.Collections.Generic;
using System.Linq;

namespace Servico
{
    public class EnderecoServico
    {
        private IUnitOfWork _uow;        
        private EnderecoRepository _repository;
        private ClienteRepository _repositoryCliente;

        private static EnderecoServico _enderecoServico = new EnderecoServico();
        
        public EnderecoServico()
        {
            _uow = new UnitOfWork();
            _repository = new EnderecoRepository(_uow);
            _repositoryCliente = new ClienteRepository(_uow);
        }

        public IList<Cliente> ObterListaClientes()
        {
            var listaCliente = _repositoryCliente.GetAll().ToList();

            var listaClienteTratada = new List<Cliente>();

            foreach (var item in listaCliente)
            {
                var cli = new Cliente();
                cli.ClienteId = item.ClienteId;
                cli.Nome= item.Nome;

                listaClienteTratada.Add(cli);
            }

            return listaClienteTratada;
        } 

        public Endereco ObterEnderco(Endereco endereco)
        {
            return _repository.SingleOrDefault(endereco.EnderecoId);
        }

        public void Inserir(Endereco endereco)
        {
            var cliente = _repositoryCliente.SingleOrDefault(endereco.ClienteId);
            endereco.Cliente = cliente;
            _repository.Insert(endereco);
        }

        public void Atualizar(Endereco endereco)
        {
            var _endereco = _repository.SingleOrDefault(endereco.EnderecoId);
            _endereco.EnderecoCompleto = endereco.EnderecoCompleto;
            _endereco.Bairro = endereco.Bairro;
            _endereco.Cep = endereco.Cep;
            _endereco.ClienteId = endereco.ClienteId;

            _repository.Update(_endereco);
        }

        public void Excluir(Endereco endereco)
        {
            var _endereco = _repository.SingleOrDefault(endereco.EnderecoId);
            _repository.Delete(_endereco);
        }

        public IList<Endereco> ObterListaEnderecos()
        {
            var listaEndereco = _repository.GetAll();

            return listaEndereco.ToList();
        }
    }
}
