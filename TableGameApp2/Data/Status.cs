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

        public static bool operator ==(Status obj1, Status obj2)
        {
            if (obj1 is null && obj2 is null)
                return true;
            if (obj1 is null && (obj2 is null) == false)
                return false;
            if ((obj1 is null) == false && obj2 is null)
                return false;
            if (obj1.statusName != obj2.statusName)
                return false;
            if (obj1.statusValue != obj2.statusValue)
                return false;
            else
                return true;

        }

        public static bool operator !=(Status obj1, Status obj2)
        {
            return (obj1 == obj2) == false;
        }

        public override bool Equals(object other)
        {
            return other is Status && this == (Status)other;
        }
    }
}
