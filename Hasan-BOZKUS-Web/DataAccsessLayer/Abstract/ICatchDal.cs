using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccsessLayer.Abstract
{
    public interface ICatchDal: IGenericDal<Catch>
    {
        List<Catch> GetListWithCategory();
        List<Catch> GetSenderWithMessageByWriter(int id);
        List<Catch> GetAnswerWithMessageByWriter(int id);
    }
}
