using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TesteEverton.Models
{
    public class Endereco
    {
        public int Identificador { get; set; }
        public int IdentificadorCliente { get; set; }
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public string Cidade { get; set; }
        public string UF { get; set; }
        public string CEP { get; set; }
    }
}