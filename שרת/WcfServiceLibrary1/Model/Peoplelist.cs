using modle;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Peoplelist:List<People>
    {
        public Peoplelist() { }
        public Peoplelist(IEnumerable<People> list) : base(list) { }
        public Peoplelist(IEnumerable<BaseEntity> list) : base(list.Cast<People>().ToList()) { }
    }
}
