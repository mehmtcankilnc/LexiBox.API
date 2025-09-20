using FluentValidation;
using static LexiBox.API.Shared.Enums;

namespace LexiBox.API.Features.CreateVocabulary;

public class CreateVocabularyRequestValidator : AbstractValidator<CreateVocabularyRequest>
{
    public CreateVocabularyRequestValidator()
    {
        RuleFor(voc => voc.Word)
            .NotEmpty().WithMessage("Word must not be empty!");
        RuleFor(voc => voc.Meaning)
            .NotEmpty().WithMessage("Meaning must not be empty!");
        RuleFor(voc => voc.Category)
            .IsInEnum().NotEqual(WordCategory.Unknown).WithMessage("Category must not be empty!");
    }
}
