using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class iletisimadresleri
    {
        [Key]
        public int Id { get; set; }
        public string iletisimadi { get; set; } 
        public string phonenumber { get; set; }
        public string adress { get; set; }
        public string eposta { get; set; }
        public bool iletisimstatus { get; set; }
        public string Youtube { get; set; }
        public string Github { get; set; }
        public string Linkedin { get; set; }
        public string Instagram { get; set; }
        public string Facebook { get; set; }
        public string Tweteer { get; set; }
        public string Pinterest { get; set; }
        public string Discord { get; set; }
        public string Microsoft { get; set; }
        public string WeChat { get; set; }
        public string Twitch { get; set; }
        //public string Reddit { get; set; }
    }
}
