using LojaManoel.Application.Interfaces;
using LojaManoel.Communication.reponse;
using LojaManoel.Domain;
using LojaManoel.Infraestructure.Repositories;

namespace LojaManoel.Application
{
    public class GetPedidosComCaixasUseCase : IGetPedidosComCaixasUseCase
    {

        private readonly ILojaManoelRepository _repository;


        public GetPedidosComCaixasUseCase(ILojaManoelRepository repository)
        {
            _repository = repository;
        }


        public async Task<List<CaixaPedidoResponseJson>> Execute()
        {
            var list = await _repository.GetAllPedidos();

            return EmpocataPedido(list);

        }



        private List<CaixaPedidoResponseJson> EmpocataPedido(IList<Pedido> pedidos)
        {
            var result = new List<CaixaPedidoResponseJson>();


            var tiposCaixas = new List<(string tipo, int capacidade)>()
            {
                ("Caixa 1", 30 * 40 * 80),
                ("Caixa 2", 80 * 50 * 40),
                ("Caixa 3", 50 * 80 * 60)
            };

            foreach (var pedido in pedidos)
            {
                var caixas = new List<Caixa>();

                foreach (var produto in pedido.produtos.OrderByDescending(p => p.Volume))
                {
                    bool colocado = false;

                    // Tenta colocar em caixas existentes
                    foreach (var caixa in caixas)
                    {
                        if (caixa.TentarAdicionar(produto))
                        {
                            colocado = true;
                            break;
                        }
                    }

                    // Se não couber, tenta abrir nova caixa
                    if (!colocado)
                    {
                        foreach (var (tipo, capacidade) in tiposCaixas)
                        {
                            if (produto.Volume <= capacidade)
                            {
                                var novaCaixa = new Caixa
                                {
                                    Tipo = tipo,
                                    VolumeCapacidade = capacidade,
                                };

                                novaCaixa.TentarAdicionar(produto);
                                caixas.Add(novaCaixa);
                                break;
                            }
                        }
                    }
                }

                result.Add(new CaixaPedidoResponseJson
                {
                    IdPedido = pedido.Id,
                    caixas = [.. caixas.Select((c, i) => new CaixaResponseJson
                    {
                        Numero = i + 1,
                        Tipo = c.Tipo,
                        Produtos = [.. c.Produtos.Select(p => new ProdutosResponseJson
                        {
                            Id = p.Id,
                            Item = p.Item
                        })]
                    })]
                });
                
            }

            return result;
        }
    }
}



