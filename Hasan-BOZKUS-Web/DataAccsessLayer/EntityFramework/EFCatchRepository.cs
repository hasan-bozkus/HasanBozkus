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
    public class EFCatchRepository : GenericRepository<Catch>, ICatchDal
    {
     

        public List<Catch> GetAnswerWithMessageByWriter(int id)
        {
            throw new NotImplementedException();
        }

        public List<Catch> GetSenderWithMessageByWriter(int id)
        {
            using (var c = new Context())
            {
                return c.Catches.Include(x => x.SenderCatchUser).Where(x => x.AnsweringId == id).ToList();
            }
        }

        public List<Catch> GetListWithCategory()
        {
            using (var c = new Context())
            {
                return c.Catches.Include(x => x.Category).ToList();
            }
        }
    }
}
