using LexiBox.API.Entities;
using MediatR;

namespace LexiBox.API.Features.GetVocabularies;

public sealed record GetVocabulariesQuery(int? State, int? Category) : IRequest<Result<List<Vocabulary>>>
{
}
