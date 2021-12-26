using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Core.Specifications
{
    public interface ISpecification<T>
    {
        Expression<Func<T, bool>> Criteria {get; }      //generic method that could take generic criteria like where the id =2, This is going to be the "WHERE" clause
        List<Expression<Func<T, object>>> Includes {get; }      //This is going to be the list of "Include" statements
        Expression<Func<T, object>> OrderBy {get; }
        Expression<Func<T, object>> OrderByDescending {get; }
        int Take {get; }
        int Skip {get; }
        bool IsPagingEnabled {get; }
    }
}