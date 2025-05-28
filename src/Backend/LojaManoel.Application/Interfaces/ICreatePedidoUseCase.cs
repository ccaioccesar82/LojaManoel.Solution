using LojaManoel.Communication.request;

namespace LojaManoel.Application.Interfaces
{
    public interface ICreatePedidoUseCase
    {
        public Task Execute(IList<CreateProductRequestJson> request);
    }
}
