using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TesteEverton.Models
{
    public class Cliente
    {
        public int Identificador { get; set; }
        public string Nome { get; set; }
        public string CPF { get; set; }
        public string RG { get; set; }
        public DateTime DataNascimento { get; set; }
        public bool Ativo { get; set; }
    }
}