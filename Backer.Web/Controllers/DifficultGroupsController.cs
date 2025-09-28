using Backer.Application.Features.DifficultGroups.Dtos;
using Backer.Application.Features.DifficultGroups.Queries;
using Backer.Utilities;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Backer.Web.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class DifficultGroupsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public DifficultGroupsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<List<DifficultGroupDto>>> GetAll()
        {
            try
            {
                var result = await _mediator.Send(new GetAllDifficultGroupsQuery());
                return Ok(ResponseProvider.GetRespone(ResponseState.Success, result));
            }
            catch
            {
                return Ok(ResponseProvider.GetRespone(ResponseState.Failed));
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<DifficultGroupDto>> GetById(int id)
        {
            try
            {
                var result = await _mediator.Send(new GetDifficultGroupByIdQuery(id));
                return result == null
                    ? Ok(new Respone { State = ResponseState.Error, Message = "اطلاعاتی یافت نشد" })
                    : Ok(ResponseProvider.GetRespone(ResponseState.Success, result));
            }
            catch
            {
                return Ok(ResponseProvider.GetRespone(ResponseState.Failed));
            }
        }

        [HttpPost("Create")]
        public async Task<ActionResult<int>> Create([FromBody] CreateDifficultGroupDto dto)
        {
            try
            {
                var id = await _mediator.Send(new CreateDifficultGroupCommand(dto));
                return Ok(ResponseProvider.GetRespone(ResponseState.Success, id));
            }
            catch
            {
                return Ok(ResponseProvider.GetRespone(ResponseState.Failed));
            }
        }

        [HttpPut("Update/{id}")]
        public async Task<ActionResult> Update(int id, [FromBody] UpdateDifficultGroupDto dto)
        {
            try
            {
                if (id != dto.Id)
                    return Ok(new Respone { State = ResponseState.Error, Message = "شناسه با اطلاعات تطابق ندارد" });

                var success = await _mediator.Send(new UpdateDifficultGroupCommand(dto));
                return Ok(ResponseProvider.GetRespone(success ? ResponseState.Success : ResponseState.Failed));
            }
            catch
            {
                return Ok(ResponseProvider.GetRespone(ResponseState.Failed));
            }
        }

        [HttpDelete("Delete/{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                var success = await _mediator.Send(new DeleteDifficultGroupCommand(id));
                return Ok(ResponseProvider.GetRespone(success ? ResponseState.Success : ResponseState.Failed));
            }
            catch
            {
                return Ok(ResponseProvider.GetRespone(ResponseState.Failed));
            }
        }
    }
}
