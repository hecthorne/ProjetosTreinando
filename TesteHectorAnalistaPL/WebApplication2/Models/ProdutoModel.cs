using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication2.Models
{
    public class ProdutoModel
    {
        public int ProdutoId { get; set; }

        public string Descricao { get; set; }

        public decimal Valor { get; set; }

        public string Excluir
        {
            get
            {
                var valor = string.Format(@"<button type='button' onclick='Excluir({0})' 
                     class='btn btn-danger'><i class='glyphicon glyphicon-remove-sign'></i></button>"
                    , Convert.ToString(ProdutoId));

                return valor;
            }
            set { }
        }

        public string Editar
        {
            get
            {
                var valor = string.Format(@"<button type='button' onclick='Editar({1},{0}{2}{0},{0}{3}{0})' 
                     class='btn btn-info'><i class='glyphicon glyphicon-edit'></i></button>"
                    , "\""
                    , Convert.ToString(ProdutoId)
                    , Descricao
                    , Valor);

                return valor;
            }
            set { }
        }
    }
}