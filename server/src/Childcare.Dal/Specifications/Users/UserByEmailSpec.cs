﻿using Childcare.Dal.Models;
using System.Linq.Expressions;
using Unosquare.EntityFramework.Specification.Common.Primitive;
using Childcare.Dal.Models;

namespace Childcare.DAL.Specifications.Users
{
    public class UserByEmailSpec : Specification<User>
    {
        private readonly string _email;

        public UserByEmailSpec(string email)
        {
            _email = email;
        }

        public override Expression<Func<User, bool>> BuildExpression()
        {
            return x => x.Email.Contains(_email);
        }
    }
}