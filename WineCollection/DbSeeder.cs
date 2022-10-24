using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;
using WineCollection.Entities;
//TODO: implement db seeding logic
namespace WineCollection
{
    public class DbSeeder
    {
        private readonly WineCollectionDbContext _dbContext;

        public DbSeeder(WineCollectionDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Seed()
        {
            if (_dbContext.Database.CanConnect())
            {

                var pendingMigration = _dbContext.Database.GetPendingMigrations();

                if (pendingMigration.Any())
                {
                    _dbContext.Database.Migrate();
                }

            }
        }

    }
}
