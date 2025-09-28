using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backer.Application.Features.Hardwares.Dtos;

public record HardwareDto(
    int Id,
    string ModelName,
    bool IsActive);

public record CreateHardwareDto(
    string ModelName,
    bool IsActive);

public record UpdateHardwareDto(
    int Id,
    string ModelName,
    bool IsActive);