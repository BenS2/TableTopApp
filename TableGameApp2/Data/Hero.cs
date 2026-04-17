using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Xml.Serialization;

namespace TableGameApp2.Data
{
    public class Hero
    {
        public String _name { get; set; }
        public List<Status> _statuses { get; set; }
        public String _notes { get; set; }
        public Hero()
        {
            _name = "";
            _notes = "";
           _statuses = new List<Status>();
        }

        public Hero(string name, List<Status> statuses, string notes)
        {
            _name = name;
            _statuses = statuses;
            _notes = notes;
        }


        public List<Status> getStatuses() { return _statuses; }
        public void setStatuses(List<Status> statuses) { _statuses = statuses; }

    }
}
