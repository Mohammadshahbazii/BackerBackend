using Backer.Application.Features.Regions.Dtos;
using Backer.Application.Features.Regions.Queries;
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
    public class RegionsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public RegionsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("GetTopLevel")]
        public async Task<ActionResult<List<RegionDto>>> GetTopLevelRegions()
        {
            try
            {
                var result = await _mediator.Send(new GetTopLevelRegionsQuery());
                return Ok(ResponseProvider.GetRespone(ResponseState.Success, result));
            }
            catch
            {
                return Ok(ResponseProvider.GetRespone(ResponseState.Failed));
            }
        }

        [HttpGet("ByParent/{parentId}")]
        public async Task<ActionResult<List<RegionDto>>> GetRegionsByParentId(int parentId)
        {
            try
            {
                var result = await _mediator.Send(new GetRegionsByParentIdQuery(parentId));
                return Ok(ResponseProvider.GetRespone(ResponseState.Success, result));
            }
            catch
            {
                return Ok(ResponseProvider.GetRespone(ResponseState.Failed));
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<RegionDto>> GetById(int id)
        {
            var Region = await _mediator.Send(new GetRegionByIdQuery(id));
            return Ok(Region);
        }

        [HttpPost("Create")]
        public async Task<ActionResult<int>> Create(CreateRegionDto dto)
        {
            try
            {
                var id = await _mediator.Send(new CreateRegionCommand(dto));
                return Ok(ResponseProvider.GetRespone(ResponseState.Success, id));
            }
            catch (Exception)
            {
                return Ok(ResponseProvider.GetRespone(ResponseState.Failed));
            }
        }

        // Update a Region
        [HttpPut("Update/{id}")]
        public async Task<ActionResult> Update(int id, UpdateRegionDto dto)
        {
            try
            {
                if (id != dto.Id)
                    return Ok(ResponseProvider.GetRespone(ResponseState.Failed));

                var success = await _mediator.Send(new UpdateRegionCommand(dto));
                return success
                    ? Ok(ResponseProvider.GetRespone(ResponseState.Success))
                    : Ok(ResponseProvider.GetRespone(ResponseState.Failed));
            }
            catch (Exception)
            {
                return Ok(ResponseProvider.GetRespone(ResponseState.Failed));
            }
        }

        // Delete a Region
        [HttpDelete("Delete/{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                var success = await _mediator.Send(new DeleteRegionCommand(id));
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
