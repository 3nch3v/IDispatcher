namespace Dispatcher.Web.Infrastructure
{
    public static class PermissionsValidator
    {
        public static bool HasPermission(string creatorId, string loggedInUserId, bool isAdmin)
        {
            if (!isAdmin && loggedInUserId != creatorId)
            {
                return false;
            }

            return true;
        }
    }
}
