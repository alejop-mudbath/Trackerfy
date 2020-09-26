namespace Trackerfy.Domain.Entities
{
    public class IssueType
    {
        public IssueType(string description)
        {
            Description = description;
        }

        public int Id { get; set; }
        public string Description { get; private set; }
    }
}