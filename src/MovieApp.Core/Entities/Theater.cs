using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApp.Core.Entities
{   
    public class Theater : BaseEntity
    {
        public string Name { get; set; }
        public string Location { get; set; }
        public int TotalSeats { get; set; }
        public List<ShowTime> ShowTimes { get; set; }

    }

}
