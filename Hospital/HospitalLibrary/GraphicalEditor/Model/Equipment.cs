using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace project.Model
{
    public class Equipment : Entity
    {
        public Room room { get; set; }
        public String name { get; set; }

        public int Amount { get; set; }
    }
}
