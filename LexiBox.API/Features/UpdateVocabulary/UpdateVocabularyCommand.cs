using LexiBox.API.Entities;
using MediatR;
using static LexiBox.API.Shared.Enums;

namespace LexiBox.API.Features.UpdateVocabulary;

public sealed record UpdateVocabularyCommand
    (Guid Id, string Word, string Meaning, WordCategory Category, LearningStates State) : IRequest<Result<Vocabulary>>
{
}
