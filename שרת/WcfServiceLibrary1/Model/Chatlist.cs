using modle;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    
        public class Chatlist : List<Chat>
        {
            public Chatlist() { }
            public Chatlist(IEnumerable<Chat> list) : base(list) { }
            public Chatlist(IEnumerable<BaseEntity> list) : base(list.Cast<Chat>().ToList()) { }

        }
    
}
