using Core.Entities.Concrete;
using Core.Entitites.Concrete;
using Core.Utilities.Result;
using Entities.Concrete;
using Entities.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IUserService
    {
        IDataResult<List<User>> GetAll();

        IDataResult<List<UserDto>> GetAllDto();
        IDataResult<User> GetById(int id);

        IDataResult<UserDto> GetUserDtoById(int userId);
        IResult Add(User user);
        IResult Update(User user);
        IResult UpdateByDto(UserDto userDto);
        IResult Delete(User user);

        List<OperationClaim> GetClaims(User user);
        
        User GetByMail(string email);
        IDataResult<UserDto> GetUserDtoByMail(string email);
    }
}
