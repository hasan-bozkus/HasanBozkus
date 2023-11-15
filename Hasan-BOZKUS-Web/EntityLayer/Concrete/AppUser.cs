using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace EntityLayer.Concrete
{
    public class AppUser : IdentityUser<int>
    {
        public string NameSurname { get; set; }
        public string ImageUrl { get; set; }
        public string UserAbout { get; set; }
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
        public bool UserStatus { get; set; }


        public virtual ICollection<Message2> UserSender { get; set; }
        public virtual ICollection<Message2> UserReceiver { get; set; }
        public virtual ICollection<Catch> UserCatchSender { get; set; }
        public virtual ICollection<Catch> UserCatchAnswering { get; set; }

    }
}
