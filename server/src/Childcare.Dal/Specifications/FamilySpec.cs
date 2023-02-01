using System;
using System.Linq.Expressions;
using Childcare.Dal.Models;
using Unosquare.EntityFramework.Specification.Common.Primitive;

namespace Childcare.Dal.Specifications.FamilySpec;

public class FamilyByIdSpec : Specification<Family>
{
    private readonly int _id;
    public FamilyByIdSpec(int id) => _id = id;

    public override Expression<Func<Family, bool>> BuildExpression()
    {
        return x => x.Id == _id;
    }
}

