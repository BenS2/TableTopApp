using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace TableGameApp2.Data
{
    public class Status
    {
        //Note: you need to declare member variables/their setters/getters like this for you to be able to 
        //bind listViews' column's to them
        public String statusName { get; set; }
        public String statusValue { get; set; }
        public Status() 
        {
            statusName = "";
            statusValue = "";
        }

        public Status(String statusName, String statusValue)
        {
            this.statusName = statusName;
            this.statusValue = statusValue;
        }
    }
}
