using FluentValidation;
using static LexiBox.API.Shared.Enums;

namespace LexiBox.API.Features.UpdateVocabulary;

public class UpdateVocabularyRequestValidator : AbstractValidator<UpdateVocabularyRequest>
{
    public UpdateVocabularyRequestValidator()
    {
        RuleFor(voc => voc.Word)
            .NotEmpty().WithMessage("Word must not be empty!");
        RuleFor(voc => voc.Meaning)
            .NotEmpty().WithMessage("Meaning must not be empty!");
        RuleFor(voc => voc.Category)
            .IsInEnum().NotEqual(WordCategory.Unknown).WithMessage("Category must not be empty!");
        RuleFor(voc => voc.State)
            .IsInEnum().WithMessage("Learning state is not valid!");
    }
}
