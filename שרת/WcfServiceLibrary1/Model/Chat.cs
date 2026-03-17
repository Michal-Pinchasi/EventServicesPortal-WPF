using modle;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Chat : BaseEntity
    {
        private People peopleWriter;

        public People PeopleWriter
        {
            get { return peopleWriter; }
            set { peopleWriter = value; }
        }

        private People peopleAccept;

        public People PeopleAccept
        {
            get { return peopleAccept; }
            set { peopleAccept = value; }
        } 
        private bool read;

        public bool Read
        {
            get { return read; }
            set { read = value; }
        }

        private Business business;

        public Business Business
        {
            get { return business; }
            set { business = value; }
        }

        private string remarks;

        public string Remarks
        {
            get { return remarks; }
            set { remarks = value; }
        }
        private DateTime chatdate;

        public DateTime ChatDate
        {
            get { return chatdate; }
            set { chatdate = value; }
        }
    }
}
