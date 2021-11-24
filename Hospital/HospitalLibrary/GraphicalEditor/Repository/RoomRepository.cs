using HospitalLibrary.GraphicalEditor.Core;
using HospitalLibrary.GraphicalEditor.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalLibrary.GraphicalEditor.Repository
{
    public class RoomRepository : Repository<Room>, IRoomRepository
    {
        public RoomRepository(MyDbContext context) : base(context) { }
    }
}
