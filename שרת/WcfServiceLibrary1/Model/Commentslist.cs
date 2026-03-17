using modle;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Commentslist:List<Comments>
    {
        public Commentslist() { }
        public Commentslist(IEnumerable<Comments> list) : base(list) { }
        public Commentslist(IEnumerable<BaseEntity> list) : base(list.Cast<Comments>().ToList()) { }
    }
}
