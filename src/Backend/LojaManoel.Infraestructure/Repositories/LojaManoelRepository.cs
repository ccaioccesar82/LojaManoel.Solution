using LojaManoel.Domain;
using Microsoft.EntityFrameworkCore;

namespace LojaManoel.Infraestructure.Repositories
{
    public class LojaManoelRepository : ILojaManoelRepository
    {
        private readonly LojaManoelDbContext _dbContext;

        public LojaManoelRepository(LojaManoelDbContext dbContext)
        {
            _dbContext = dbContext;
        }




        public async Task PedidoCreate(Pedido request)
        {

            await _dbContext.Pedidos.AddAsync(request);

            await _dbContext.SaveChangesAsync();
        }



        public async Task<IList<Pedido>> GetAllPedidos() => await _dbContext.Pedidos.AsNoTracking().Include(p => p.produtos).ToListAsync();


    }
}
