namespace Backer.Application.Features.SolutionAssignToDifficult.Dtos;

public record SolutionAssignToDifficultDto(
    int Id,
    int DifficultId,
    int SolutionId,
    string DifficultTitle,  // Included from Difficult
    string SolutionTitle); // Included from Solution

public record AssignSolutionToDifficultDto(
    int DifficultId,
    int SolutionId);