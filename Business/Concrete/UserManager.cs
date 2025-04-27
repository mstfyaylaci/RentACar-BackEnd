using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validaton;
using Core.Entities.Concrete;
using Core.Entitites.Concrete;
using Core.Utilities.Business;
using Core.Utilities.Result;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Business.ValidationRules.FluentValidation.UserValidator;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }


        public IDataResult<List<User>> GetAll()
        {
            return new SuccessDataResult<List<User>>(_userDal.GetAll(), Messages.UserListed);
        }

        public IDataResult<List<UserDto>> GetAllDto()
        {
            return new SuccessDataResult<List<UserDto>>(_userDal.GetUsersDtos(), Messages.UserListed);
        }

        public IDataResult<User> GetById(int id)
        {
            return new SuccessDataResult<User>(_userDal.Get(u => u.Id == id), Messages.UserByListed);
        }

        public User GetByMail(string email)
        {
            return _userDal.Get(u => u.Email == email);
        }

        [ValidationAspect(typeof(UserDtoValidator))]
        public List<OperationClaim> GetClaims(User user)
        {
            return _userDal.GetClaims(user);
        }

        public IDataResult<UserDto> GetUserDtoById(int userId)
        {
            return new SuccessDataResult<UserDto>(_userDal.GetUsersDtos(u => u.Id == userId).SingleOrDefault(), Messages.UserListed);
        }

        public IDataResult<UserDto> GetUserDtoByMail(string email)
        {
            return new SuccessDataResult<UserDto>(_userDal.GetUsersDtos(u => u.Email == email).SingleOrDefault(), Messages.UserListed);
        }

        [ValidationAspect(typeof(UserValidator))]
        public IResult Add(User user)
        {
            _userDal.Add(user);

            return new SuccessResult();
        }

        public IResult Delete(User user)
        {
            _userDal.Delete(user);
            return new SuccessResult(Messages.UserDeleted);
        }

        

        [ValidationAspect(typeof(UserValidator))]
        public IResult Update(User user)
        {
            _userDal.Update(user);
            return new SuccessResult(Messages.UserUpdated);
        }

        [ValidationAspect(typeof(UserDtoValidator))]
        public IResult UpdateByDto(UserDto userDto)
        {
            var rulesResult = BusinessRules.Run(CheckIfUserIdExist(userDto.Id)
                , CheckIfEmailAvailable(userDto.Email));
            if (rulesResult != null)
            {
                return rulesResult;
            }

            var updatedUser = _userDal.Get(u => u.Id == userDto.Id && u.Email == userDto.Email);
            if (updatedUser == null)
            {
                return new ErrorResult(Messages.UserNotFound);
            }

            updatedUser.FirstName = userDto.FirstName;
            updatedUser.LastName = userDto.LastName;
            _userDal.Update(updatedUser);
            return new SuccessResult(Messages.UserUpdated);
        }


        //Business Rules

        private IResult CheckIfUserIdExist(int userId)
        {
            var result = _userDal.GetAll(u => u.Id == userId).Any();
            if (!result)
            {
                return new ErrorResult(Messages.UserNotFound);
            }
            return new SuccessResult();
        }

        

        private IResult CheckIfEmailAvailable(string userEmail)
        {
            var result = BaseCheckIfEmailExist(userEmail);
            if (!result)
            {
                return new ErrorResult(Messages.UserEmailNotAvailable);
            }
            return new SuccessResult();
        }

        private bool BaseCheckIfEmailExist(string userEmail)
        {
            return _userDal.GetAll(u => u.Email == userEmail).Any();
        }
    }
}
