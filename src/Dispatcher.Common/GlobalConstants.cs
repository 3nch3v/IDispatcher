namespace Dispatcher.Common
{
    public static class GlobalConstants
    {
        public const string SystemName = "Dispatcher";

        public const string Like = "Like";

        public const string Dislike = "Dislike";

        public const string Unsolved = "Unsolved";

        public const int DiscussionDescriptionMinLength = 50;

        public const int DefaultBodyStringMinLength = 100;

        public const string YouTubeRegexPattern = @"^<iframe width=""[0-9]+"" height=""[0-9]+"" src=""https:\/\/www\.youtube\.[a-z]{2,}\/embed\/[A-z0-9]+"" title=""YouTube video player"" frameborder=""0"" allow=""accelerometer; autoplay; clipboard-write; encrypted-media; gyroscope; picture-in-picture"" allowfullscreen><\/iframe>$";

        public static readonly string[] AllowedPictureTypes = { ".jpg", ".jpeg", ".png", ".gif", ".bmp" };

        public static class PageEntities
        {
            public const int AdsCount = 9;

            public const int DefaultPageNumber = 1;

            public const int JobsCount = 10;

            public const int BlogsCount = 10;

            public const int ForumCount = 5;
        }

        public static class User
        {
            public const string AdministratorRole = "Administrator";

            public const string UserRole = "User";

            public const string UnableToLoadUser = "Unable to load user with ID";

            public const string UpdatedSuccessfully = "Your profile has been updated";

            public const string ProfilePicturePath = "/img/profile-pictures";

            public const string PhoneError = "Unexpected error when trying to set phone number.";

            public const string LoggedInConfirmation = "User logged in.";

            public const string LockedOut = "User account locked out.";

            public const string InvalidLoginAttemt = "Invalid login attempt.";
        }
    }
}
