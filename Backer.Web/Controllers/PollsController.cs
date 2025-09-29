using Backer.Application.Features.AnswerPolls.Dtos;
using Backer.Application.Features.AnswerPolls.Queries;
using Backer.Application.Features.AskPolls.Dtos;
using Backer.Application.Features.AskPolls.Queries;
using Backer.Application.Features.PollSamples.Dtos;
using Backer.Application.Features.PollSamples.Queries;
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
    public class PollsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PollsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        #region Ask
        [HttpGet("GetAllAsks")]
        public async Task<ActionResult<List<AskPollDto>>> GetAllAsks()
        {
            try
            {
                var result = await _mediator.Send(new GetAllAskPollsQuery());
                return Ok(ResponseProvider.GetRespone(ResponseState.Success, result));
            }
            catch (Exception)
            {
                return Ok(ResponseProvider.GetRespone(ResponseState.Failed));
            }
        }

        // Get AskPoll by ID
        [HttpGet("GetAsk/{id}")]
        public async Task<ActionResult<AskPollDto>> GetAsk(int id)
        {
            try
            {
                var result = await _mediator.Send(new GetAskPollByIdQuery(id));
                if (result == null)
                    return Ok(new Respone { State = ResponseState.Error, Message = "اطلاعاتی یافت نشد" });

                return Ok(ResponseProvider.GetRespone(ResponseState.Success, result));
            }
            catch (Exception)
            {
                return Ok(ResponseProvider.GetRespone(ResponseState.Failed));
            }
        }

        // Create a new AskPoll
        [HttpPost("CreateAsk")]
        public async Task<ActionResult<int>> CreateAsk(CreateAskPollDto dto)
        {
            try
            {
                var id = await _mediator.Send(new CreateAskPollCommand(dto));
                return Ok(ResponseProvider.GetRespone(ResponseState.Success, id));
            }
            catch (Exception)
            {
                return Ok(ResponseProvider.GetRespone(ResponseState.Failed));
            }
        }

        // Update a AskPoll
        [HttpPost("UpdateAsk/{id}")]
        public async Task<ActionResult> UpdateAsk(int id, UpdateAskPollDto dto)
        {
            try
            {
                if (id != dto.Id)
                    return Ok(ResponseProvider.GetRespone(ResponseState.Failed));

                var success = await _mediator.Send(new UpdateAskPollCommand(dto));
                return success
                    ? Ok(ResponseProvider.GetRespone(ResponseState.Success))
                    : Ok(ResponseProvider.GetRespone(ResponseState.Failed));
            }
            catch (Exception)
            {
                return Ok(ResponseProvider.GetRespone(ResponseState.Failed));
            }
        }

        // Delete a AskPoll
        [HttpPost("DeleteAsk/{id}")]
        public async Task<ActionResult> DeleteAsk(int id)
        {
            try
            {
                var success = await _mediator.Send(new DeleteAskPollCommand(id));
                return success
                    ? Ok(ResponseProvider.GetRespone(ResponseState.Success))
                    : Ok(ResponseProvider.GetRespone(ResponseState.Failed));
            }
            catch (Exception)
            {
                return Ok(ResponseProvider.GetRespone(ResponseState.Failed));
            }
        }
        #endregion Ask

        #region Answer
        [HttpGet("GetAllAnswers")]
        public async Task<ActionResult<List<AnswerPollDto>>> GetAllAnswers()
        {
            try
            {
                var result = await _mediator.Send(new GetAllAnswerPollsQuery());
                return Ok(ResponseProvider.GetRespone(ResponseState.Success, result));
            }
            catch (Exception)
            {
                return Ok(ResponseProvider.GetRespone(ResponseState.Failed));
            }
        }

        // Get AnswerPoll by ID
        [HttpGet("GetAnswer/{id}")]
        public async Task<ActionResult<AnswerPollDto>> GetAnswer(int id)
        {
            try
            {
                var result = await _mediator.Send(new GetAnswerPollByIdQuery(id));
                if (result == null)
                    return Ok(new Respone { State = ResponseState.Error, Message = "اطلاعاتی یافت نشد" });

                return Ok(ResponseProvider.GetRespone(ResponseState.Success, result));
            }
            catch (Exception)
            {
                return Ok(ResponseProvider.GetRespone(ResponseState.Failed));
            }
        }

        // Create a new AnswerPoll
        [HttpPost("CreateAnswer")]
        public async Task<ActionResult<int>> CreateAnswer(CreateAnswerPollDto dto)
        {
            try
            {
                var id = await _mediator.Send(new CreateAnswerPollCommand(dto));
                return Ok(ResponseProvider.GetRespone(ResponseState.Success, id));
            }
            catch (Exception)
            {
                return Ok(ResponseProvider.GetRespone(ResponseState.Failed));
            }
        }

        // Update a AnswerPoll
        [HttpPost("UpdateAnswer/{id}")]
        public async Task<ActionResult> UpdateAnswer(int id, UpdateAnswerPollDto dto)
        {
            try
            {
                if (id != dto.Id)
                    return Ok(ResponseProvider.GetRespone(ResponseState.Failed));

                var success = await _mediator.Send(new UpdateAnswerPollCommand(dto));
                return success
                    ? Ok(ResponseProvider.GetRespone(ResponseState.Success))
                    : Ok(ResponseProvider.GetRespone(ResponseState.Failed));
            }
            catch (Exception)
            {
                return Ok(ResponseProvider.GetRespone(ResponseState.Failed));
            }
        }

        // Delete a AnswerPoll
        [HttpPost("DeleteAnswer/{id}")]
        public async Task<ActionResult> DeleteAnswer(int id)
        {
            try
            {
                var success = await _mediator.Send(new DeleteAnswerPollCommand(id));
                return success
                    ? Ok(ResponseProvider.GetRespone(ResponseState.Success))
                    : Ok(ResponseProvider.GetRespone(ResponseState.Failed));
            }
            catch (Exception)
            {
                return Ok(ResponseProvider.GetRespone(ResponseState.Failed));
            }
        }
        #endregion Answer

        #region Sample
        [HttpGet("GetAllSamples")]
        public async Task<ActionResult<List<PollSampleDto>>> GetAllSamples()
        {
            try
            {
                var result = await _mediator.Send(new GetAllPollSamplesQuery());
                return Ok(ResponseProvider.GetRespone(ResponseState.Success, result));
            }
            catch (Exception)
            {
                return Ok(ResponseProvider.GetRespone(ResponseState.Failed));
            }
        }

        // Get SamplePoll by ID
        [HttpGet("GetSample/{id}")]
        public async Task<ActionResult<PollSampleDto>> GetSample(int id)
        {
            try
            {
                var result = await _mediator.Send(new GetPollSampleByIdQuery(id));
                if (result == null)
                    return Ok(new Respone { State = ResponseState.Error, Message = "اطلاعاتی یافت نشد" });

                return Ok(ResponseProvider.GetRespone(ResponseState.Success, result));
            }
            catch (Exception)
            {
                return Ok(ResponseProvider.GetRespone(ResponseState.Failed));
            }
        }

        // Create a new SamplePoll
        [HttpPost("CreateSample")]
        public async Task<ActionResult<int>> CreateSample(CreatePollSampleDto dto)
        {
            try
            {
                var id = await _mediator.Send(new CreatePollSampleCommand(dto));
                return Ok(ResponseProvider.GetRespone(ResponseState.Success, id));
            }
            catch (Exception)
            {
                return Ok(ResponseProvider.GetRespone(ResponseState.Failed));
            }
        }

        // Update a SamplePoll
        [HttpPost("UpdateSample/{id}")]
        public async Task<ActionResult> UpdateSample(int id, UpdatePollSampleDto dto)
        {
            try
            {
                if (id != dto.Id)
                    return Ok(ResponseProvider.GetRespone(ResponseState.Failed));

                var success = await _mediator.Send(new UpdatePollSampleCommand(dto));
                return success
                    ? Ok(ResponseProvider.GetRespone(ResponseState.Success))
                    : Ok(ResponseProvider.GetRespone(ResponseState.Failed));
            }
            catch (Exception)
            {
                return Ok(ResponseProvider.GetRespone(ResponseState.Failed));
            }
        }

        // Delete a SamplePoll
        [HttpPost("DeleteSample/{id}")]
        public async Task<ActionResult> DeleteSample(int id)
        {
            try
            {
                var success = await _mediator.Send(new DeletePollSampleCommand(id));
                return success
                    ? Ok(ResponseProvider.GetRespone(ResponseState.Success))
                    : Ok(ResponseProvider.GetRespone(ResponseState.Failed));
            }
            catch (Exception)
            {
                return Ok(ResponseProvider.GetRespone(ResponseState.Failed));
            }
        }
        #endregion Sample
    }
}
