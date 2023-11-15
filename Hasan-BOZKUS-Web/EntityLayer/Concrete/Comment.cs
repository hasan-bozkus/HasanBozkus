using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Comment
    {

        //tarih 05.08.2022
        [Key]
        public int CommentId { get; set; }
        public string CommentUserName { get; set; }
        public string Commenttitle { get; set; }
        public string CommentContent { get; set; }
        public DateTime CommentDate { get; set; }
        public int BlogScore { get; set; }
        public bool CommentStatus { get; set; }
        public bool IsDelete { get; set; }
        public int BlogId { get; set; }
        public Blog Blog { get; set; }
    }
}
