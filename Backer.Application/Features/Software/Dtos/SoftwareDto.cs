using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// src/Backer.Application/Features/Software/Dtos/SoftwareDto.cs
namespace Backer.Application.Features.Software.Dtos;

public record SoftwareDto(
    int Id,
    string SoftwareName,
    DateTime? CreateDate,
    string? Description,
    bool IsActive);

public record CreateSoftwareDto(
    string SoftwareName,
    DateTime? CreateDate,
    string? Description,
    bool IsActive);

public record UpdateSoftwareDto(
    int Id,
    string SoftwareName,
    DateTime? CreateDate,
    string? Description,
    bool IsActive);
