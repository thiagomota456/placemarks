using System.Collections.Generic;
using System;

namespace placemarksAPI.Model
{
    public class Filters
    {
        public List<String> Cliente {  get; set; }
        public List<String> Situacao { get; set; }
        public List<String> Bairro { get; set; }

        public Filters(List<String> cliente, List<String> situacao, List<String> bairro) 
        { 
            this.Cliente = cliente;
            this.Situacao = situacao;
            this.Bairro = bairro;
        }
    }
}
