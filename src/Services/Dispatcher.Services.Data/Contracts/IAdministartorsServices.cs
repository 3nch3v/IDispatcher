namespace Dispatcher.Services.Data.Contracts
{
    using System.Threading.Tasks;

    using Dispatcher.Services.Data.Dtos;

    public interface IAdministartorsServices
    {
        AdminIndexDto GetIndexData();

        Task DeleteUserAsync(string id);

        Task DeleteReviewAsync(int id);

        AdminRequestDataDto GetData(string searchData, string searchMethod, string searchTerm);
    }
}
