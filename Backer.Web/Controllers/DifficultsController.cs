using Backer.Application.Features.Difficults.Dtos;
using Backer.Application.Features.Difficults.Queries;
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
    public class DifficultsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public DifficultsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // Get All Difficults
        [HttpGet]
        public async Task<ActionResult<List<DifficultDto>>> GetAll()
        {
            try
            {
                var result = await _mediator.Send(new GetAllDifficultsQuery());
                return Ok(ResponseProvider.GetRespone(ResponseState.Success , result));
            }
            catch (Exception)
            {
                return Ok(ResponseProvider.GetRespone(ResponseState.Failed));
            }
        }

        // Get Difficult by ID
        [HttpGet("{id}")]
        public async Task<ActionResult<DifficultDto>> GetById(int id)
        {
            try
            {
                var result = await _mediator.Send(new GetDifficultByIdQuery(id));
                if (result == null)
                    return Ok(new Respone { State = ResponseState.Error, Message = "اطلاعاتی یافت نشد" });

                return Ok(ResponseProvider.GetRespone(ResponseState.Success, result));
            }
            catch (Exception)
            {
                return Ok(ResponseProvider.GetRespone(ResponseState.Failed));
            }
        }

        // Create a new Difficult
        [HttpPost("Create")]
        public async Task<ActionResult<int>> Create(CreateDifficultDto dto)
        {
            try
            {
                var id = await _mediator.Send(new CreateDifficultCommand(dto));
                return Ok(ResponseProvider.GetRespone(ResponseState.Success, id));
            }
            catch (Exception)
            {
                return Ok(ResponseProvider.GetRespone(ResponseState.Failed));
            }
        }

        // Update a Difficult
        [HttpPut("Update/{id}")]
        public async Task<ActionResult> Update(int id, UpdateDifficultDto dto)
        {
            try
            {
                if (id != dto.Id)
                    return Ok(ResponseProvider.GetRespone(ResponseState.Failed));

                var success = await _mediator.Send(new UpdateDifficultCommand(dto));
                return success
                    ? Ok(ResponseProvider.GetRespone(ResponseState.Success))
                    : Ok(ResponseProvider.GetRespone(ResponseState.Failed));
            }
            catch (Exception)
            {
                return Ok(ResponseProvider.GetRespone(ResponseState.Failed));
            }
        }

        // Delete a Difficult
        [HttpDelete("Delete/{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                var success = await _mediator.Send(new DeleteDifficultCommand(id));
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
