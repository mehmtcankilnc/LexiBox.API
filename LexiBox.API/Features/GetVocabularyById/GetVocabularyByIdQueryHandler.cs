using LexiBox.API.Database;
using LexiBox.API.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace LexiBox.API.Features.GetVocabularyById;

public class GetVocabularyByIdQueryHandler
    (AppDbContext context) : IRequestHandler<GetVocabularyByIdQuery, Result<Vocabulary>>
{
    private readonly AppDbContext _context = context;

    public async Task<Result<Vocabulary>> Handle(GetVocabularyByIdQuery request, CancellationToken cancellationToken)
    {
        var voc = await _context.Vocabularies
            .Where(v => v.Id == request.Id)
            .FirstOrDefaultAsync(cancellationToken);

        if (voc == null)
        {
            return Result<Vocabulary>.Failure<Vocabulary>(VocabularyErrors.NotFound);
        }

        return Result.Success(voc);
    }
}
