﻿using project.Model;
using project.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace project.Service
{
    public class EquipmentService : IService<Equipment>
    {
        public IEnumerable<Equipment> getAll()
        {
            using (UnitOfWork unitOfWork = new UnitOfWork(new MyDbContext()))       //poziva dispose na kraju
            {
                return unitOfWork.Equipments.GetAll();
            }
        }

        public Equipment create(Equipment equipment)
        {
            using (UnitOfWork unitOfWork = new UnitOfWork(new MyDbContext()))       //poziva dispose na kraju
            {
                unitOfWork.Equipments.Add(equipment);
                unitOfWork.Complete();

                return equipment;
            }
        }
    }
}
