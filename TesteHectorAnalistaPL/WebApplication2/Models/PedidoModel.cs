using Dominio.Entidades;
using System;

namespace WebApplication2.Models
{
    public class PedidoModel
    {
        public int PedidoId { get; set; }

        public int Quantidade { get; set; }

        public decimal ValorTotal { get; set; }

        public virtual Produto Produto { get; set; }

        public virtual int ProdutoId { get; set; }

        public virtual Cliente Cliente { get; set; }

        public virtual int ClienteId { get; set; }

        public string Excluir
        {
            get
            {
                var valor = string.Format(@"<button type='button' onclick='Excluir({0})' 
                     class='btn btn-danger'><i class='glyphicon glyphicon-remove-sign'></i></button>"
                    , Convert.ToString(PedidoId));

                return valor;
            }
            set { }
        }

        public string Editar
        {
            get
            {
                var valor = string.Format(@"<button type='button' onclick='Editar({1})' 
                     class='btn btn-info'><i class='glyphicon glyphicon-edit'></i></button>"
                    , "\""
                    , Convert.ToString(PedidoId));

                return valor;
            }
            set { }
        }
    }
}