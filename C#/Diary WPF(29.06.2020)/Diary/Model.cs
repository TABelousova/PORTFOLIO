using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Diary
{
    class Model
    {
        private DateTime _date;
        private string _name;
        private string _status;
        private string _them;
        private string _coments;

        public DateTime Date
        {
            set { _date = value; }
            get { return _date; }
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public string Status
        {
            get { return _status; }
            set { _status = value; }
        }

        public string Them
        {
            get { return _them; }
            set { _them = value; }
        }

        public string Coments
        {
            get { return _coments; }
            set { _coments = value; }
        }

        public override string ToString()
        {
            return Date.ToString() + '~' + Name + '~' + Status + '~' + Them + '~' + Coments;
        }
    }
}
