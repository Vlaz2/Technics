using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Technics.com.Interfaces;
using Technics.com.Models;

namespace Technics.com.Repository
{
    public class ManufacturerRepository : IManufacturer
    {
        private readonly AppDbContext appDbContext;

        public ManufacturerRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public async Task CreateManufacturerAsync(Manufacturer manufacturer)
        {
            await appDbContext.Manufacturers.AddAsync(manufacturer);
            await appDbContext.SaveChangesAsync();
        }

        public List<Manufacturer> GetAlIManufacturers()
        {
            return appDbContext.Manufacturers.ToList();
        }
    }
}
