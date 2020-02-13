using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Grupp7.Data
{
    public class IdDbContext :IdentityDbContext
    {
        public IdDbContext(DbContextOptions<IdDbContext> options) : base(options) { }


    }
}
