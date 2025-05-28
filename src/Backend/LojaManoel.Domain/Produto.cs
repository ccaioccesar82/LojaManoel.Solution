namespace LojaManoel.Domain
{
    public class Produto
    {
        public Guid Id { get; set; }
        public string Item { get; set; } = string.Empty;
        public int Comprimento { get; set; }
        public int Largura { get; set; }

        public int Altura { get; set; }

        public int Volume { get; set; }

        public Guid PedidoId { get; set; }
        public Pedido? Pedido { get; set; }

    }
}
