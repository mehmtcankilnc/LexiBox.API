using static LexiBox.API.Shared.Enums;

namespace LexiBox.API.Entities
{
    public class Vocabulary
    {
        public Guid Id { get; set; }
        public string Word { get; set; } = string.Empty;
        public string Meaning { get; set; } = string.Empty;
        public LearningStates State { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public WordCategory Category { get; set; }
    }
}
