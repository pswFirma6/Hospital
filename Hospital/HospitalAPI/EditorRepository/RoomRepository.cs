using HospitalLibrary.GraphicalEditor.Core;
using HospitalLibrary.GraphicalEditor.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalAPI.EditorRepository
{
    public class RoomRepository : Repository<Room>, IRoomRepository
    {
        public RoomRepository(MyDbContext context) : base(context) { }
    }
}
