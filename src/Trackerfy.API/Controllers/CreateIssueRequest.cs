namespace Trackerfy.API.Controllers
{
    public class CreateIssueRequest
    {
        public string Summary { get; set; }
        public int IssueTypeId { get; set; }
    }
}