using LojaManoel.Domain;

namespace LojaManoel.Infraestructure.Repositories
{
    public interface ILojaManoelRepository
    {
        public Task PedidoCreate(Pedido request);

        public Task<IList<Pedido>> GetAllPedidos();
    }
}
