using LexiBox.API.Entities;
using MediatR;

namespace LexiBox.API.Features.GetVocabularyById;

public sealed record GetVocabularyByIdQuery(Guid Id) : IRequest<Result<Vocabulary>>
{
}
