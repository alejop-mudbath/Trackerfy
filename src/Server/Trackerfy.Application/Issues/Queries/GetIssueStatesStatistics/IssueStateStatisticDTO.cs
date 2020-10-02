namespace Trackerfy.Application.Issues.Queries.GetIssueStatesStatistics
{
    public class IssueStateStatisticDTO
    {
        public int count { get; set; }
        public int stateId { get; set; }
        public string stateDescription { get; set; }
    }
}