using Backer.Application.Features.Telephones.Dtos;
using Backer.Application.Features.Telephones.Queries;
using Backer.Utilities;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Backer.Web.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class TelephonesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TelephonesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<List<TelephoneDto>>> GetAll()
        {
            try
            {
                var result = await _mediator.Send(new GetAllTelephonesQuery());
                return Ok(ResponseProvider.GetRespone(ResponseState.Success, result));
            }
            catch (Exception)
            {
                return Ok(ResponseProvider.GetRespone(ResponseState.Failed));
            }
        }

        [HttpGet("GetByID/{id}")]
        public async Task<ActionResult<TelephoneDto>> GetByID(int id)
        {
            try
            {
                var result = await _mediator.Send(new GetTelephoneByIdQuery(id));
                if (result == null)
                    return Ok(new Respone { State = ResponseState.Error, Message = "اطلاعاتی یافت نشد" });

                return Ok(ResponseProvider.GetRespone(ResponseState.Success, result));
            }
            catch (Exception)
            {
                return Ok(ResponseProvider.GetRespone(ResponseState.Failed));
            }
        }

        [HttpPost("Create")]
        public async Task<ActionResult<int>> Create(CreateTelephoneDto dto)
        {
            try
            {
                var id = await _mediator.Send(new CreateTelephoneCommand(dto));
                return Ok(ResponseProvider.GetRespone(ResponseState.Success, id));
            }
            catch (Exception)
            {
                return Ok(ResponseProvider.GetRespone(ResponseState.Failed));
            }
        }

        [HttpPost("Update/{id}")]
        public async Task<ActionResult> Update(int id, UpdateTelephoneDto dto)
        {
            try
            {
                if (id != dto.Id)
                    return Ok(ResponseProvider.GetRespone(ResponseState.Failed));

                var success = await _mediator.Send(new UpdateTelephoneCommand(dto));
                return success
                    ? Ok(ResponseProvider.GetRespone(ResponseState.Success))
                    : Ok(ResponseProvider.GetRespone(ResponseState.Failed));
            }
            catch (Exception)
            {
                return Ok(ResponseProvider.GetRespone(ResponseState.Failed));
            }
        }

        [HttpPost("Delete/{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                var success = await _mediator.Send(new DeleteTelephoneCommand(id));
                return success
                    ? Ok(ResponseProvider.GetRespone(ResponseState.Success))
                    : Ok(ResponseProvider.GetRespone(ResponseState.Failed));
            }
            catch (Exception)
            {
                return Ok(ResponseProvider.GetRespone(ResponseState.Failed));
            }
        }
    }
}
