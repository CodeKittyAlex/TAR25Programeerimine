using ShopTAR25.Models.Spaceship;
using ShopTARpe25.Core.Dto;

namespace ShopTAR25.Models.Kindergarden
{
    public class KindergardenCreateUpdateViewModel
    {
        public Guid? Id { get; set; }
        public string GroupName { get; set; }
        public int? ChildrenCount { get; set; }
        public string KindergartenName { get; set; }
        public string TeacherName { get; set; }

        public List<IFormFile> Files { get; set; }
        public List<ImageViewModel> Image { get; set; }
            = new List<ImageViewModel>();

        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
