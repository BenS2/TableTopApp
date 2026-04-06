using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
namespace TableGameApp2.Data
{
    public class Hero
    {
        String _name;
        /*ObservableCollection<Status> _statuses;*/
        String _notes;

        public Hero()
        {
            _name = "";
            _notes = "";
           //_statuses = new ObservableCollection<Status>();
        }

        public Hero(string name, /*ObservableCollection<Status> statuses,*/ string notes)
        {
            _name = name;
            //_statuses = statuses;
            _notes = notes;
        }


        public String getName() { return _name; }
        //public ObservableCollection<Status> getStatuses() { return _statuses; }
        public String getNotes() { return _notes; }

        public void setName(String name) { _name = name; }
        //public void setStatuses(ObservableCollection<Status> statuses) { _statuses = statuses; }
        public void setNotes(String notes) { _notes = notes; }

    }
}
