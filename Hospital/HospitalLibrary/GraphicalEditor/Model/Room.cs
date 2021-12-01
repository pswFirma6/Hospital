using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalLibrary.GraphicalEditor.Model
{
    public class Room : Entity
    {
        public virtual Floor floor { get; set; }
        public String Name { get; set; }
        public String Description { get; set; }
        public String WorkHour { get; set; }
    }
}
