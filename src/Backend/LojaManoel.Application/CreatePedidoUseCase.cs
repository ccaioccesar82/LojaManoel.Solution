using LojaManoel.Application.Interfaces;
using LojaManoel.Communication.request;
using LojaManoel.Domain;
using LojaManoel.Infraestructure.Repositories;

namespace LojaManoel.Application
{
    public class CreatePedidoUseCase : ICreatePedidoUseCase
    {
        private readonly ILojaManoelRepository _repository;

        public CreatePedidoUseCase(ILojaManoelRepository repository)
        {
            _repository = repository;
        }


        public async Task Execute(IList<CreateProductRequestJson> request)
        {
            //Valida os campos do pedido
            Validate(request);

            //Cria a entidade de pedido
            var pedido = new Pedido();

            for (int i = 0; i < request.Count; i++)
            {
                pedido.produtos.Add(new Produto
                {
                    Item = request.ElementAt(i).Item,
                    Comprimento = request.ElementAt(i).Comprimento,
                    Largura = request.ElementAt(i).Largura,
                    Altura = request.ElementAt(i).Altura,
                    Volume = request.ElementAt(i).Comprimento * request.ElementAt(i).Largura * request.ElementAt(i).Altura
                });

            }

            //Calcula o volume total do pedido

            pedido.VolumeTotal = pedido.produtos.Select(p => p.Volume).Sum();

            //Cria o pedido no database
            await _repository.PedidoCreate(pedido);

        }



        private void Validate(IList<CreateProductRequestJson> request)
        {

            foreach (var produto in request)
            {
                if (produto.Largura <= 0 || produto.Altura <= 0 || produto.Comprimento <= 0 || string.IsNullOrEmpty(produto.Item))
                {

                    throw new Exception("Todos os campos são obrigatórios. Largura, altura e comprimento precisam ser maiores que 0");


                }

                if (produto.Largura.GetType() != typeof(int) || produto.Comprimento.GetType() != typeof(int) || produto.Altura.GetType() != typeof(int))
                {

                    throw new Exception("O tipo de largura, altura e comprimento precisam ser números inteiros");

                }
            }
        }
    }
}
