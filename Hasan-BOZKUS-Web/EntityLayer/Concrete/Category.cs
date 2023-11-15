using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Category
    {
        //erişim belirleyici tütü - değişken türü, isim, {get; set;}; tarih 05.08.2022
        [Key]
        public int CategoryId { get; set; }
        public string CategorName { get; set; }
        public string CategoryDescription { get; set; }
        public bool CategoryStatus { get; set; }

        public List<Blog> Blogs { get; set; }


    }
}
