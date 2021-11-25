using HospitalLibrary.GraphicalEditor.Core;
using HospitalLibrary.GraphicalEditor.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalAPI.EditorRepository
{
    public class RoomRepository : Repository<Room>, IRoomRepository
    {
        public RoomRepository(MyDbContext context) : base(context) { }

        public override IEnumerable<Room> GetAll()
        {
            return MyDbContext.Rooms.Include(x => x.Doctor).Include(x => x.floor).ToList();
        }
    }
}
