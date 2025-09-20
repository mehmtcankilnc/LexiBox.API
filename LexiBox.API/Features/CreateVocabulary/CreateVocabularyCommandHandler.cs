using LexiBox.API.Database;
using LexiBox.API.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace LexiBox.API.Features.CreateVocabulary;

public class CreateVocabularyCommandHandler(AppDbContext context) : IRequestHandler<CreateVocabularyCommand, Result>
{
    private readonly AppDbContext _context = context;
    public async Task<Result> Handle(CreateVocabularyCommand command, CancellationToken cancellationToken)
    {
        var vocabularyAlreadyExists = await _context.Vocabularies
            .Where(v => v.Word == command.Word)
            .AnyAsync(cancellationToken);

        if (vocabularyAlreadyExists)
        {
            return Result.Failure(VocabularyErrors.AlreadyExists);
        }

        var vocabularyId = new Guid();
        var vocabulary = CreateVocabulary(command, vocabularyId);

        await _context.Vocabularies.AddAsync(vocabulary, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }

    private static Vocabulary CreateVocabulary(CreateVocabularyCommand command, Guid vocabularyId)
    {
        return new Vocabulary
        {
            Id = vocabularyId,
            Category = command.Category,
            Word = command.Word,
            Meaning = command.Meaning,
            State = Shared.Enums.LearningStates.Untested,
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow,
        };
    }
}
