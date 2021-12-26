using Core.Entities;

namespace Core.Specifications
{
    public class JobWithFiltersForCountSpecification : BaseSpecification<Job>
    {
        public JobWithFiltersForCountSpecification(JobsSpecParams jobParams) 
        : base(x => 
        (string.IsNullOrEmpty(jobParams.Search) || x.Title.ToLower().Contains(jobParams.Search)) &&
        (!jobParams.CategoryId.HasValue || x.JobCategoryId == jobParams.CategoryId))
        {
        }
    }
}