namespace UndoAssessment.Models
{
    public class Item : IEntity
    {
        public string Id { get; set; }
        public string Text { get; set; }
        public string Description { get; set; }
    }
}
