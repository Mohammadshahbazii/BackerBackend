using Backer.Application.Features.HardwareCartReaders.Dtos;
using Backer.Application.Features.HardwareCartReaders.Queries;
using Backer.Application.Features.HardwareChanges.Dtos;
using Backer.Application.Features.HardwareChanges.Queries;
using Backer.Application.Features.HardwareConnections.Dtos;
using Backer.Application.Features.HardwareConnections.Queries;
using Backer.Application.Features.HardwarePortals.Dtos;
using Backer.Application.Features.HardwarePortals.Queries;
using Backer.Application.Features.HardwareRepairs.Dtos;
using Backer.Application.Features.HardwareRepairs.Queries;
using Backer.Application.Features.HardwareReplaces.Dtos;
using Backer.Application.Features.HardwareReplaces.Queries;
using Backer.Application.Features.Hardwares.Dtos;
using Backer.Application.Features.Hardwares.Queries;
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
    public class HardwaresController : ControllerBase
    {
        private readonly IMediator _mediator;

        public HardwaresController(IMediator mediator)
        {
            _mediator = mediator;
        }

        #region Models
        [HttpGet]
        public async Task<ActionResult<List<HardwareDto>>> GetAll()
        {
            try
            {
                var result = await _mediator.Send(new GetAllHardwaresQuery());
                return Ok(ResponseProvider.GetRespone(ResponseState.Success, result));
            }
            catch (Exception)
            {
                return Ok(ResponseProvider.GetRespone(ResponseState.Failed));
            }
        }

        // Get Hardware by ID
        [HttpGet("{id}")]
        public async Task<ActionResult<HardwareDto>> GetById(int id)
        {
            try
            {
                var result = await _mediator.Send(new GetHardwareByIdQuery(id));
                if (result == null)
                    return Ok(new Respone { State = ResponseState.Error, Message = "اطلاعاتی یافت نشد" });

                return Ok(ResponseProvider.GetRespone(ResponseState.Success, result));
            }
            catch (Exception)
            {
                return Ok(ResponseProvider.GetRespone(ResponseState.Failed));
            }
        }

        // Create a new Hardware
        [HttpPost("Create")]
        public async Task<ActionResult<int>> Create(CreateHardwareDto dto)
        {
            try
            {
                var id = await _mediator.Send(new CreateHardwareCommand(dto));
                return Ok(ResponseProvider.GetRespone(ResponseState.Success, id));
            }
            catch (Exception)
            {
                return Ok(ResponseProvider.GetRespone(ResponseState.Failed));
            }
        }

        // Update a Hardware
        [HttpPut("Update/{id}")]
        public async Task<ActionResult> Update(int id, UpdateHardwareDto dto)
        {
            try
            {
                if (id != dto.Id)
                    return Ok(ResponseProvider.GetRespone(ResponseState.Failed));

                var success = await _mediator.Send(new UpdateHardwareCommand(dto));
                return success
                    ? Ok(ResponseProvider.GetRespone(ResponseState.Success))
                    : Ok(ResponseProvider.GetRespone(ResponseState.Failed));
            }
            catch (Exception)
            {
                return Ok(ResponseProvider.GetRespone(ResponseState.Failed));
            }
        }

        // Delete a Hardware
        [HttpDelete("Delete/{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                var success = await _mediator.Send(new DeleteHardwareCommand(id));
                return success
                    ? Ok(ResponseProvider.GetRespone(ResponseState.Success))
                    : Ok(ResponseProvider.GetRespone(ResponseState.Failed));
            }
            catch (Exception)
            {
                return Ok(ResponseProvider.GetRespone(ResponseState.Failed));
            }
        }
        #endregion Models

        #region CartReaders

        [HttpGet("CartReaders")]
        public async Task<ActionResult<List<HardwareCartReaderDto>>> GetAllCartReaders()
        {
            try
            {
                var result = await _mediator.Send(new GetAllHardwareCartReadersQuery());
                return Ok(ResponseProvider.GetRespone(ResponseState.Success, result));
            }
            catch (Exception)
            {
                return Ok(ResponseProvider.GetRespone(ResponseState.Failed));
            }
        }


        [HttpGet("CartReader/{id}")]
        public async Task<ActionResult<HardwareCartReaderDto>> GetCartReaderById(int id)
        {
            try
            {
                var result = await _mediator.Send(new GetHardwareCartReaderByIdQuery(id));
                if (result == null)
                    return Ok(new Respone { State = ResponseState.Error, Message = "اطلاعاتی یافت نشد" });

                return Ok(ResponseProvider.GetRespone(ResponseState.Success, result));
            }
            catch (Exception)
            {
                return Ok(ResponseProvider.GetRespone(ResponseState.Failed));
            }
        }

        // Create a new Hardware
        [HttpPost("CreateCartReader")]
        public async Task<ActionResult<int>> CreateCartReader(CreateHardwareCartReaderDto dto)
        {
            try
            {
                var id = await _mediator.Send(new CreateHardwareCartReaderCommand(dto));
                return Ok(ResponseProvider.GetRespone(ResponseState.Success, id));
            }
            catch (Exception)
            {
                return Ok(ResponseProvider.GetRespone(ResponseState.Failed));
            }
        }

        // Update a Hardware
        [HttpPut("UpdateCartReader/{id}")]
        public async Task<ActionResult> UpdateCartReader(int id, UpdateHardwareCartReaderDto dto)
        {
            try
            {
                if (id != dto.id)
                    return Ok(ResponseProvider.GetRespone(ResponseState.Failed));

                var success = await _mediator.Send(new UpdateHardwareCartReaderCommand(dto));
                return success
                    ? Ok(ResponseProvider.GetRespone(ResponseState.Success))
                    : Ok(ResponseProvider.GetRespone(ResponseState.Failed));
            }
            catch (Exception)
            {
                return Ok(ResponseProvider.GetRespone(ResponseState.Failed));
            }
        }

        // Delete a Hardware
        [HttpDelete("DeleteCartReader/{id}")]
        public async Task<ActionResult> DeleteCartReader(int id)
        {
            try
            {
                var success = await _mediator.Send(new DeleteHardwareCartReaderCommand(id));
                return success
                    ? Ok(ResponseProvider.GetRespone(ResponseState.Success))
                    : Ok(ResponseProvider.GetRespone(ResponseState.Failed));
            }
            catch (Exception)
            {
                return Ok(ResponseProvider.GetRespone(ResponseState.Failed));
            }
        }

        #endregion CartReaders

        #region Connection

        [HttpGet("Connections")]
        public async Task<ActionResult<List<HardwareConnectionDto>>> GetAllConnections()
        {
            try
            {
                var result = await _mediator.Send(new GetAllHardwareConnectionsQuery());
                return Ok(ResponseProvider.GetRespone(ResponseState.Success, result));
            }
            catch (Exception)
            {
                return Ok(ResponseProvider.GetRespone(ResponseState.Failed));
            }
        }


        [HttpGet("Connection/{id}")]
        public async Task<ActionResult<HardwareConnectionDto>> GetConnectionById(int id)
        {
            try
            {
                var result = await _mediator.Send(new GetHardwareConnectionByIdQuery(id));
                if (result == null)
                    return Ok(new Respone { State = ResponseState.Error, Message = "اطلاعاتی یافت نشد" });

                return Ok(ResponseProvider.GetRespone(ResponseState.Success, result));
            }
            catch (Exception)
            {
                return Ok(ResponseProvider.GetRespone(ResponseState.Failed));
            }
        }

        // Create a new Hardware
        [HttpPost("CreateConnection")]
        public async Task<ActionResult<int>> CreateConnection(CreateHardwareConnectionDto dto)
        {
            try
            {
                var id = await _mediator.Send(new CreateHardwareConnectionCommand(dto));
                return Ok(ResponseProvider.GetRespone(ResponseState.Success, id));
            }
            catch (Exception)
            {
                return Ok(ResponseProvider.GetRespone(ResponseState.Failed));
            }
        }

        // Update a Hardware
        [HttpPut("UpdateConnection/{id}")]
        public async Task<ActionResult> UpdateConnection(int id, UpdateHardwareConnectionDto dto)
        {
            try
            {
                if (id != dto.Id)
                    return Ok(ResponseProvider.GetRespone(ResponseState.Failed));

                var success = await _mediator.Send(new UpdateHardwareConnectionCommand(dto));
                return success
                    ? Ok(ResponseProvider.GetRespone(ResponseState.Success))
                    : Ok(ResponseProvider.GetRespone(ResponseState.Failed));
            }
            catch (Exception)
            {
                return Ok(ResponseProvider.GetRespone(ResponseState.Failed));
            }
        }

        // Delete a Hardware
        [HttpDelete("DeleteConnection/{id}")]
        public async Task<ActionResult> DeleteConnection(int id)
        {
            try
            {
                var success = await _mediator.Send(new DeleteHardwareConnectionCommand(id));
                return success
                    ? Ok(ResponseProvider.GetRespone(ResponseState.Success))
                    : Ok(ResponseProvider.GetRespone(ResponseState.Failed));
            }
            catch (Exception)
            {
                return Ok(ResponseProvider.GetRespone(ResponseState.Failed));
            }
        }

        #endregion Connection

        #region Portal

        [HttpGet("Portals")]
        public async Task<ActionResult<List<HardwarePortalDto>>> GetAllPortals()
        {
            try
            {
                var result = await _mediator.Send(new GetAllHardwarePortalsQuery());
                return Ok(ResponseProvider.GetRespone(ResponseState.Success, result));
            }
            catch (Exception)
            {
                return Ok(ResponseProvider.GetRespone(ResponseState.Failed));
            }
        }


        [HttpGet("Portal/{id}")]
        public async Task<ActionResult<HardwarePortalDto>> GetPortalById(int id)
        {
            try
            {
                var result = await _mediator.Send(new GetHardwarePortalByIdQuery(id));
                if (result == null)
                    return Ok(new Respone { State = ResponseState.Error, Message = "اطلاعاتی یافت نشد" });

                return Ok(ResponseProvider.GetRespone(ResponseState.Success, result));
            }
            catch (Exception)
            {
                return Ok(ResponseProvider.GetRespone(ResponseState.Failed));
            }
        }

        // Create a new Hardware
        [HttpPost("CreatePortal")]
        public async Task<ActionResult<int>> CreatePortal(CreateHardwarePortalDto dto)
        {
            try
            {
                var id = await _mediator.Send(new CreateHardwarePortalCommand(dto));
                return Ok(ResponseProvider.GetRespone(ResponseState.Success, id));
            }
            catch (Exception)
            {
                return Ok(ResponseProvider.GetRespone(ResponseState.Failed));
            }
        }

        // Update a Hardware
        [HttpPut("UpdatePortal/{id}")]
        public async Task<ActionResult> UpdatePortal(int id, UpdateHardwarePortalDto dto)
        {
            try
            {
                if (id != dto.Id)
                    return Ok(ResponseProvider.GetRespone(ResponseState.Failed));

                var success = await _mediator.Send(new UpdateHardwarePortalCommand(dto));
                return success
                    ? Ok(ResponseProvider.GetRespone(ResponseState.Success))
                    : Ok(ResponseProvider.GetRespone(ResponseState.Failed));
            }
            catch (Exception)
            {
                return Ok(ResponseProvider.GetRespone(ResponseState.Failed));
            }
        }

        // Delete a Hardware
        [HttpDelete("DeletePortal/{id}")]
        public async Task<ActionResult> DeletePortal(int id)
        {
            try
            {
                var success = await _mediator.Send(new DeleteHardwarePortalCommand(id));
                return success
                    ? Ok(ResponseProvider.GetRespone(ResponseState.Success))
                    : Ok(ResponseProvider.GetRespone(ResponseState.Failed));
            }
            catch (Exception)
            {
                return Ok(ResponseProvider.GetRespone(ResponseState.Failed));
            }
        }

        #endregion Portal

        #region Change

        [HttpGet("Changes")]
        public async Task<ActionResult<List<HardwareChangeDto>>> GetAllChanges()
        {
            try
            {
                var result = await _mediator.Send(new GetAllHardwareChangesQuery());
                return Ok(ResponseProvider.GetRespone(ResponseState.Success, result));
            }
            catch (Exception)
            {
                return Ok(ResponseProvider.GetRespone(ResponseState.Failed));
            }
        }


        [HttpGet("Change/{id}")]
        public async Task<ActionResult<HardwareChangeDto>> GetChangeById(int id)
        {
            try
            {
                var result = await _mediator.Send(new GetHardwareChangeByIdQuery(id));
                if (result == null)
                    return Ok(new Respone { State = ResponseState.Error, Message = "اطلاعاتی یافت نشد" });

                return Ok(ResponseProvider.GetRespone(ResponseState.Success, result));
            }
            catch (Exception)
            {
                return Ok(ResponseProvider.GetRespone(ResponseState.Failed));
            }
        }

        // Create a new Hardware
        [HttpPost("CreateChange")]
        public async Task<ActionResult<int>> CreateChange(CreateHardwareChangeDto dto)
        {
            try
            {
                var id = await _mediator.Send(new CreateHardwareChangeCommand(dto));
                return Ok(ResponseProvider.GetRespone(ResponseState.Success, id));
            }
            catch (Exception)
            {
                return Ok(ResponseProvider.GetRespone(ResponseState.Failed));
            }
        }

        // Update a Hardware
        [HttpPut("UpdateChange/{id}")]
        public async Task<ActionResult> UpdateChange(int id, UpdateHardwareChangeDto dto)
        {
            try
            {
                if (id != dto.Id)
                    return Ok(ResponseProvider.GetRespone(ResponseState.Failed));

                var success = await _mediator.Send(new UpdateHardwareChangeCommand(dto));
                return success
                    ? Ok(ResponseProvider.GetRespone(ResponseState.Success))
                    : Ok(ResponseProvider.GetRespone(ResponseState.Failed));
            }
            catch (Exception)
            {
                return Ok(ResponseProvider.GetRespone(ResponseState.Failed));
            }
        }

        // Delete a Hardware
        [HttpDelete("DeleteChange/{id}")]
        public async Task<ActionResult> DeleteChange(int id)
        {
            try
            {
                var success = await _mediator.Send(new DeleteHardwareChangeCommand(id));
                return success
                    ? Ok(ResponseProvider.GetRespone(ResponseState.Success))
                    : Ok(ResponseProvider.GetRespone(ResponseState.Failed));
            }
            catch (Exception)
            {
                return Ok(ResponseProvider.GetRespone(ResponseState.Failed));
            }
        }

        #endregion Change

        #region Repair

        [HttpGet("Repairs")]
        public async Task<ActionResult<List<HardwareRepairDto>>> GetAllRepairs()
        {
            try
            {
                var result = await _mediator.Send(new GetAllHardwareRepairsQuery());
                return Ok(ResponseProvider.GetRespone(ResponseState.Success, result));
            }
            catch (Exception)
            {
                return Ok(ResponseProvider.GetRespone(ResponseState.Failed));
            }
        }


        [HttpGet("Repair/{id}")]
        public async Task<ActionResult<HardwareRepairDto>> GetRepairById(int id)
        {
            try
            {
                var result = await _mediator.Send(new GetHardwareRepairByIdQuery(id));
                if (result == null)
                    return Ok(new Respone { State = ResponseState.Error, Message = "اطلاعاتی یافت نشد" });

                return Ok(ResponseProvider.GetRespone(ResponseState.Success, result));
            }
            catch (Exception)
            {
                return Ok(ResponseProvider.GetRespone(ResponseState.Failed));
            }
        }

        // Create a new Hardware
        [HttpPost("CreateRepair")]
        public async Task<ActionResult<int>> CreateRepair(CreateHardwareRepairDto dto)
        {
            try
            {
                var id = await _mediator.Send(new CreateHardwareRepairCommand(dto));
                return Ok(ResponseProvider.GetRespone(ResponseState.Success, id));
            }
            catch (Exception)
            {
                return Ok(ResponseProvider.GetRespone(ResponseState.Failed));
            }
        }

        // Update a Hardware
        [HttpPut("UpdateRepair/{id}")]
        public async Task<ActionResult> UpdateRepair(int id, UpdateHardwareRepairDto dto)
        {
            try
            {
                if (id != dto.Id)
                    return Ok(ResponseProvider.GetRespone(ResponseState.Failed));

                var success = await _mediator.Send(new UpdateHardwareRepairCommand(dto));
                return success
                    ? Ok(ResponseProvider.GetRespone(ResponseState.Success))
                    : Ok(ResponseProvider.GetRespone(ResponseState.Failed));
            }
            catch (Exception)
            {
                return Ok(ResponseProvider.GetRespone(ResponseState.Failed));
            }
        }

        // Delete a Hardware
        [HttpDelete("DeleteRepair/{id}")]
        public async Task<ActionResult> DeleteRepair(int id)
        {
            try
            {
                var success = await _mediator.Send(new DeleteHardwareRepairCommand(id));
                return success
                    ? Ok(ResponseProvider.GetRespone(ResponseState.Success))
                    : Ok(ResponseProvider.GetRespone(ResponseState.Failed));
            }
            catch (Exception)
            {
                return Ok(ResponseProvider.GetRespone(ResponseState.Failed));
            }
        }

        #endregion Repair

        #region Replace

        [HttpGet("Replaces")]
        public async Task<ActionResult<List<HardwareReplaceDto>>> GetAllReplaces()
        {
            try
            {
                var result = await _mediator.Send(new GetAllHardwareReplacesQuery());
                return Ok(ResponseProvider.GetRespone(ResponseState.Success, result));
            }
            catch (Exception)
            {
                return Ok(ResponseProvider.GetRespone(ResponseState.Failed));
            }
        }


        [HttpGet("Replace/{id}")]
        public async Task<ActionResult<HardwareReplaceDto>> GetReplaceById(int id)
        {
            try
            {
                var result = await _mediator.Send(new GetHardwareReplaceByIdQuery(id));
                if (result == null)
                    return Ok(new Respone { State = ResponseState.Error, Message = "اطلاعاتی یافت نشد" });

                return Ok(ResponseProvider.GetRespone(ResponseState.Success, result));
            }
            catch (Exception)
            {
                return Ok(ResponseProvider.GetRespone(ResponseState.Failed));
            }
        }

        // Create a new Hardware
        [HttpPost("CreateReplace")]
        public async Task<ActionResult<int>> CreateReplace(CreateHardwareReplaceDto dto)
        {
            try
            {
                var id = await _mediator.Send(new CreateHardwareReplaceCommand(dto));
                return Ok(ResponseProvider.GetRespone(ResponseState.Success, id));
            }
            catch (Exception)
            {
                return Ok(ResponseProvider.GetRespone(ResponseState.Failed));
            }
        }

        // Update a Hardware
        [HttpPut("UpdateReplace/{id}")]
        public async Task<ActionResult> UpdateReplace(int id, UpdateHardwareReplaceDto dto)
        {
            try
            {
                if (id != dto.Id)
                    return Ok(ResponseProvider.GetRespone(ResponseState.Failed));

                var success = await _mediator.Send(new UpdateHardwareReplaceCommand(dto));
                return success
                    ? Ok(ResponseProvider.GetRespone(ResponseState.Success))
                    : Ok(ResponseProvider.GetRespone(ResponseState.Failed));
            }
            catch (Exception)
            {
                return Ok(ResponseProvider.GetRespone(ResponseState.Failed));
            }
        }

        // Delete a Hardware
        [HttpDelete("DeleteReplace/{id}")]
        public async Task<ActionResult> DeleteReplace(int id)
        {
            try
            {
                var success = await _mediator.Send(new DeleteHardwareReplaceCommand(id));
                return success
                    ? Ok(ResponseProvider.GetRespone(ResponseState.Success))
                    : Ok(ResponseProvider.GetRespone(ResponseState.Failed));
            }
            catch (Exception)
            {
                return Ok(ResponseProvider.GetRespone(ResponseState.Failed));
            }
        }

        #endregion Replace
    }
}
