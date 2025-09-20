using LexiBox.API.Database;
using LexiBox.API.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using static LexiBox.API.Shared.Enums;

namespace LexiBox.API.Features.GetVocabularies;

public class GetVocabulariesQueryHandler(AppDbContext context) : IRequestHandler<GetVocabulariesQuery, Result<List<Vocabulary>>>
{
    private readonly AppDbContext _context = context;

    public async Task<Result<List<Vocabulary>>> Handle(GetVocabulariesQuery request, CancellationToken cancellationToken)
    {
        IQueryable<Vocabulary> q = _context.Vocabularies;

        if (request.State.HasValue)
        {
            var s = request.State.Value;
            if (!Enum.IsDefined(typeof(LearningStates), s))
                return Result<List<Vocabulary>>.Failure<List<Vocabulary>>(CommonErrors.InvalidEnum);

            q = q.Where(v => (int)v.State == s);
        }

        if (request.Category.HasValue)
        {
            var c = request.Category.Value;
            if (!Enum.IsDefined(typeof(WordCategory), c))
                return Result<List<Vocabulary>>.Failure<List<Vocabulary>>(CommonErrors.InvalidEnum);

            q = q.Where(v => (int)v.Category == c);
        }

        var vocList = await q.OrderBy(v => v.CreatedAt).ToListAsync(cancellationToken);
        return Result<List<Vocabulary>>.Success(vocList);
    }
}
