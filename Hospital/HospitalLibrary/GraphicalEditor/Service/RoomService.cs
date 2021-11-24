using project.Model;
using project.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace project.Service
{
    public class RoomService : IService<Room>
    {
        public IEnumerable<Room> getAll()
        {
            using (UnitOfWork unitOfWork = new UnitOfWork(new MyDbContext()))       //poziva dispose na kraju
            {
                return unitOfWork.Rooms.GetAll();
            }
        }

        public Room create(Room room)
        {
            using (UnitOfWork unitOfWork = new UnitOfWork(new MyDbContext()))       //poziva dispose na kraju
            {
                unitOfWork.Rooms.Add(room);
                unitOfWork.Complete();

                return room;
            }
        }
    }
}
