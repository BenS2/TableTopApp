using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TableGameApp2.Data
{
    public class Army
    {
        public Guid _armyId { get; set; }
        public string _armyName { get; set; }
        public List<Guid> _heroIds { get; set; }
        public Army()
        {
            _heroIds = new List<Guid>();
        }

        public Army(List<Guid> heroIds)
        {
            _heroIds = heroIds;
        }
    }

    
}
