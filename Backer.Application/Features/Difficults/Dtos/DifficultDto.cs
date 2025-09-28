using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backer.Application.Features.Difficults.Dtos;

public record DifficultDto
{
    // Parameterless constructor required by AutoMapper
    public DifficultDto() { }

    // Primary constructor
    public DifficultDto(
        int id,
        int difficultGroupId,
        string description,
        string groupTitle)
    {
        Id = id;
        DifficultGroupId = difficultGroupId;
        Description = description;
        GroupTitle = groupTitle;
    }

    public int Id { get; init; }
    public int DifficultGroupId { get; init; }
    public string Description { get; init; }
    public string GroupTitle { get; init; }
}

// CreateDifficultDto.cs
public record CreateDifficultDto(int DifficultGroupId, string Description);

// UpdateDifficultDto.cs
public record UpdateDifficultDto(int Id, int DifficultGroupId, string Description);