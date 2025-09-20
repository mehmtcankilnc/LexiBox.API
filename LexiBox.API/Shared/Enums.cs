namespace LexiBox.API.Shared;

public class Enums
{
    public enum WordCategory
    {
        Unknown = 0,
        Noun = 1,
        Verb = 2,
        Adjective = 3,
        Adverb = 4
    }

    public enum LearningStates
    {
        Untested = 0,
        Unlearned = 1,
        Learned = 2,
    }
}
