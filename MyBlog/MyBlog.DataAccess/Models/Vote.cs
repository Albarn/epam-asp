using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.DataAccess.Models
{
    public class Vote
    {
        public int VoteId { get; set; }

        public Article Article { get; set; }
        public int ArticleId { get; set; }
    }
}
