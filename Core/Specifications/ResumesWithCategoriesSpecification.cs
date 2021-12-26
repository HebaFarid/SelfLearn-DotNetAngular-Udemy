using System;
using System.Linq.Expressions;
using Core.Entities;

namespace Core.Specifications
{
    public class ResumesWithCategoriesSpecification : BaseSpecification<Resume>
    {
        public ResumesWithCategoriesSpecification(ResumeSpecParams resumeParams) 
        : base(x =>
        (string.IsNullOrEmpty(resumeParams.Search) || x.Name.ToLower().Contains(resumeParams.Search)) &&
        (!resumeParams.CategoryId.HasValue || x.ResumeCategoryId == resumeParams.CategoryId))
        {
            AddInclude(x => x.ResumeCategory);
            AddOrderBy(x => x.Name);
            ApplyPaging(resumeParams.PageSize * (resumeParams.PageIndex-1), resumeParams.PageSize);


        }

        public ResumesWithCategoriesSpecification(int id) : base(x => x.Id == id)
        {
            AddInclude(x => x.ResumeCategory);
        }
    }
}