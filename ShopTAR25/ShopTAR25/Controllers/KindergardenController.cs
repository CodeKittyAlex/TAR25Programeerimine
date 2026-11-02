using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShopTAR25.Models.Kindergarden;
using ShopTARpe25.Data.Migrations;
using ShopTARpe25.Core.Dto;
using ShopTARpe25.Core.ServiceInterface;
using ShopTARpe25.Data;


namespace ShopTAR25.Controllers
{
    public class KindergardenController : Controller
    {
        private readonly shopTARpe25Context _context;

        public KindergardenController
            (
                shopTARpe25Context context
            )
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var result = _context.Kindergardens
                .select(x => new KindergardenIndexViewModel
                {
                    Id = x.Id,
                    GroupName = x.GroupName,
                    ChildrenCount = x.ChildrenCount,
                    KindergartenName = x.KindergartenName,
                    TeacherName = x.TeacherName,
                });
            return View(result);
        }
    }
}
