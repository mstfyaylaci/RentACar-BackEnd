using Core.DataAccess;
using Core.Entities.Concrete;
using Core.Entitites.Concrete;
using Entities.Concrete;
using Entities.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IUserDal:IEntitiyRepository<User>
    {
        List<OperationClaim> GetClaims(User user);

        List<UserDto> GetUsersDtos(Expression<Func<UserDto, bool>> filter = null);
    }
}
