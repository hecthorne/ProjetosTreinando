using Dominio.Entidades;
using Newtonsoft.Json;
using Servico;
using System;
using System.Collections.Generic;
using System.Web.Script.Services;
using System.Web.Services;
using WebApp.TratamentoRetornoJson;
using WebApplication2.Models;

namespace WebApp.Paginas
{
    public partial class EnderecoPagina : System.Web.UI.Page
    {
        private static EnderecoServico _enderecoServico = new EnderecoServico();             

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public static string ListarClientes()
        {
            var lista = _enderecoServico.ObterListaClientes();

            return TratarParaJson.TratarSerializeObjectJson(lista);
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public static string Salvar(string endereco)
        {
            var _endereco = JsonConvert.DeserializeObject<Endereco>(endereco);
            _enderecoServico.Inserir(_endereco);

            return null;
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public static string Atualizar(string cliente)
        {
            var _endereco = JsonConvert.DeserializeObject<Endereco>(cliente);
            _enderecoServico.Atualizar(_endereco);

            return null;
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public static string Excluir(string endereco)
        {
            var _cliente = JsonConvert.DeserializeObject<Endereco>(endereco);
            _enderecoServico.Excluir(_cliente);

            return null;
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public static string ListarEnderecos()
        {
            var lista = ConverterParaModel(_enderecoServico.ObterListaEnderecos());

            return TratarParaJson.TratarSerializeObjectJson(lista);
        }

        public static List<EnderecoModel> ConverterParaModel(IList<Endereco> lista)
        {
            var listaEnderecoModel = new List<EnderecoModel>();

            foreach (var item in lista)
            {
                var enderecoModal = new EnderecoModel();
                enderecoModal.EnderecoId = item.EnderecoId;
                enderecoModal.EnderecoCompleto = item.EnderecoCompleto;
                enderecoModal.Bairro = item.Bairro;
                enderecoModal.Cep = item.Cep;
                enderecoModal.ClienteId = item.ClienteId;
                enderecoModal.NomeCliente = item.Cliente.Nome;

                listaEnderecoModel.Add(enderecoModal);
            }

            return listaEnderecoModel;
        }
    }
}