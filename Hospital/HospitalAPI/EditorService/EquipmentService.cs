using HospitalAPI.EditorRepository;
using HospitalLibrary.GraphicalEditor.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalAPI.EditorService
{
    public class EquipmentService : IService<Equipment>
    {
        private MyDbContext dbContxt;

        public EquipmentService(MyDbContext dbContxt)
        {
            this.dbContxt = dbContxt;
        }
        public IEnumerable<Equipment> getAll()
        {
            using (UnitOfWork unitOfWork = new UnitOfWork(dbContxt))       //poziva dispose na kraju
            {
                return unitOfWork.Equipments.GetAll();
            }
        }

        public Equipment create(Equipment equipment)
        {
            using (UnitOfWork unitOfWork = new UnitOfWork(dbContxt))       //poziva dispose na kraju
            {
                unitOfWork.Equipments.Add(equipment);
                unitOfWork.Complete();

                return equipment;
            }
        }
    }
}
