using Microsoft.EntityFrameworkCore;
using ShopTARpe25.Core.Domain;
using ShopTARpe25.Core.Dto;
using ShopTARpe25.Core.ServiceInterface;
using ShopTARpe25.Data;

namespace ShopTARpe25.ApplicatsionServices.services
{
    public class KindergardenServises : IKindergardenServises
    {
        private readonly ShopTARpe25Context _context;
        private readonly IFileServices _fileServices;

        public KindergardenServises
            (
                ShopTARpe25Context context,
                IFileServices fileServices
            )
        {
            _context = context;
            _fileServices = fileServices;
        }
        public async Task<Kindergarden> Create(KindergardenDto dto)
        {
            Kindergarden domain = new();

            domain.Id = dto.Id;
            domain.GroupName = dto.GroupName;
            domain.ChildrenCount = dto.ChildrenCount;
            domain.KindergartenName = dto.KindergartenName;
            domain.TeacherName = dto.TeacherName;
            domain.CreatedAt = dto.CreatedAt;
            domain.UpdatedAt = dto.UpdatedAt;
            //_fileServices.FilesToApi(dto, domain);

            await _context.Kindergardens.AddAsync(domain);
            await _context.SaveChangesAsync();

            return domain;
        }
        public async Task<Kindergarden> DetailsAsync(Guid id)
        {
            var result = await _context.Kindergardens
                .FirstOrDefaultAsync(x => x.Id == id);

            return result;
        }

        public async Task<Kindergarden> Update(KindergardenDto dto)
        {
            Kindergarden Kindergarden = new();

            Kindergarden.Id = dto.Id;
            Kindergarden.GroupName = dto.GroupName;
            Kindergarden.ChildrenCount = dto.ChildrenCount;
            Kindergarden.KindergartenName = dto.KindergartenName;
            Kindergarden.TeacherName = dto.TeacherName;
            Kindergarden.CreatedAt = dto.CreatedAt;
            Kindergarden.UpdatedAt = DateTime.Now;
            //_fileServices.FilesToApi(dto, Kindergarden);

            _context.Kindergardens.Update(Kindergarden);
            await _context.SaveChangesAsync();

            return Kindergarden;
        }

        public async Task<Kindergarden> Delete(Guid id)
        {
            var result = await _context.Kindergardens
                .FirstOrDefaultAsync(x => x.Id == id);

            var images = await _context.FileToApis
                .Where(x => x.KindergardenId == id)
                .Select(y => new FileToApiDto
                {
                    Id = y.Id,
                    KindergardenId = y.KindergardenId,
                    ExistingFilePath = y.ExistingFilePath,
                }).ToArrayAsync();

            await _fileServices.RemoveImagesFromApi(images);
            _context.Kindergardens.Remove(result);
            await _context.SaveChangesAsync();

            return result;
        }
    }
}
