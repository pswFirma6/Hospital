using HospitalLibrary.MedicalRecords.Model;
using System.Collections.Generic;
using System.Text;

namespace Hospital_library.MedicalRecords.Model
{
    public class Medicine : Entity
    {
        public string Name { get; set; }
        public int Quantity { get; set; }

        public Medicine() { }

        public Medicine(int id, string name, int quantity)
        {
            Id = id;
            Name = name;
            Quantity = quantity;
        }
    }
}
