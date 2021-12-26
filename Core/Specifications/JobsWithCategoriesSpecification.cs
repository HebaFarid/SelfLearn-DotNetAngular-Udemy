using System;
using System.Linq.Expressions;
using Core.Entities;

namespace Core.Specifications
{
    public class JobsWithCategoriesSpecification : BaseSpecification<Job>
    {
        public JobsWithCategoriesSpecification(JobsSpecParams jobParams) 
        : base(x =>
        (string.IsNullOrEmpty(jobParams.Search) || x.Title.ToLower().Contains(jobParams.Search)) && 
        (!jobParams.CategoryId.HasValue || x.JobCategoryId == jobParams.CategoryId))
        {
            AddInclude(x => x.JobCategory);
            AddOrderBy(x => x.Title);
            ApplyPaging(jobParams.PageSize * (jobParams.PageIndex - 1), jobParams.PageSize);
        }

        public JobsWithCategoriesSpecification(int id) : base(x => x.Id == id)
        {
            AddInclude(x => x.JobCategory);
        }
    }
}