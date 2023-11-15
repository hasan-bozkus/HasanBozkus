using DataAccsessLayer.Abstract;
using DataAccsessLayer.Concrete;
using DataAccsessLayer.Repositories;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccsessLayer.EntityFramework
{
    public class EFUserRepository : GenericRepository<AppUser>, IUserDal
    {

        public List<AppUser> GetWriterList()
        {
            using (var c = new Context())
            {
                return c.Users.Include(x => x.UserName).ToList();
            }
        }

    }
}
