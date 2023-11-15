using EntityLayer.Concrete;
using System.Collections.Generic;

namespace HasanBozkus.Models
{
    public class SearchViewModel
    {
        public string Query { get; set; }
        public List<Blog> Results { get; set; }
    }
}
