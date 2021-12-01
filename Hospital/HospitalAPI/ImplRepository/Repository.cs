using HospitalAPI;
using HospitalLibrary.MedicalRecords.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;


namespace HospitalLibrary.MedicalRecords.Repository
{
    public class Repository<Entity> : IRepository<Entity> where Entity : Model.Entity
    {
        private MyDbContext _context;
        private DbSet<Entity> entities;

        public Repository(MyDbContext context)
        {
            _context = context;
            entities = _context.Set<Entity>();
        }

        public virtual List<Entity> GetAll()
        {
            return entities.ToList();
        }
        public Entity GetOne(string id)
        {
            return entities.SingleOrDefault(s => s.Id == id);
        }
        public Entity Add(Entity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Add(entity);
            _context.SaveChanges();
            return entity;
        }
        public Entity Update(Entity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            _context.SaveChanges();
            return entity;
        }
        public void Delete(Entity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Remove(entity);
            _context.SaveChanges();
        }
    }
}
