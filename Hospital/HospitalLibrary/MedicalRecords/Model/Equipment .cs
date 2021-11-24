using HospitalLibrary.MedicalRecords.Model.Enums;
using System;

namespace HospitalLibrary.MedicalRecords.Model
{
    public class Equipment : Entity
    {
        public String Name { get; set; }
        public EquipmentType Type { get; set; }
        public int Quantity { get; set; }
    }
}
