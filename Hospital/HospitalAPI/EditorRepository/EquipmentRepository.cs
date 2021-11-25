using HospitalLibrary.GraphicalEditor.Core;
using HospitalLibrary.GraphicalEditor.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalAPI.EditorRepository
{
    public class EquipmentRepository : Repository<Equipment>, IEquipmentRepository
    {
        public EquipmentRepository(MyDbContext context) : base(context) { }

        public override IEnumerable<Equipment> GetAll()
        {
            return MyDbContext.Equipments.Include(x => x.room).ToList();
        }
    }
}
