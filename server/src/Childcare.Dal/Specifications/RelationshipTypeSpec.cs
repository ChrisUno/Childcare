using System;
using System.Linq.Expressions;
using Childcare.Dal.Models;
using Unosquare.EntityFramework.Specification.Common.Primitive;

namespace Childcare.Dal.Specifications.RelationshipTypeSpec;

public class RelationshipTypeByIdSpec : Specification<RelationshipType>
{
    private readonly int _id;
    public RelationshipTypeByIdSpec(int id) => _id = id;

    public override Expression<Func<RelationshipType, bool>> BuildExpression()
    {
        return x => x.Id == _id;
    }
}

