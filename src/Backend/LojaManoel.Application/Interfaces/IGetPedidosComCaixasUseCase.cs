using LojaManoel.Communication.reponse;

namespace LojaManoel.Application.Interfaces
{
    public interface IGetPedidosComCaixasUseCase
    {

        public Task<List<CaixaPedidoResponseJson>> Execute();
    }
}
