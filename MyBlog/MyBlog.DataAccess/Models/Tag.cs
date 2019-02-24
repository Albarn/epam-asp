using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.DataAccess.Models
{
    public class Tag
    {
        public int TagId { get; set; }
        public string TagString { get; set; }
        public ICollection<Article> Articles { get; set; }
    }
}
