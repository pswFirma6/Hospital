using project.Core;
using project.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace project.Repository
{
    public class FloorRepository : Repository<Floor>, IFloorRepository
    {
        public FloorRepository(MyDbContext context) : base(context) { }




    }
}
