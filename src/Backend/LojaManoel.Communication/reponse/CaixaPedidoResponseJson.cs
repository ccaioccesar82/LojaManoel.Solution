namespace LojaManoel.Communication.reponse
{
    public class CaixaPedidoResponseJson
    {
        public Guid IdPedido { get; set; }
        public IList<CaixaResponseJson> caixas { get; set; } = [];
        

    }
}
