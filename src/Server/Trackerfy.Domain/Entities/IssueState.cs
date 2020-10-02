namespace Trackerfy.Domain.Entities
{
    public class IssueState
    {
        public IssueState(string description)
        {
            Description = description;
        }
        public int Id { get; set; }
        public string Description { get; private set; }
    }
}