namespace UndoAssessment.Models
{
    public class User : IEntity
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public uint Age { get; set; }
    }
}
