using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LojaManoel.Communication.reponse
{
    public class CaixaResponseJson
    {
        public int Numero { get; set; }
        public string Tipo { get; set; } = string.Empty;
        public IList<ProdutosResponseJson> Produtos { get; set; } = [];
    }
}
