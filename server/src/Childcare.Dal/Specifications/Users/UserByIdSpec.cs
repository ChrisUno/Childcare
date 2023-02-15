using Childcare.Dal.Models;
using System.Linq.Expressions;
using Unosquare.EntityFramework.Specification.Common.Primitive;
using Childcare.Dal.Models;

namespace Childcare.Dal.Specifications.Users
{
    public class UserByIdSpec : Specification<User>
    {
        private readonly int _id;

        public UserByIdSpec(int id)
        {
            _id = id;
        }

        public override Expression<Func<User, bool>> BuildExpression()
        {
            return x => x.Id == _id;
        }
    }
}