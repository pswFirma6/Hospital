using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalLibrary.GraphicalEditor.Configuration
{
    public class ProjectConfiguration : IProjectConfiguration
    {
        public DatabaseConfiguration DatabaseConfiguration { get; set; } = new DatabaseConfiguration();

    }

    public class DatabaseConfiguration
    {
        public string ConnectionString { get; set; }
    }


}
