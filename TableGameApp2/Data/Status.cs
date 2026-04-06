using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TableGameApp2.Data
{
    internal class Status
    {
        String _statusName;
        String _statusValue;
        public Status() 
        {
            _statusName = "";
            _statusValue = "";
        }

        public Status(String statusName, String statusValue)
        {
            _statusName = statusName;
            _statusValue = statusValue;
        }

        public String getStatusName() { return _statusName; }
        public void setStatusName(String statusName) { _statusName = statusName; }
        
        public String getStatusValue() { return _statusValue; }
        public void setStatusValue(String statusValue) { _statusValue = statusValue; }

    }
}
