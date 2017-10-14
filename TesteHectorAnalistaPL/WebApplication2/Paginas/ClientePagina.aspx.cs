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
    public partial class ClientePagina1 : System.Web.UI.Page
    {
        private static ClienteServico _servico;

        protected void Page_Load(object sender, EventArgs e)
        {
            _servico = new ClienteServico();
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public static string ListarClientes()
        {
            var lista = ConverterParaModel(_servico.ObterListaClientes());

            return TratarParaJson.TratarSerializeObjectJson(lista);
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public static string Salvar(string cliente)
        {
            var _cliente = JsonConvert.DeserializeObject<Cliente>(cliente);
            _servico.Inserir(_cliente);

            return null;
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public static string Atualizar(string cliente)
        {
            var _cliente = JsonConvert.DeserializeObject<Cliente>(cliente);
            _servico.Atualizar(_cliente);

            return null;
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public static string Excluir(string cliente)
        {
            var _cliente = JsonConvert.DeserializeObject<Cliente>(cliente);
            _servico.Excluir(_cliente);

            return null;
        }

        public static List<ClienteModel> ConverterParaModel(IList<Cliente> lista)
        {
            var listaClienteModel = new List<ClienteModel>();
            
            foreach (var item in lista)
            {
                var clienteModel = new ClienteModel();
                clienteModel.ClienteId = item.ClienteId;
                clienteModel.Nome = item.Nome;
                listaClienteModel.Add(clienteModel);
            }

            return listaClienteModel;
        }
    }
}