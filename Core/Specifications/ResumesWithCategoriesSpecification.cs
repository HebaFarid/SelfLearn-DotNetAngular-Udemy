using System;
using System.Linq.Expressions;
using Core.Entities;

namespace Core.Specifications
{
    public class ResumesWithCategoriesSpecification : BaseSpecification<Resume>
    {
        public ResumesWithCategoriesSpecification()
        {
            AddInclude(x => x.ResumeCategory);
        }

        public ResumesWithCategoriesSpecification(int id) : base(x => x.Id == id)
        {
            AddInclude(x => x.ResumeCategory);
        }
    }
}