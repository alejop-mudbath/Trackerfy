
using System;

namespace Trackerfy.Domain.Entities
{
    public class Issue: AuditableEntity
    {
        private Issue()
        {
        }

        public Issue(string summary, int issueTypeId, string userId, IssueState defaultState)
        {
            Summary = summary;
            IssueTypeId = issueTypeId;
            CreatedBy = userId;
            Created = SystemClock.Now;
            IssueState = defaultState;
        }

        public int Id { get; private set; }

        public string Summary { get; private set; }

        public int IssueTypeId { get; private set; }

        public virtual IssueType IssueType { get; private set; }

        public int IssueStateId { get; private set; }

        public virtual IssueState IssueState { get; private set; }

        public string Assignee { get; private set; }

        public void AssignAssignee(string requestAssigneeUserId)
        {
            Assignee = requestAssigneeUserId;
        }

        public void UpdateState(in int issueStateId)
        {
            IssueStateId = issueStateId;
        }
    }
}