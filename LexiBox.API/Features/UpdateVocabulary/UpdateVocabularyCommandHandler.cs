using LexiBox.API.Database;
using LexiBox.API.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace LexiBox.API.Features.UpdateVocabulary
{
    public class UpdateVocabularyCommandHandler
        (AppDbContext context) : IRequestHandler<UpdateVocabularyCommand, Result<Vocabulary>>
    {
        private readonly AppDbContext _context = context;

        public async Task<Result<Vocabulary>> Handle(UpdateVocabularyCommand command, CancellationToken cancellationToken)
        {
            var voc = await _context.Vocabularies
                .Where(v => v.Id == command.Id).FirstOrDefaultAsync(cancellationToken);

            if (voc == null)
            {
                return Result<Vocabulary>.Failure<Vocabulary>(VocabularyErrors.NotFound);
            }

            voc.Word = command.Word;
            voc.Meaning = command.Meaning;
            voc.Category = command.Category;
            voc.State = command.State;
            voc.UpdatedAt = DateTime.UtcNow;

            await _context.SaveChangesAsync(cancellationToken);

            return Result<Vocabulary>.Success<Vocabulary>(voc);
        }
    }
}
