using AutoMapper;
using Backer.Core.Entities;
using Backer.Application.Features.Software.Dtos;
using Backer.Application.Features.Hardwares.Dtos;
using Backer.Application.Features.DifficultGroups.Dtos;
using Backer.Application.Features.Difficults.Dtos;
using Backer.Application.Features.Solutions.Dtos;
using Backer.Application.Features.SolutionAssignToDifficult.Dtos;
using Backer.Application.Features.JobTitles.Dtos;
using Backer.Application.Features.AskPolls.Dtos;
using Backer.Application.Features.AnswerPolls.Dtos;
using Backer.Application.Features.PollSamples.Dtos;
using Backer.Application.Features.HardwareCartReaders.Dtos;
using Backer.Application.Features.HardwarePortals.Dtos;
using Backer.Application.Features.HardwareConnections.Dtos;
using Backer.Application.Features.HardwareRepairs.Dtos;
using Backer.Application.Features.HardwareChanges.Dtos;
using Backer.Application.Features.HardwareReplaces.Dtos;
using Backer.Application.Features.ContractPackages.Dtos;
using Backer.Application.Features.ContractTypes.Dtos;
using Backer.Application.Features.DeviceContractSamples.Dtos;
using Backer.Application.Features.DeviceContractSamplePrices.Dtos;
using Backer.Application.Features.Regions.Dtos;
using Backer.Application.Features.AccessGroups.Dtos;
using Backer.Application.Features.Users.Dtos;
using Backer.Application.Features.JobsAccess.Dtos;
using Backer.Application.Features.SoftwareVersions.Dtos;
using Backer.Application.Features.Telephones.Dtos;

namespace Backer.Application.Common.Mappings;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        #region General

        CreateMap<Region, RegionDto>()
                .ForMember(dest => dest.ParentTitle,
                 opt => opt.MapFrom(src => src.Parent != null ? src.Parent.Title : null));

        #endregion General

        #region Regions

        CreateMap<Region, RegionDto>();
        CreateMap<CreateRegionDto, Region>();
        CreateMap<UpdateRegionDto, Region>().ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));

        #endregion Regions

        #region Software

        CreateMap<Software, SoftwareDto>();


        CreateMap<SoftwareVersion, SoftwareVersionDto>()
           .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
           .ForMember(dest => dest.SoftwareId, opt => opt.MapFrom(src => src.SoftwareId))
           .ForMember(dest => dest.Version, opt => opt.MapFrom(src => src.Version))
           .ForMember(dest => dest.SoftwareName, opt => opt.MapFrom(src => src.Software.SoftwareName))
           .ForMember(dest => dest.CreateDate, opt => opt.MapFrom(src => src.CreateDate));

        #endregion Software

        #region Hardware

        CreateMap<Hardware, HardwareDto>();
        CreateMap<CreateHardwareDto, Hardware>();

        CreateMap<HardwareCartReader, HardwareCartReaderDto>();
        CreateMap<CreateHardwareCartReaderDto, HardwareCartReader>();

        CreateMap<HardwarePortal, HardwarePortalDto>();
        CreateMap<CreateHardwarePortalDto, HardwarePortal>();

        CreateMap<HardwareConnection, HardwareConnectionDto>();
        CreateMap<CreateHardwareConnectionDto, HardwareConnection>();

        CreateMap<HardwareRepair, HardwareRepairDto>();
        CreateMap<CreateHardwareRepairDto, HardwareRepair>();

        CreateMap<HardwareChange, HardwareChangeDto>();
        CreateMap<CreateHardwareChangeDto, HardwareChange>();

        CreateMap<HardwareReplace, HardwareReplaceDto>();
        CreateMap<CreateHardwareReplaceDto, HardwareReplace>();

        #endregion Hardware

        #region DifficultGroup

        CreateMap<DifficultGroup, DifficultGroupDto>();
        CreateMap<CreateDifficultGroupDto, DifficultGroup>();

        #endregion DifficultGroup

        #region Telephone
        CreateMap<Telephone, TelephoneDto>();
        CreateMap<TelephoneDto, Telephone>();
        #endregion Telephone

        #region Difficults

        // src/Backer.Application/Common/Mappings/MappingProfile.cs
        CreateMap<Difficult, DifficultDto>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.DifficultGroupId, opt => opt.MapFrom(src => src.DifficultGroupId))
            .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
            .ForMember(dest => dest.GroupTitle, opt => opt.MapFrom(src => src.DifficultGroup.Title));

        #endregion Difficults

        #region Solutions

        CreateMap<Solution, SolutionDto>();
        CreateMap<CreateSolutionDto, Solution>();

        #endregion Solutions

        #region SolutionAssignToDifficult

        CreateMap<SolutionAssignToDifficult, SolutionAssignToDifficultDto>()
         .ForMember(dest => dest.DifficultTitle, opt => opt.MapFrom(src => src.Difficult.Description))
         .ForMember(dest => dest.SolutionTitle,
          opt => opt.MapFrom(src => src.Solution.Title));

        #endregion SolutionAssignToDifficult

        #region JobTitle

        CreateMap<JobTitle, JobTitleDto>();
        CreateMap<CreateJobTitleDto, JobTitle>();

        #endregion JobTitle

        #region Poll

        CreateMap<AskPoll, AskPollDto>();
        CreateMap<CreateAskPollDto, AskPoll>();

        CreateMap<AnswerPoll, AnswerPollDto>();
        CreateMap<CreateAnswerPollDto, AnswerPoll>();

        CreateMap<PollSample, PollSampleDto>().ForMember(dest => dest.JobTitleName, opt => opt.MapFrom(src => src.JobTitle.Title));

        #endregion Poll

        #region Contracts

        CreateMap<ContractPackage, ContractPackageDto>();
        CreateMap<CreateContractPackageDto, ContractPackage>();

        CreateMap<ContractType, ContractTypeDto>();
        CreateMap<CreateContractTypeDto, ContractType>();

        CreateMap<DeviceContractSample, DeviceContractSampleDto>();
        CreateMap<CreateDeviceContractSampleDto, DeviceContractSample>();

        CreateMap<DeviceContractSamplePrice, DeviceContractSamplePriceDto>()
            .ForMember(dest => dest.DeviceContractSampleTitle,
            opt => opt.MapFrom(src => src.DeviceContractSample.Title));

        #endregion Contracts

        #region Users

        CreateMap<AccessGroup, AccessGroupDto>();
        CreateMap<CreateAccessGroupDto, AccessGroup>();

        CreateMap<User, UserDto>();
        CreateMap<CreateUserDto, User>();

        #endregion Users

        #region JobAccess

        CreateMap<JobsAccess, JobsAccessDto>();   // Convert Entity to DTO
        CreateMap<CreateJobsAccessDto, JobsAccess>(); // Convert DTO to Entity

        #endregion JobAccess

    }
}