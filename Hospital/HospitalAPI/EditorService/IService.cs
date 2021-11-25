using HospitalLibrary.GraphicalEditor.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalAPI.EditorService
{
    public interface IService<TEntity> where TEntity : class
    {
        public IEnumerable<TEntity> getAll();
        public TEntity create(TEntity entity);
    }
}
