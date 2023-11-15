using DataAccsessLayer.Abstract;
using DataAccsessLayer.Concrete;
using DataAccsessLayer.Repositories;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccsessLayer.EntityFramework
{
    public class EFBlogRepository : GenericRepository<Blog>, IBlogDal
    {

        public List<Blog> blogagoreyazarınmedyahesabinigetir(int id)
        {
            using (var c = new Context())
            {
                return c.Blogs.Include(x => x.Writers).Where(x => x.BlogId == id).Take(1).ToList();
            }
        }

        public List<Blog> getlistblogidbyfromcategory(int id)
        {
            throw new NotImplementedException();

        }

        public List<Blog> GetListWithCategory()
        {
            using (var c = new Context())
            {
                return c.Blogs.Include(x => x.Category).ToList();
            }
        }

        public List<Blog> GetListWithCategoryByWriter(int id)
        {
            using (var c = new Context())
            {
                return c.Blogs.Include(x => x.Category).Where(x => x.WritersId == id).ToList();
            }
        }


    }
}
