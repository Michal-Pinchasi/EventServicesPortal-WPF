using modle;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Categorieslist:List<Categories>
    {
        public Categorieslist() { }
        public Categorieslist(IEnumerable<Categories> list) : base(list) { }
        public Categorieslist(IEnumerable<BaseEntity> list) : base(list.Cast<Categories>().ToList()) { }
    }
}
