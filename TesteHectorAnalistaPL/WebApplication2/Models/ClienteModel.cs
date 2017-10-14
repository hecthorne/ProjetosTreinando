using System;

namespace WebApplication2.Models
{
    public class ClienteModel
    {
        public int ClienteId { get; set; }
        public string Nome { get; set; }

        public string Excluir
        {
            get
            {
                return "<button type='submit' onclick='Excluir(" + Convert.ToString(ClienteId) + ",  \"" + Nome + "\")' class='btn btn-danger'><i class='glyphicon glyphicon-remove-sign'></i></button>";
            }
            set { }
        }

        public string Editar
        {
            get
            {
                return "<button type='button' onclick='Editar(" + Convert.ToString(ClienteId) + ",  \"" + Nome + "\")' class='btn btn-info'><i class='glyphicon glyphicon-edit'></i></button>";
            }
            set { }
        }
    }
}