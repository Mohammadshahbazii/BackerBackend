using Backer.Application.Features.Software.Dtos;
using Backer.Application.Features.Software.Queries;
using Backer.Application.Features.Solutions.Dtos;
using Backer.Application.Features.Solutions.Queries;
using Backer.Application.Features.Solutions.Queries.GetAllSolutions;
using Backer.Application.Features.Solutions.Queries.GetSolutionById;
using Backer.Utilities;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Backer.Web.Controllers;

[Authorize]
[ApiController]
[Route("[controller]")]
public class SolutionsController : ControllerBase
{
    private readonly IMediator _mediator;

    public SolutionsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<SolutionDto>> GetById(int id)
    {
        var solution = await _mediator.Send(new GetSolutionByIdQuery(id));
        return solution != null ? Ok(solution) : NotFound();
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<SolutionDto>>> GetAll()
    {
        
        try
        {
            var solutions = await _mediator.Send(new GetAllSolutionsQuery());
            return Ok(ResponseProvider.GetRespone(ResponseState.Success, solutions));
        }
        catch (Exception)
        {
            return Ok(ResponseProvider.GetRespone(ResponseState.Failed));
        }
    }

    [HttpPost("Create")]
    public async Task<ActionResult<int>> Create(CreateSolutionDto dto)
    {
        try
        {
            var id = await _mediator.Send(new CreateSolutionCommand(dto));
            return Ok(ResponseProvider.GetRespone(ResponseState.Success, id));
        }
        catch (Exception)
        {
            return Ok(ResponseProvider.GetRespone(ResponseState.Failed));
        }
    }

    [HttpPost("Update/{id}")]
    public async Task<ActionResult> Update(int id, UpdateSolutionDto dto)
    {
        try
        {
            if (id != dto.Id)
                return Ok(ResponseProvider.GetRespone(ResponseState.Failed));

            var success = await _mediator.Send(new UpdateSolutionCommand(dto));
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
            var success = await _mediator.Send(new DeleteSolutionCommand(id));
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