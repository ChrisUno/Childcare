using System;
using System.Linq.Expressions;
using Childcare.Dal.Models;
using Unosquare.EntityFramework.Specification.Common.Primitive;

namespace Childcare.Dal.Specifications.AddressSpec;

public class AddressByIdSpec : Specification<Address>
{
    private readonly int _id;
    public AddressByIdSpec(int id) => _id = id;

    public override Expression<Func<Address, bool>> BuildExpression()
    {
        return x => x.Id == _id;
    }
}

