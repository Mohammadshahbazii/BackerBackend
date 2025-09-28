using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backer.Application.Features.Solutions.Dtos;

public record SolutionDto
{
    public SolutionDto() { } 

    public SolutionDto(int id, string title, string? description)
    {
        Id = id;
        Title = title;
        Description = description;
    }

    public int Id { get; init; }
    public string Title { get; init; }
    public string? Description { get; init; }
}

public record CreateSolutionDto(
    string Title,
    string? Description);

public record UpdateSolutionDto(
    int Id,
    string Title,
    string? Description);