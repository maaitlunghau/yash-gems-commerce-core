namespace YashGems.Commerce.Application.Interfaces
{
    public interface IPhotoService
    {
        Task<(string Url, string PublicId)> AddPhotoAsync(Stream stream, string fileName);
        Task<bool> DeletePhotoAsync(string publicId);
    }
}
