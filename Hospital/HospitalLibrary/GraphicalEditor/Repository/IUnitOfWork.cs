using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalLibrary.GraphicalEditor.Repository
{
    public interface IUnitOfWork
    {
        int Complete();
    }
}
