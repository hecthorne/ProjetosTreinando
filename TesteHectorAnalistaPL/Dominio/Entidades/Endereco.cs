using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Entidades
{
    public class Endereco
    {
        public int EnderecoId { get; set; }

        public string EnderecoCompleto { get; set; }

        public string Bairro { get; set; }

        public string Cep { get; set; }

        public virtual Cliente Cliente { get; set; }

        public virtual int ClienteId { get; set; }
    }
}
