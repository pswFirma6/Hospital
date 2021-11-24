using Hospital_library.MedicalRecords.Model.Enums;
using System;

namespace Hospital_library.MedicalRecords.Model
{
    public class Equipment : Entity
    {
        public String Name { get; set; }
        public EquipmentType Type { get; set; }
        public int Quantity { get; set; }
    }
}
