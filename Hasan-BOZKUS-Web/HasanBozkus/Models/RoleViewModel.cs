using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HasanBozkus.Models
{
    public class RoleViewModel
    {
        [Required(ErrorMessage ="Lütfen Role adı giriniz...")]
        public string Name { get; set; }
    }
}
