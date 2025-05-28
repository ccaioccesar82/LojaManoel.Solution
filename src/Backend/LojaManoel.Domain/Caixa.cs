namespace LojaManoel.Domain
{
    public class Caixa
    {
        public string Tipo { get; set; } = string.Empty;

        public int VolumeCapacidade;
        public List<Produto> Produtos { get; set; } = [];
        public double VolumeAtual => Produtos.Sum(p => p.Volume);

        public bool TentarAdicionar(Produto produto)
        {
            if (VolumeAtual + produto.Volume <= VolumeCapacidade)
            {
                Produtos.Add(produto);
                return true;
            }
           
                return false;
            
        }
    }
}
