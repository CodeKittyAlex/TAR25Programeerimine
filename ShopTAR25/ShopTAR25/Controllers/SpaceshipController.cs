using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShopTAR25.Models.Spaceship;
using ShopTARpe25.ApplicatsionServices.services;
using ShopTARpe25.Core.Dto;
using ShopTARpe25.Core.ServiceInterface;
using ShopTARpe25.Data;

namespace ShopTAR25.Controllers
{
    public class SpaceshipController : Controller
    {
        private readonly ShopTARpe25Context _context;
        private readonly ISpaceshipServises _spaceshipServises;
            
        public SpaceshipController
            (
                ShopTARpe25Context context,
                ISpaceshipServises spaceshipServices
            )
        {
            _context = context;
            _spaceshipServises = spaceshipServices;
        }
        public async Task<IActionResult> Index()
        {
            var result = _context.Spaceships
                .Select(x => new SpaceshipIndexViewModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    Classification = x.Classification,
                    BuildTime = x.BuildTime,
                    Crew = x.Crew,
                    EnginePower = x.EnginePower
                });

            return View(result);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(SpaceshipCreateViewModel vm)
        {

            var dto = new SpaceshipDto
            {
                Id = vm.Id,
                Name = vm.Name,
                Classification = vm.Classification,
                BuildTime = vm.BuildTime,
                Crew = vm.Crew,
                EnginePower = vm.EnginePower
            };


            var result = await _spaceshipServises.Create(dto);

            return RedirectToAction(nameof(Index));
        }


        [HttpGet]
        public async Task<IActionResult> Details(Guid id)
        {
            //meetodi kutsumine interfacest
            var spaceship = await _spaceshipServises.DetailsAsync(id);

            //veakäsitlus
            //suunab vaatele NotFound, kui andmeid ei ole
            if (spaceship == null)
            {
                return NotFound();
            }

            var vm = new SpaceshipDetailsViewModel();

            vm.Id = spaceship.Id;
            vm.Name = spaceship.Name;
            vm.Classification = spaceship.Classification;
            vm.BuiltDate = spaceship.BuildTime;
            vm.Crew = spaceship.Crew;
            vm.EnginePower = spaceship.EnginePower;
            vm.CreatedAt = spaceship.CreatedAt;
            vm.ModifiedAt = spaceship.ModifiedAt;

            return View(vm);
        }

        [HttpGet]
        public async Task<IActionResult> Update(Guid id)
        {
            var spaceship = await _spaceshipServises.DetailsAsync(id);

            if (spaceship == null)
            {
                return NotFound();
            }

            var vm = new SpaceshipUpdateViewModel();

            vm.Id = spaceship.Id;
            vm.Name = spaceship.Name;
            vm.Classification = spaceship.Classification;
            vm.BuiltDate = spaceship.BuildTime;
            vm.Crew = spaceship.Crew;
            vm.EnginePower = spaceship.EnginePower;
            vm.CreatedAt = spaceship.CreatedAt;
            vm.ModifiedAt = spaceship.ModifiedAt;

            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> Update(SpaceshipUpdateViewModel vm)
        {
            var dto = new SpaceshipDto()
            {
                Id = vm.Id,
                Name = vm.Name,
                Classification = vm.Classification,
                Crew = vm.Crew,
                EnginePower = vm.EnginePower,
                BuildTime = vm.BuiltDate,
                CreatedAt = vm.CreatedAt,
                ModifiedAt = vm.ModifiedAt
            };

            var result = await _spaceshipServises.Update(dto);

            if (result == null)
            {
                return RedirectToAction(nameof(Index));
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Delete(Guid id)
        {
            var spaceship = await _spaceshipServises.DetailsAsync(id);

            if (spaceship == null)
            {
                return NotFound();
            }

            var vm = new SpaceshipDeleteViewModel();

            vm.Id = spaceship.Id;
            vm.Name = spaceship.Name;
            vm.Classification = spaceship.Classification;
            vm.BuiltDate = spaceship.BuildTime;
            vm.Crew = spaceship.Crew;
            vm.EnginePower = spaceship.EnginePower;
            vm.CreatedAt = spaceship.CreatedAt;
            vm.ModifiedAt = spaceship.ModifiedAt;

            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteConfirmation(Guid id)
        {
            var result = await _spaceshipServises.Delete(id);

            if (result == null)
            {
                return RedirectToAction(nameof(Index));
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
