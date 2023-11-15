using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Talk
    {
        [Key]
        public int TalkId { get; set; }
        public string TalkUserName { get; set; }
        public string Talkttitle { get; set; }
        public string TalkContent { get; set; }
        public DateTime TalktDate { get; set; }
        public int TalkScore { get; set; }
        public bool TalkStatus { get; set; }
        public int CatchId { get; set; }
        public Catch @catch { get; set; }
    }
}
