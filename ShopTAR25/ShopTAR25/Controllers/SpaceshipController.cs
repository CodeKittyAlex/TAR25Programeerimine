using Microsoft.AspNetCore.Mvc;
using ShopTAR25.Models.Spaceship;

namespace ShopTAR25.Controllers
{
    public class SpaceshipController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        //kui kasutaja klikib "Create" nuppu, siis see meetod käivitakse
        //tagastab kasutajale vormi, kuhu saab sisestada andmed
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        //kui oled teinud vormi, siis see meetod käivitakse
        //saadab andmed serverisse, kus need salvestatakse andmebaasi
        [HttpPost]
        public async Task<IActionResult> Create(SpaceshipCreateViewModel vm)
        {
            return RedirectToAction(nameof(Index));
        }

    }
}
