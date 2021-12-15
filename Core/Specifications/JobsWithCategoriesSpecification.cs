using System;
using System.Linq.Expressions;
using Core.Entities;

namespace Core.Specifications
{
    public class JobsWithCategoriesSpecification : BaseSpecification<Job>
    {
        public JobsWithCategoriesSpecification()
        {
            AddInclude(x => x.JobCategory);
        }

        public JobsWithCategoriesSpecification(int id) : base(x => x.Id == id)
        {
            AddInclude(x => x.JobCategory);
        }
    }
}