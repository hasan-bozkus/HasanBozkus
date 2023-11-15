using BusinnesLayer.Abstract;
using DataAccsessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BusinnesLayer.Concrete
{
    public class UserManager : IUserService
    {
        IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }
        public List<AppUser> GetList()
        {
            return _userDal.GetListAll().ToList();
        }

        public List<AppUser> GetUserById(int id)
        {
            return _userDal.GetListAll(x => x.Id == id);
        }

        public List<AppUser> GetWriterList()
        {
            return _userDal.GetWriterList().ToList();
        }

        public void TAdd(AppUser t)
        {
            _userDal.Insert(t); 
        }

        public void TDelete(AppUser t)
        {
            _userDal.Delete(t);
        }

        public AppUser TGetById(int id)
        {
            return _userDal.GetByID(id);
        }

        public void TUpdate(AppUser t)
        {
            _userDal.Update(t);
        }
    }
}
