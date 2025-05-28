using System.Threading.Tasks;
using LojaManoel.Application.Interfaces;
using LojaManoel.Communication.request;
using Microsoft.AspNetCore.Mvc;

namespace LojaManoel.Api.Controllers
{
    [Route("api/pedido")]
    [ApiController]
    public class LojaManoelController : ControllerBase
    {

        [Route("create")]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create([FromBody] IList<CreateProductRequestJson> request, [FromServices] ICreatePedidoUseCase usecase)
        {
            try
            {
                await usecase.Execute(request);

                return Created();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [Route("/caixa-produto")]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]

        public async Task<IActionResult> Index([FromServices] IGetPedidosComCaixasUseCase usecase)
        {
            try
            {
                var result = await usecase.Execute();

                if (result.Count == 0)
                    return NoContent();


                return Ok(result);


            }
            catch (Exception ex)
            {

                return NotFound(ex.Message);
            }
        }

    }
}
