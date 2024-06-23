namespace Quizz.Domain.Core.Dto
{
    public class LevelRequest
    {
    
        public long? Id { get; set; }
        public string Content { get; set; }

        public int AdminId { get; set; }
        public bool IsActive { get; set; }
    }
}
