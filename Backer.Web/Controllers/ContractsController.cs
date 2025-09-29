using Backer.Application.Features.ContractPackages.Dtos;
using Backer.Application.Features.ContractPackages.Queries;
using Backer.Application.Features.ContractTypes.Dtos;
using Backer.Application.Features.ContractTypes.Queries;
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
    public class ContractsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ContractsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        #region Packages
        [HttpGet("GetAllPackages")]
        public async Task<ActionResult<List<ContractPackageDto>>> GetAllPackages()
        {
            try
            {
                var result = await _mediator.Send(new GetAllContractPackagesQuery());
                return Ok(ResponseProvider.GetRespone(ResponseState.Success, result));
            }
            catch (Exception)
            {
                return Ok(ResponseProvider.GetRespone(ResponseState.Failed));
            }
        }

        // Get ContractPackage by ID
        [HttpGet("GetPackageByID/{id}")]
        public async Task<ActionResult<ContractPackageDto>> GetPackageByID(int id)
        {
            try
            {
                var result = await _mediator.Send(new GetContractPackageByIdQuery(id));
                if (result == null)
                    return Ok(new Respone { State = ResponseState.Error, Message = "اطلاعاتی یافت نشد" });

                return Ok(ResponseProvider.GetRespone(ResponseState.Success, result));
            }
            catch (Exception)
            {
                return Ok(ResponseProvider.GetRespone(ResponseState.Failed));
            }
        }

        // Create a new ContractPackage
        [HttpPost("CreatePackage")]
        public async Task<ActionResult<int>> CreatePackage(CreateContractPackageDto dto)
        {
            try
            {
                var id = await _mediator.Send(new CreateContractPackageCommand(dto));
                return Ok(ResponseProvider.GetRespone(ResponseState.Success, id));
            }
            catch (Exception)
            {
                return Ok(ResponseProvider.GetRespone(ResponseState.Failed));
            }
        }

        // Update a ContractPackage
        [HttpPost("UpdatePackage/{id}")]
        public async Task<ActionResult> UpdatePackage(int id, UpdateContractPackageDto dto)
        {
            try
            {
                if (id != dto.Id)
                    return Ok(ResponseProvider.GetRespone(ResponseState.Failed));

                var success = await _mediator.Send(new UpdateContractPackageCommand(dto));
                return success
                    ? Ok(ResponseProvider.GetRespone(ResponseState.Success))
                    : Ok(ResponseProvider.GetRespone(ResponseState.Failed));
            }
            catch (Exception)
            {
                return Ok(ResponseProvider.GetRespone(ResponseState.Failed));
            }
        }

        // Delete a ContractPackage
        [HttpPost("DeletePackage/{id}")]
        public async Task<ActionResult> DeletePackage(int id)
        {
            try
            {
                var success = await _mediator.Send(new DeleteContractPackageCommand(id));
                return success
                    ? Ok(ResponseProvider.GetRespone(ResponseState.Success))
                    : Ok(ResponseProvider.GetRespone(ResponseState.Failed));
            }
            catch (Exception)
            {
                return Ok(ResponseProvider.GetRespone(ResponseState.Failed));
            }
        }
        #endregion Packages

        #region Types
        [HttpGet("GetAllTypes")]
        public async Task<ActionResult<List<ContractTypeDto>>> GetAllTypes()
        {
            try
            {
                var result = await _mediator.Send(new GetAllContractTypesQuery());
                return Ok(ResponseProvider.GetRespone(ResponseState.Success, result));
            }
            catch (Exception)
            {
                return Ok(ResponseProvider.GetRespone(ResponseState.Failed));
            }
        }

        // Get ContractType by ID
        [HttpGet("GetTypeByID/{id}")]
        public async Task<ActionResult<ContractTypeDto>> GetTypeByID(int id)
        {
            try
            {
                var result = await _mediator.Send(new GetContractTypeByIdQuery(id));
                if (result == null)
                    return Ok(new Respone { State = ResponseState.Error, Message = "اطلاعاتی یافت نشد" });

                return Ok(ResponseProvider.GetRespone(ResponseState.Success, result));
            }
            catch (Exception)
            {
                return Ok(ResponseProvider.GetRespone(ResponseState.Failed));
            }
        }

        // Create a new ContractType
        [HttpPost("CreateType")]
        public async Task<ActionResult<int>> CreateType(CreateContractTypeDto dto)
        {
            try
            {
                var id = await _mediator.Send(new CreateContractTypeCommand(dto));
                return Ok(ResponseProvider.GetRespone(ResponseState.Success, id));
            }
            catch (Exception)
            {
                return Ok(ResponseProvider.GetRespone(ResponseState.Failed));
            }
        }

        // Update a ContractType
        [HttpPost("UpdateType/{id}")]
        public async Task<ActionResult> UpdateType(int id, UpdateContractTypeDto dto)
        {
            try
            {
                if (id != dto.Id)
                    return Ok(ResponseProvider.GetRespone(ResponseState.Failed));

                var success = await _mediator.Send(new UpdateContractTypeCommand(dto));
                return success
                    ? Ok(ResponseProvider.GetRespone(ResponseState.Success))
                    : Ok(ResponseProvider.GetRespone(ResponseState.Failed));
            }
            catch (Exception)
            {
                return Ok(ResponseProvider.GetRespone(ResponseState.Failed));
            }
        }

        // Delete a ContractType
        [HttpPost("DeleteType/{id}")]
        public async Task<ActionResult> DeleteType(int id)
        {
            try
            {
                var success = await _mediator.Send(new DeleteContractTypeCommand(id));
                return success
                    ? Ok(ResponseProvider.GetRespone(ResponseState.Success))
                    : Ok(ResponseProvider.GetRespone(ResponseState.Failed));
            }
            catch (Exception)
            {
                return Ok(ResponseProvider.GetRespone(ResponseState.Failed));
            }
        }
        #endregion Types
    }
}
