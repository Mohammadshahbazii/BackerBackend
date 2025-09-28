using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backer.Application.Features.Telephones.Dtos;

public record TelephoneDto
{
    public TelephoneDto() { }

    public TelephoneDto(int id, string tellNumber, string? description)
    {
        Id = id;
        TellNumber = tellNumber;
        Description = description;
    }

    public int Id { get; init; }
    public string TellNumber { get; init; }
    public string? Description { get; init; }
}


public record CreateTelephoneDto(
    string TellNumber,
    string? Description);

public record UpdateTelephoneDto(
    int Id,
    string TellNumber,
    string? Description);
