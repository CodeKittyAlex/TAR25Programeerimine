using ShopTARpe25.Core.Domain;
using ShopTARpe25.Core.Dto;


namespace ShopTARpe25.Core.ServiceInterface
{
    public interface IKindergardenServises
    {
        Task<Kindergarden> Create(KindergardenDto dto);
        Task<Kindergarden> DetailsAsync(Guid id);
        Task<Kindergarden> Update(KindergardenDto dto);
        Task<Kindergarden> Delete(Guid id);
    }
}
