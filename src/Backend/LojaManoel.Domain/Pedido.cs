namespace LojaManoel.Domain
{
    public class Pedido
    {
        public Guid Id { get; set; }

        public int VolumeTotal { get; set; }

        public IList<Produto> produtos { get; set; } = [];


    }
}
