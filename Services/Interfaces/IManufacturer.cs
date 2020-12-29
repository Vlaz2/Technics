using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Technics.com.Models;

namespace Technics.com.Interfaces
{
    public interface IManufacturer
    {
        List<Manufacturer> GetAlIManufacturers();
        Task CreateManufacturerAsync(Manufacturer manufacturer);
    }
}
