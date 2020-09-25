namespace Trackerfy.Application
{
    public class CreateIssueCommand
    {
        public CreateIssueCommand(string summary, int issueTypeId)
        {
            Summary = summary;
            IssueTypeId = issueTypeId;
        }
        public string Summary { get; }
        public int IssueTypeId { get; }
    }
}