using modle;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Citylist:List<City>
    {
        public Citylist() { }
        public Citylist(IEnumerable<City> list) : base(list) { }
        public Citylist(IEnumerable<BaseEntity> list) : base(list.Cast<City>().ToList()) { }
    }
}
