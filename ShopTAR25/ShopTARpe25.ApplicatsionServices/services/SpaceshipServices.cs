using ShopTARpe25.Core.Domain;
using ShopTARpe25.Core.Dto;
using ShopTARpe25.Data;

namespace ShopTARpe25.ApplicatsionServices.services
{
    public class SpaceshipServices
    {
        private readonly ShopTARpe25Context _context;

        public SpaceshipServices
            (
                ShopTARpe25Context context
            )
        {
            _context = context;
        }

        public async Task<Spaceship> Create(SpaceshipDto dto)
        {
            Spaceship domain = new();

            domain.Id = dto.Id;
            domain.Name = dto.Name;
            domain.Classification = dto.Classification;
            domain.BuildTime = dto.BuildTime;
            domain.crew = dto.crew;
            domain.EnginePower = dto.EnginePower;
            domain.CreatedAt = dto.CreatedAt;
            domain.ModifiedAt = dto.ModifiedAt;

            await _context.spaceships.AddAsync(domain);
            await _context.SaveChangesAsync();

            return null;
        }
    }
}
