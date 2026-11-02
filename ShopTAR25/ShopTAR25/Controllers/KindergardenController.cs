using Microsoft.AspNetCore.Mvc;
using ShopTAR25.Models.Kindergarden;
using ShopTARpe25.Core.Dto;
using ShopTARpe25.Core.ServiceInterface;
using ShopTARpe25.Data;


namespace ShopTAR25.Controllers
{
    public class KindergardenController : Controller
    {
        private readonly IKindergardenServises _KindergardenServises;
        private readonly ShopTARpe25Context _context;

        public KindergardenController
            (
                IKindergardenServises kindergardenServises,
                ShopTARpe25Context context
            )
        {
            _KindergardenServises = kindergardenServises;
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var result = _context.Kindergardens
                .Select(x => new KindergardenIndexViewModel
                {
                    Id = x.Id,
                    GroupName = x.GroupName,
                    ChildrenCount = x.ChildrenCount,
                    KindergartenName = x.KindergartenName,
                    TeacherName = x.TeacherName,
                });
            return View(result);
        }
        [HttpGet]
        public IActionResult Create()
        {
            KindergardenCreateUpdateViewModel vm = new();

            return View("CreateUpdate", vm);
        }

        [HttpPost]
        public async Task<IActionResult> Create(KindergardenCreateUpdateViewModel vm)
        {
            var dto = new KindergardenDto
            {
                Id = vm.Id,
                GroupName = vm.GroupName,
                ChildrenCount = vm.ChildrenCount,
                KindergartenName = vm.KindergartenName,
                TeacherName = vm.TeacherName,
            };

            var result = await _KindergardenServises.Create(dto);

            if (result == null)
            {
                return RedirectToAction(nameof(Index));
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Details(Guid Id)
        {
            var kindergarden = await _KindergardenServises.DetailsAsync(Id);

            if (kindergarden == null)
            {
                return NotFound();
            }

            var vm = new KindergardenDetailsViewModel();

            vm.Id = kindergarden.Id;
            vm.GroupName = kindergarden.GroupName;
            vm.ChildrenCount = kindergarden.ChildrenCount;
            vm.KindergartenName = kindergarden.KindergartenName;
            vm.TeacherName = kindergarden.TeacherName;
            vm.CreatedAt = kindergarden.CreatedAt;
            vm.UpdatedAt = kindergarden.UpdatedAt;
           
            return View(vm);
        }

        [HttpGet]
        public async Task<IActionResult> Update(Guid Id) 
        {
            var kindergarden = await _KindergardenServises.DetailsAsync(Id);

            if (kindergarden == null)
            {
                return NotFound();
            }

            var vm = new KindergardenCreateUpdateViewModel();

            vm.Id = kindergarden.Id;
            vm.GroupName = kindergarden.GroupName;
            vm.ChildrenCount = kindergarden.ChildrenCount;
            vm.KindergartenName = kindergarden.KindergartenName;
            vm.TeacherName = kindergarden.TeacherName;
            vm.CreatedAt = kindergarden.CreatedAt;
            vm.UpdatedAt = kindergarden.UpdatedAt;

            return View(vm);
        }
        [HttpPost]
        public async Task<IActionResult> Update(KindergardenCreateUpdateViewModel vm)
        {
            var dto = new KindergardenDto
            {
                Id = vm.Id,
                GroupName = vm.GroupName,
                ChildrenCount = vm.ChildrenCount,
                KindergartenName = vm.KindergartenName,
                TeacherName = vm.TeacherName,
            };

            var result = await _KindergardenServises.Update(dto);

            if (result == null)
            {
                return RedirectToAction(nameof(Index));
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Delete(Guid Id) 
        {
            var kindergarden = await _KindergardenServises.DetailsAsync(Id);

            if (kindergarden == null)
            {
                return NotFound();
            }

            var vm = new KindergardenDeleteViewModel();

            vm.Id = kindergarden.Id;
            vm.GroupName = kindergarden.GroupName;
            vm.ChildrenCount = kindergarden.ChildrenCount;
            vm.KindergartenName = kindergarden.KindergartenName;
            vm.TeacherName = kindergarden.TeacherName;
            vm.CreatedAt = kindergarden.CreatedAt;
            vm.UpdatedAt = kindergarden.UpdatedAt;

            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteConfirmation(Guid id)
        {
            var result = await _KindergardenServises.Delete(id);

            if (result == null)
            {
                return RedirectToAction(nameof(Index));
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
