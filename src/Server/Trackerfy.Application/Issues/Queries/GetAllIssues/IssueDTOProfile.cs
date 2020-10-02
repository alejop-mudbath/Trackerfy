using AutoMapper;
using Trackerfy.Domain.Entities;

namespace Trackerfy.Application.Issues.Queries.GetAllIssues
{
    public class IssueDTOProfile: Profile
    {
        public IssueDTOProfile()
        {
            CreateMap<Issue,IssueDTO>();
        }
    }
}