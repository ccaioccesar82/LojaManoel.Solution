namespace LojaManoel.Communication.request
{
    public class CreateProductRequestJson
    {

        public string Item { get; set; } = string.Empty;
        public int Comprimento { get; set; }
        public int Largura { get; set; }
        public int Altura { get; set; }
    }
}
