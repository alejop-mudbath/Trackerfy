using System;

namespace Trackerfy.Application.Queries.GetAllIssues
{
    public class IssueDTO
    {
        public int Id { get; set; }

        public string Summary { get; set; }

        public int IssueTypeId { get; set; }

        public string IssueTypeDescription { get; set; }

        public int IssueStateId { get; set; }

        public string IssueStateDescription { get; set; }

        public string CreatedBy { get; set; }

        public DateTime Created { get; set; }
    }
}