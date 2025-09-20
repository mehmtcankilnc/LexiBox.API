using static LexiBox.API.Shared.Enums;

namespace LexiBox.API.Features.CreateVocabulary;

public class CreateVocabularyRequest
{
    public string Word { get; set; } = string.Empty;
    public string Meaning { get; set; } = string.Empty;
    public WordCategory Category { get; set; }
}
