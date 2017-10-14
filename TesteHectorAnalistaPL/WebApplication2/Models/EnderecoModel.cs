using System;

namespace WebApplication2.Models
{
    public class EnderecoModel
    {
        public int EnderecoId { get; set; }

        public string EnderecoCompleto { get; set; }

        public string Bairro { get; set; }

        public string Cep { get; set; }

        public virtual int ClienteId { get; set; }

        public string NomeCliente { get; set; }

        public string Excluir
        {
            get
            {
                var valor = string.Format(@"<button type='button' onclick='Excluir({0})' 
                     class='btn btn-danger'><i class='glyphicon glyphicon-remove-sign'></i></button>"
                    , Convert.ToString(EnderecoId));

                return valor;
            }
            set { }
        }

        public string Editar
        {
            get
            {
                var valor = string.Format(@"<button type='button' onclick='Editar({1},{0}{2}{0},{0}{3}{0},{0}{4}{0},{5})' 
                     class='btn btn-info'><i class='glyphicon glyphicon-edit'></i></button>"
                    , "\""
                    , Convert.ToString(EnderecoId)
                    , EnderecoCompleto
                    , Bairro
                    , Cep
                    , Convert.ToString(ClienteId));

                return valor;                
            }
            set { }
        }
    }
}