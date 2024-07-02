namespace Quizz.Domain.Core.Entities
{
    public class Level
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public bool IsActive { get; set; }
        public int AdminId { get; set; }
    }
}
