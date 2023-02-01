using System;
using System.Linq.Expressions;
using Childcare.Dal.Models;
using Unosquare.EntityFramework.Specification.Common.Primitive;

namespace Childcare.Dal.Specifications.EventSpec;

public class EventByIdSpec : Specification<Event>
{
    private readonly int _id;
    public EventByIdSpec(int id) => _id = id;

    public override Expression<Func<Event, bool>> BuildExpression()
    {
        return x => x.Id == _id;
    }
}

