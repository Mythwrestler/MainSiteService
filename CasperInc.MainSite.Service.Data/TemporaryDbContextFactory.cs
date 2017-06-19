using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace CasperInc.MainSite.Service.Data
{
    public class TemporaryDbContextFactory : IDbContextFactory<NarrativeDbContext>
    {
        public NarrativeDbContext Create(DbContextFactoryOptions options)
        {
            throw new NotImplementedException();
        }
    }
}
