using AutoMapper;
using Trackerfy.Domain.Entities;

namespace Trackerfy.Application.Queries.GetAllIssues
{
    public class IssueDTOProfile: Profile
    {
        public IssueDTOProfile()
        {
            CreateMap<Issue,IssueDTO>();
        }
    }
}