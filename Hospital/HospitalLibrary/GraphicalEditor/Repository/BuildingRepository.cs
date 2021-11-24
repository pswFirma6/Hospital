using HospitalLibrary.GraphicalEditor.Core;
using HospitalLibrary.GraphicalEditor.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalLibrary.GraphicalEditor.Repository
{
    public class BuildingRepository : Repository<Building>, IBuildingRepository
    {
        public BuildingRepository(MyDbContext context) : base(context)
        {

        }
    }
}
