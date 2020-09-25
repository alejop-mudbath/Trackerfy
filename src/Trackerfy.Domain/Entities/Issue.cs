
using System;

namespace Trackerfy.Domain.Entities
{
    public class Issue
    {
        private Issue()
        {
        }

        public Issue(string summary, int issueTypeId)
        {
            Summary = summary;
            IssueTypeId = issueTypeId;
        }

        public int Id { get; private set; }

        public string Summary { get; private set; }

        public int IssueTypeId { get; private set; }

        public virtual IssueType IssueType { get; private set; }

        public int IssueStateId { get; private set; }

        public virtual IssueState IssueState { get; private set; }

        public string CreatedBy { get; private set; }

        public DateTime Created { get; private set; }
    }
}