using modle;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Takendateslist:List<Takendates>
    {
        public Takendateslist() { }
        public Takendateslist(IEnumerable<Takendates> list) : base(list) { }
        public Takendateslist(IEnumerable<BaseEntity> list) : base(list.Cast<Takendates>().ToList()) { }
    }
}
