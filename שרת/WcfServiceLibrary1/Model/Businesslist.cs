using modle;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Businesslist:List<Business>
    {
        public Businesslist() { }
        public Businesslist(IEnumerable<Business> list) : base(list) { }
        public Businesslist(IEnumerable<BaseEntity> list) : base(list.Cast<Business>().ToList()) { }
    }
}
