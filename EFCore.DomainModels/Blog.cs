using System;
using System.Collections.Generic;
using System.Text;

namespace EFCore.DomainModels
{
    public class Blog
    {
        public int BlogId { get; set; }
        public string Url { get; set; }
        public DateTime CreateTime { get; set; }
        public decimal Rating { get; set; }
        public DateTime LoadedFromDatabase { get; set; }
        public List<Post> Posts { get; } = new List<Post>();
    }
}
