using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalLibrary.GraphicalEditor.Model
{
    public class Equipment : Entity
    {
        public virtual Room room { get; set; }
        public String name { get; set; }

        public int Amount { get; set; }
    }
}
