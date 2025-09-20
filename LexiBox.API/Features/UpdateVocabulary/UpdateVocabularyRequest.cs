using static LexiBox.API.Shared.Enums;

namespace LexiBox.API.Features.UpdateVocabulary;

public class UpdateVocabularyRequest
{
    public string Word { get; set; } = string.Empty;
    public string Meaning { get; set; } = string.Empty;
    public WordCategory Category { get; set; }
    public LearningStates State { get; set; }
}
