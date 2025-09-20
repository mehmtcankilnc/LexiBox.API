using LexiBox.API.Entities;

namespace LexiBox.API.Entities
{
    public sealed record Error (bool IsSuccess, string Code, string Description)
    {
        public static readonly Error None = new(true, string.Empty, string.Empty);
    }
}

public static class VocabularyErrors
{
    public static readonly Error AlreadyExists = new(
        false, "Vocabularies.AlreadyExists", "Already exists!");
    public static readonly Error NotFound = new(
        false, "Vocabulary.NotFound", "Not found!");
}

public static class CommonErrors
{
    public static readonly Error InvalidEnum = new(
        false, "Enums.InvalidEnum", "InvalidEnum");
}
