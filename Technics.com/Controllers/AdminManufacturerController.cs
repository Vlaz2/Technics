using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Technics.com.Attributes;
using Technics.com.Interfaces;
using Technics.com.Models;

namespace Technics.com.Controllers
{
    [AuthorizedAttribute(Roles.Admin)]
    public class AdminManufacturerController : Controller
    {
        private readonly IManufacturer manufacturerRep;

        public AdminManufacturerController(IManufacturer manufacturerRep)
        {
            this.manufacturerRep = manufacturerRep;
        }

        public IActionResult CreateManufacturer(string message)
        {
            ViewBag.message = message;
            return View();
        }

        
        public async Task<IActionResult> CreateManufacturer(Manufacturer manufacturer)
        {
            await manufacturerRep.CreateManufacturerAsync(manufacturer);
            return RedirectToAction("CreateManufacturer", new { message ="Производитель успешно создан"});
        }
    }
}