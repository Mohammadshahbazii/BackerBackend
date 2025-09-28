using Backer.Application.Features.JobTitles.Dtos;
using Backer.Application.Features.JobTitles.Queries;
using Backer.Utilities;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[Authorize]
[ApiController]
[Route("[controller]")]
public class JobTitlesController : ControllerBase
{
    private readonly IMediator _mediator;

    public JobTitlesController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult<List<JobTitleDto>>> GetAll()
    {
        try
        {
            var result = await _mediator.Send(new GetAllJobTitlesQuery());
            return Ok(ResponseProvider.GetRespone(ResponseState.Success, result));
        }
        catch
        {
            return Ok(ResponseProvider.GetRespone(ResponseState.Failed));
        }
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<JobTitleDto>> GetById(int id)
    {
        var jobTitle = await _mediator.Send(new GetJobTitleByIdQuery(id));
        return Ok(jobTitle);
    }

    [HttpPost("Create")]
    public async Task<ActionResult<int>> Create(CreateJobTitleDto dto)
    {
        try
        {
            var id = await _mediator.Send(new CreateJobTitleCommand(dto));
            return Ok(ResponseProvider.GetRespone(ResponseState.Success, id));
        }
        catch (Exception)
        {
            return Ok(ResponseProvider.GetRespone(ResponseState.Failed));
        }
    }

    // Update a JobTitle
    [HttpPut("Update/{id}")]
    public async Task<ActionResult> Update(int id, UpdateJobTitleDto dto)
    {
        try
        {
            if (id != dto.Id)
                return Ok(ResponseProvider.GetRespone(ResponseState.Failed));

            var success = await _mediator.Send(new UpdateJobTitleCommand(dto));
            return success
                ? Ok(ResponseProvider.GetRespone(ResponseState.Success))
                : Ok(ResponseProvider.GetRespone(ResponseState.Failed));
        }
        catch (Exception)
        {
            return Ok(ResponseProvider.GetRespone(ResponseState.Failed));
        }
    }

    // Delete a JobTitle
    [HttpDelete("Delete/{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        try
        {
            var success = await _mediator.Send(new DeleteJobTitleCommand(id));
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