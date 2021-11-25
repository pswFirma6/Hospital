using HospitalAPI.EditorRepository;
using HospitalLibrary.GraphicalEditor.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalAPI.EditorService
{
    public class BuildingService : IService<Building>
    {

        private MyDbContext dbContxt;

        public BuildingService(MyDbContext dbContxt)
        {
            this.dbContxt = dbContxt;
        }

        public IEnumerable<Building> getAll()
        {
            using (UnitOfWork unitOfWork = new UnitOfWork(dbContxt))       //poziva dispose na kraju
            {
                return unitOfWork.Buildings.GetAll();
            }
        }

        public Building create(Building building)
        {
            using (UnitOfWork unitOfWork = new UnitOfWork(dbContxt))       //poziva dispose na kraju
            {
                unitOfWork.Buildings.Add(building);
                unitOfWork.Complete();

                return building;
            }
        }


    }
}
