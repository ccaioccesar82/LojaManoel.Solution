using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LojaManoel.Communication.reponse
{
    public class ProdutosResponseJson
    {
        public Guid Id { get; set; }
        public string Item { get; set; } = string.Empty;
    }
}
