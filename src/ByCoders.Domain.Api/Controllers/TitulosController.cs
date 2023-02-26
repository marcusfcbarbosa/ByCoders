using ByCoders.Core.Controllers;
using ByCoders.Core.Extensions;
using ByCoders.Domain.Api.Commands;
using ByCoders.Domain.Api.Entities;
using ByCoders.Domain.Api.Repositories;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ByCoders.Domain.Api.Controllers
{
    [Route("api/titulos")]
    [Authorize]
    public class TitulosController : MainController
    {
        private readonly ITituloRepository _tituloRepository;
        public TitulosController(ITituloRepository tituloRepository)
        {
            _tituloRepository = tituloRepository;
        }

        [HttpGet("all")]
        public async Task<PagedResult<Titulo>> Get([FromQuery] int ps = 8,
                                                      [FromQuery] int page = 1,
                                                      [FromQuery] string q = null)
        {
            return await _tituloRepository.GetAllTitulosPaged(ps, page, q);
        }

        [HttpPost("create")]
        public async Task<IActionResult> Post([FromServices] IMediator _mediator,
            AddCNABCommand command)
        {
            return CustomResponse(await _mediator.Send(command));
        }

    }
}
