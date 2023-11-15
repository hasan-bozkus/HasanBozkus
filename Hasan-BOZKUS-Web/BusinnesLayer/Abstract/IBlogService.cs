using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinnesLayer.Abstract
{
    public interface IBlogService: IGenericService<Blog>
    {
        List<Blog> GetBlogListWithCategory();
        List<Blog> GetBlogListByWriter(int id);
        List<Blog> GetBlogById(int Id);
        List<Blog> GetLast3Blog();
        List<Blog> Blogagoremedyahesbigetir(int id);
        List<Blog> getlistblogidbyfromcategory(int id);


    }
}

