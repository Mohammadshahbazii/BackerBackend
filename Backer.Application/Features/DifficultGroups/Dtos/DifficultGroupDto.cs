using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backer.Application.Features.DifficultGroups.Dtos;

public record DifficultGroupDto(
    int Id,
    string Title);

public record CreateDifficultGroupDto(
    string Title);

public record UpdateDifficultGroupDto(int Id, string Title);

