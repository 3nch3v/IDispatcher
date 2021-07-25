namespace Dispatcher.Services.Data.Contracts
{
    using System.Threading.Tasks;

    using Dispatcher.Data.Models.Dtos;

    public interface IAdministartorsServices
    {
        AdminIndexDto GetIndexData();

        AdminRequestDataDto GetData(string searchData, string searchMethod, string searchTerm);

        Task DeleteUserAsync(string id);

        Task DeleteReviewAsync(int id);
    }
}
