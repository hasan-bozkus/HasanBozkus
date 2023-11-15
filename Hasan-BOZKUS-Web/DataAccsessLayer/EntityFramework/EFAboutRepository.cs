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
    public class EFAboutRepository : GenericRepository<About>, IAboutDal
    {
        public List<About> Aboutagöremedyahesabigetir(int id)
        {
            using (var c = new Context())
            {
                return c.Abouts.Include(x => x.iletisimadresleri).Where(x => x.iletisimId == id).Take(1).ToList();
            }
        }
    }
}
