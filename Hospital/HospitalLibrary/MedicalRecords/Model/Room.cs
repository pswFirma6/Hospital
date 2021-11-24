using Hospital_library.MedicalRecords.Model.Enums;
using System;
using System.Collections.Generic;

namespace Hospital_library.MedicalRecords.Model
{
    public class Room : Entity
    {
        public String name { get; set; }
        public RoomType RoomType { get; set; }
        public int Floor { get; set; }
        public float SquareFootage { get; set; }
        public bool IsBeingRenovated { get; set; }
        public List<Equipment> Equipment { get; set; }
    }
}
