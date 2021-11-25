using HospitalLibrary.GraphicalEditor.Core;
using HospitalLibrary.GraphicalEditor.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace HospitalAPI.EditorRepository
{
    public class FloorRepository : Repository<Floor>, IFloorRepository
    {
        public FloorRepository(MyDbContext context) : base(context) { }

        public override IEnumerable<Floor> GetAll()
        {
            return MyDbContext.Floors.Include(x => x.building).ToList();
        }


    }
}
