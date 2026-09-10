using Microsoft.AspNetCore.Mvc;
using ShopTAR25.Models.Spaceship;
using ShopTARpe25.ApplicatsionServices.services;
using ShopTARpe25.Core.Dto;
using ShopTARpe25.Core.ServiceInterface;

namespace ShopTAR25.Controllers
{
    public class SpaceshipController : Controller
    {
        private readonly ISpaceshipServises _spaceshipServises;
            
        public SpaceshipController
            (
                ISpaceshipServises spaceshipServices
            )
        {
            _spaceshipServises = spaceshipServices;
        }
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
            //luua vaheinstants, mis sisaldeb andmeid, mis on saadud vormist
            //need andmed tuleb edasi saata dto-sse, mis on mõeldud andmebaasi salvestamiseks
            var dto = new SpaceshipDto
            {
                Id = vm.Id,
                Name = vm.Name,
                Classification = vm.Classification,
                BuildTime = vm.BuildTime,
                crew = vm.Crew,
                EnginePower = vm.EnginePower
            };


            var result = await _spaceshipServises.Create(dto);

            return RedirectToAction(nameof(Index));
        }

    }
}
