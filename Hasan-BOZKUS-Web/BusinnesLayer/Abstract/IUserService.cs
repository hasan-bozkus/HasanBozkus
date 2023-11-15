using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinnesLayer.Abstract
{
    public interface IUserService : IGenericService<AppUser>
    {
        List<AppUser> GetWriterList();
        List<AppUser> GetUserById(int id);
    }
}
