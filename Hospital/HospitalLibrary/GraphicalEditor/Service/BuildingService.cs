using HospitalLibrary.GraphicalEditor.Model;
using HospitalLibrary.GraphicalEditor.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalLibrary.GraphicalEditor.Service
{
    public class BuildingService : IService<Building>
    {
        public IEnumerable<Building> getAll()
        {
            using (UnitOfWork unitOfWork = new UnitOfWork(new MyDbContext()))       //poziva dispose na kraju
            {
                return unitOfWork.Buildings.GetAll();
            }
        }

        public Building create(Building building)
        {
            using (UnitOfWork unitOfWork = new UnitOfWork(new MyDbContext()))       //poziva dispose na kraju
            {
                unitOfWork.Buildings.Add(building);
                unitOfWork.Complete();

                return building;
            }
        }


    }
}
