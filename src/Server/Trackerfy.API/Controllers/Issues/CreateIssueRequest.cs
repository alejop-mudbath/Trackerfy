namespace Trackerfy.API.Controllers.Issues
{
    public class CreateIssueRequest
    {
        public string Summary { get; set; }
        public int IssueTypeId { get; set; }
    }
}