using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Xml.Serialization;
using System.Windows.Controls;

namespace TableGameApp2.Data
{
    public class Hero
    {
        public Guid _guid { get; set; }
        public String _name { get; set; }
        public List<Status> _statuses { get; set; }
        public String _notes { get; set; }
        public Hero()
        {
            _name = "";
            _notes = "";
           _statuses = new List<Status>();
            _guid = Guid.Empty;
        }

        public Hero(string name, List<Status> statuses, string notes, Guid guid)
        {
            _name = name;
            _statuses = statuses;
            _notes = notes;
            _guid = guid;
        }

        public static bool operator ==(Hero obj1, Hero obj2)
        {
            if (obj1 is null && obj2 is null)
                return true;
            if(obj1 is null && (obj2 is null) == false)
                return false;
            if ((obj1 is null) == false && obj2 is null)
                return false;
            if (obj1._notes != obj2._notes)
                return false;
            if (obj1._name != obj2._name)
                return false;
            if (obj1._statuses.SequenceEqual(obj2._statuses) == false)
                return false;
            if (obj1._guid != obj2._guid)
                return false;
            else
                return true;

        }

        public static bool operator !=(Hero obj1, Hero obj2)
        {
            return (obj1 == obj2) == false;
        }

        public override bool Equals(object other)
        {
            return other is Hero && this == (Hero)other;
        }
        public List<Status> getStatuses() { return _statuses; }
        public void setStatuses(List<Status> statuses) { _statuses = statuses; }

    }
}
