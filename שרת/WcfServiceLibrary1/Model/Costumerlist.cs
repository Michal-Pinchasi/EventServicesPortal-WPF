using modle;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Costumerlist:List<Costumer>
    {
        public Costumerlist() { }
        public Costumerlist(IEnumerable<Costumer> list) : base(list) { }
        public Costumerlist(IEnumerable<BaseEntity> list) : base(list.Cast<Costumer>().ToList()) { }
    }
}
