namespace ThhTransTracker.Core.Interfaces.IRepositories
{
    public interface IUtilityRepository
    {
        Task<string> UploadFile(IFormFile formFile);
    }
}
