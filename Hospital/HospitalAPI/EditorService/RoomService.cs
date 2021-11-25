using HospitalAPI.EditorRepository;
using HospitalLibrary.GraphicalEditor.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalAPI.EditorService
{
    public class RoomService : IService<Room>
    {
        private MyDbContext dbContxt;

        public RoomService(MyDbContext dbContxt)
        {
            this.dbContxt = dbContxt;
        }
        public IEnumerable<Room> getAll()
        {
            using (UnitOfWork unitOfWork = new UnitOfWork(dbContxt))       //poziva dispose na kraju
            {
                return unitOfWork.Rooms.GetAll();
            }
        }

        public Room create(Room room)
        {
            using (UnitOfWork unitOfWork = new UnitOfWork(dbContxt))       //poziva dispose na kraju
            {
                unitOfWork.Rooms.Add(room);
                unitOfWork.Complete();

                return room;
            }
        }
    }
}
