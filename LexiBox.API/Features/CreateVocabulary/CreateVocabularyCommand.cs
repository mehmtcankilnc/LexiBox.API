using LexiBox.API.Entities;
using MediatR;
using static LexiBox.API.Shared.Enums;

namespace LexiBox.API.Features.CreateVocabulary;

public sealed record CreateVocabularyCommand
    (string Word, string Meaning, WordCategory Category) : IRequest<Result>
{
}
