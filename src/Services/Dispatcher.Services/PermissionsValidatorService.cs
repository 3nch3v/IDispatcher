namespace Dispatcher.Services
{
    using System.Threading.Tasks;

    using Dispatcher.Data.Models;
    using Dispatcher.Services.Contracts;
    using Microsoft.AspNetCore.Identity;

    using static Dispatcher.Common.GlobalConstants.User;

    public class PermissionsValidatorService : IPermissionsValidatorService
    {
        private readonly UserManager<ApplicationUser> userManager;

        public PermissionsValidatorService(UserManager<ApplicationUser> userManager)
        {
            this.userManager = userManager;
        }

        public async Task<bool> HasPermission(string creatorId, string loggedInUserId)
        {
            var user = await this.userManager.FindByIdAsync(loggedInUserId);
            var isInRole = await this.userManager.IsInRoleAsync(user, AdministratorRole);

            if (!isInRole && user.Id != creatorId)
            {
                return false;
            }

            return true;
        }
    }
}
