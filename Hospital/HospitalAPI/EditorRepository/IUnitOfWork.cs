using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalAPI.EditorRepository
{
    public interface IUnitOfWork
    {
        int Complete();
    }
}
