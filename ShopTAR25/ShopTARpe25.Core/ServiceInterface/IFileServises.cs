using ShopTARpe25.Core.Domain;
using ShopTARpe25.Core.Dto;

namespace ShopTARpe25.Core.ServiceInterface
{
    public interface IFileServices
    {
        void FilesToApi(SpaceshipDto dto, Spaceship domain);
        Task<FileToApi> RemoveImageFromApi(FileToApiDto dto);
        Task<List<FileToApi>> RemoveImagesFromApi(FileToApiDto[] dto);

        void FilesToApiK(KindergardenDto dto, Kindergarden domain);
        Task<FileToApi> RemoveImageFromApiK(FileToApiDto dto);
        Task<List<FileToApi>> RemoveImagesFromApiK(FileToApiDto[] dto);
    }
}