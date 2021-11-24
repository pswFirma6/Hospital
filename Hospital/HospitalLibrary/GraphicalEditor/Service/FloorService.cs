using project.Model;
using project.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace project.Service
{
    public class FloorService : IService<Floor>
    {
        public IEnumerable<Floor> getAll()
        {
            using (UnitOfWork unitOfWork = new UnitOfWork(new MyDbContext()))       //poziva dispose na kraju
            {
                return unitOfWork.Floors.GetAll();
            }
        }

        public Floor create(Floor floor)
        {
            using (UnitOfWork unitOfWork = new UnitOfWork(new MyDbContext()))       //poziva dispose na kraju
            {
                unitOfWork.Floors.Add(floor);
                unitOfWork.Complete();

                return floor;
            }
        }
    }
}
