using HospitalLibrary.GraphicalEditor.Core;
using HospitalLibrary.GraphicalEditor.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalLibrary.GraphicalEditor.Repository
{
    public class EquipmentRepository : Repository<Equipment>, IEquipmentRepository
    {
        public EquipmentRepository(MyDbContext context) : base(context) { }
    }
}
