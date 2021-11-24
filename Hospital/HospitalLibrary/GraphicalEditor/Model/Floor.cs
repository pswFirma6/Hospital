using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace project.Model
{
    public class Floor : Entity
    {
        public Building building;
        public int FloorNumber { get; set; }
    }
}
