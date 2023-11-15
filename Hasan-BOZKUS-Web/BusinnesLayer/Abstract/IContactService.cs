using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinnesLayer.Abstract
{
    public interface IContactService : IGenericService<Contact>
    {
        void ContactAdd(Contact contact);
        List<Contact> GetListAll(int id);
    }
}
