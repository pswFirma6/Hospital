using HospitalAPI.EditorRepository;
using HospitalLibrary.GraphicalEditor.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalAPI.EditorService
{
    public class FloorService : IService<Floor>
    {
        private MyDbContext dbContxt;

        public FloorService(MyDbContext dbContxt)
        {
            this.dbContxt = dbContxt;
        }
        public IEnumerable<Floor> getAll()
        {
            using (UnitOfWork unitOfWork = new UnitOfWork(dbContxt))       //poziva dispose na kraju
            {
                return unitOfWork.Floors.GetAll();
            }
        }

        public Floor create(Floor floor)
        {
            using (UnitOfWork unitOfWork = new UnitOfWork(dbContxt))       //poziva dispose na kraju
            {
                unitOfWork.Floors.Add(floor);
                unitOfWork.Complete();

                return floor;
            }
        }
    }
}
