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
    public partial class ProdutoPagina : System.Web.UI.Page
    {
        private static ProdutoServico _servico = new ProdutoServico();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public static string ObterLista()
        {
            var lista = ConverterParaModel(_servico.ObterLista());

            return TratarParaJson.TratarSerializeObjectJson(lista);
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public static string Salvar(string produto)
        {
            var _produto = JsonConvert.DeserializeObject<Produto>(produto);
            _servico.Inserir(_produto);

            return null;
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public static string Atualizar(string produto)
        {
            var _produto = JsonConvert.DeserializeObject<Produto>(produto);
            _servico.Atualizar(_produto);

            return null;
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public static string Excluir(string produto)
        {
            var _produto = JsonConvert.DeserializeObject<Produto>(produto);
            _servico.Excluir(_produto);

            return null;
        }

        public static List<ProdutoModel> ConverterParaModel(IList<Produto> lista)
        {
            var listaObjModel = new List<ProdutoModel>();

            foreach (var item in lista)
            {
                var objModel = new ProdutoModel();

                objModel.ProdutoId = item.ProdutoId;
                objModel.Descricao = item.Descricao;
                objModel.Valor = item.Valor;
                listaObjModel.Add(objModel);
            }

            return listaObjModel;
        }
    }
}