using System;
using System.Collections.Generic;
using System.Text;
using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public IResult Add(User users)
        {
            _userDal.Add(users);
            return new SuccessResult(Messages.UserAdded);
        }

        public IResult Delete(User users)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<User>> GetAllUsers()
        {
            throw new NotImplementedException();
        }

        public IResult Update(User users)
        {
            throw new NotImplementedException();
        }
    }
}
