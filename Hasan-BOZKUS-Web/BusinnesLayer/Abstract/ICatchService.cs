using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinnesLayer.Abstract
{
    public interface ICatchService : IGenericService<Catch>
    {
        List<Catch> GetList(int id);
        List<Catch> GetCatchWithCategory();
        List<Catch> GetCatchWithCategory(int id);
        List<Catch> GetCathById(int Id);
        //List<Message2> GetSenderListByWriter(int id);
        //List<Message2> GetAnsweringListByWriter(int id);
    }
}
