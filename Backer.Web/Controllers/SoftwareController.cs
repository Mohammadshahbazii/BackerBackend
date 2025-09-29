using Backer.Application.Features.AnswerPolls.Dtos;
using Backer.Application.Features.AnswerPolls.Queries;
using Backer.Application.Features.AskPolls.Dtos;
using Backer.Application.Features.AskPolls.Queries;
using Backer.Application.Features.Software.Dtos;
using Backer.Application.Features.Software.Queries;
using Backer.Application.Features.SoftwareVersions.Dtos;
using Backer.Application.Features.SoftwareVersions.Queries;
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
    public class SoftwareController : ControllerBase
    {
        private readonly IMediator _mediator;

        public SoftwareController(IMediator mediator)
        {
            _mediator = mediator;
        }

        #region Software

        [HttpGet("GetAllSoftwares")]
        public async Task<ActionResult<List<SoftwareDto>>> GetAllSoftwares()
        {
            try
            {
                var result = await _mediator.Send(new GetAllSoftwaresQuery());
                return Ok(ResponseProvider.GetRespone(ResponseState.Success, result));
            }
            catch (Exception)
            {
                return Ok(ResponseProvider.GetRespone(ResponseState.Failed));
            }
        }

        [HttpGet("GetSoftware/{id}")]
        public async Task<ActionResult<SoftwareDto>> GetSoftware(int id)
        {
            try
            {
                var result = await _mediator.Send(new GetSoftwareByIdQuery(id));
                if (result == null)
                    return Ok(new Respone { State = ResponseState.Error, Message = "اطلاعاتی یافت نشد" });

                return Ok(ResponseProvider.GetRespone(ResponseState.Success, result));
            }
            catch (Exception)
            {
                return Ok(ResponseProvider.GetRespone(ResponseState.Failed));
            }
        }

        [HttpPost("CreateSoftware")]
        public async Task<ActionResult<int>> CreateSoftware(CreateSoftwareDto dto)
        {
            try
            {
                var id = await _mediator.Send(new CreateSoftwareCommand(dto));
                return Ok(ResponseProvider.GetRespone(ResponseState.Success, id));
            }
            catch (Exception)
            {
                return Ok(ResponseProvider.GetRespone(ResponseState.Failed));
            }
        }


        [HttpPost("UpdateSoftware/{id}")]
        public async Task<ActionResult> UpdateSoftware(int id, UpdateSoftwareDto dto)
        {
            try
            {
                if (id != dto.Id)
                    return Ok(ResponseProvider.GetRespone(ResponseState.Failed));

                var success = await _mediator.Send(new UpdateSoftwareCommand(dto));
                return success
                    ? Ok(ResponseProvider.GetRespone(ResponseState.Success))
                    : Ok(ResponseProvider.GetRespone(ResponseState.Failed));
            }
            catch (Exception)
            {
                return Ok(ResponseProvider.GetRespone(ResponseState.Failed));
            }
        }

        [HttpPost("DeleteSoftware/{id}")]
        public async Task<ActionResult> DeleteSoftware(int id)
        {
            try
            {
                var success = await _mediator.Send(new DeleteSoftwareCommand(id));
                return success
                    ? Ok(ResponseProvider.GetRespone(ResponseState.Success))
                    : Ok(ResponseProvider.GetRespone(ResponseState.Failed));
            }
            catch (Exception)
            {
                return Ok(ResponseProvider.GetRespone(ResponseState.Failed));
            }
        }
        #endregion Software


        #region Version

        [HttpGet("GetAllVersions")]
        public async Task<ActionResult<List<SoftwareVersionDto>>> GetAllVersions()
        {
            try
            {
                var result = await _mediator.Send(new GetAllSoftwareVersionsQuery());
                return Ok(ResponseProvider.GetRespone(ResponseState.Success, result));
            }
            catch (Exception)
            {
                return Ok(ResponseProvider.GetRespone(ResponseState.Failed));
            }
        }

        [HttpGet("GetVersion/{id}")]
        public async Task<ActionResult<SoftwareVersionDto>> GetVersion(int id)
        {
            try
            {
                var result = await _mediator.Send(new GetSoftwareVersionByIdQuery(id));
                if (result == null)
                    return Ok(new Respone { State = ResponseState.Error, Message = "اطلاعاتی یافت نشد" });

                return Ok(ResponseProvider.GetRespone(ResponseState.Success, result));
            }
            catch (Exception)
            {
                return Ok(ResponseProvider.GetRespone(ResponseState.Failed));
            }
        }

        [HttpPost("CreateVersion")]
        public async Task<ActionResult<int>> CreateVersion(CreateSoftwareVersionDto dto)
        {
            try
            {
                var id = await _mediator.Send(new CreateSoftwareVersionCommand(dto));
                return Ok(ResponseProvider.GetRespone(ResponseState.Success, id));
            }
            catch (Exception)
            {
                return Ok(ResponseProvider.GetRespone(ResponseState.Failed));
            }
        }

        // Update a AnswerPoll
        [HttpPost("UpdateVersion/{id}")]
        public async Task<ActionResult> UpdateVersion(int id, UpdateSoftwareVersionDto dto)
        {
            try
            {
                if (id != dto.Id)
                    return Ok(ResponseProvider.GetRespone(ResponseState.Failed));

                var success = await _mediator.Send(new UpdateSoftwareVersionCommand(dto));
                return success
                    ? Ok(ResponseProvider.GetRespone(ResponseState.Success))
                    : Ok(ResponseProvider.GetRespone(ResponseState.Failed));
            }
            catch (Exception)
            {
                return Ok(ResponseProvider.GetRespone(ResponseState.Failed));
            }
        }

        [HttpPost("DeleteVersion/{id}")]
        public async Task<ActionResult> DeleteVersion(int id)
        {
            try
            {
                var success = await _mediator.Send(new DeleteSoftwareVersionCommand(id));
                return success
                    ? Ok(ResponseProvider.GetRespone(ResponseState.Success))
                    : Ok(ResponseProvider.GetRespone(ResponseState.Failed));
            }
            catch (Exception)
            {
                return Ok(ResponseProvider.GetRespone(ResponseState.Failed));
            }
        }
        #endregion Version
    }
}
