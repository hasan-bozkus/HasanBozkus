using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Catch
    {
        [Key]
        public int CatchId { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public int? SenderId { get; set; }
        public int? AnsweringId { get; set; }
        public string CatchTitle { get; set; }
        public string sohbetaciklamasi { get; set; }
        public string CatchDetails { get; set; }
        public DateTime CatchDate { get; set; } 
        public bool CatchStatus { get; set; }
        public AppUser SenderCatchUser { get; set; }
        public AppUser AnsweringCatchUser { get; set; }
        public List<Talk> Talks { get; set; }

    }
}
