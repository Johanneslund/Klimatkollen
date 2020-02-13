using Grupp7.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Grupp7.Data
{
    public class IdRepository : IIdRepository
    {
        private IdDbContext context;

        public IdRepository(IdDbContext context)
        {
            this.context = context;
        }

        
    }
}
