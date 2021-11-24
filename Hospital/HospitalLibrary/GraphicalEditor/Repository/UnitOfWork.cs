using project.Core;
using project.Model;
using project.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace project.Repository
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly MyDbContext context;

        public UnitOfWork(MyDbContext context)
        {
            this.context = context;
            Buildings = new BuildingRepository(this.context);
            Floors = new FloorRepository(this.context);
            Rooms = new RoomRepository(this.context);
            Equipments = new EquipmentRepository(this.context);


        }

        public IBuildingRepository Buildings { get; private set; }
        public IFloorRepository Floors { get; private set; }
        public IRoomRepository Rooms { get; private set; }
        public IEquipmentRepository Equipments { get; private set; }


        public MyDbContext Context
        {
            get { return context; }
        }

        public int Complete()
        {
            return context.SaveChanges();
        }


        public void Dispose()
        {
            context.Dispose();
        }
    }
}
