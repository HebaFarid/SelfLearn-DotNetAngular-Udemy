using Core.Entities;

namespace Core.Specifications
{
    public class ResumeWithFiltersForCountSpecification : BaseSpecification<Resume>
    {
        public ResumeWithFiltersForCountSpecification(ResumeSpecParams resumeParams) 
        : base(x =>
        (string.IsNullOrEmpty(resumeParams.Search) || x.Name.ToLower().Contains(resumeParams.Search)) && 
        (!resumeParams.CategoryId.HasValue || x.ResumeCategoryId == resumeParams.CategoryId))
        {
        }
    }
}