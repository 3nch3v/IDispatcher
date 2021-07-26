namespace Dispatcher.Common
{
    public static class GlobalConstants
    {
        public const string SystemName = "Dispatcher";

        public const string EmptyBody = "The description can not be white space!";

        public static class Advertisement
        {
            public const int TitleMaxLength = 100;

            public const int TitleMinLength = 3;

            public const int DescriptionMaxLength = 5000;

            public const int DescriptionMinLength = 100;

            public const int CompensationMaxLenght = 50;
        }

        public static class Attributes
        {
            public const string YouTubeRegexPattern = @"^<iframe width=""[0-9]+"" height=""[0-9]+"" src=""https:\/\/www\.youtube\.[a-z]{2,}\/embed\/[A-z0-9]+"" title=""YouTube video player"" frameborder=""0"" allow=""accelerometer; autoplay; clipboard-write; encrypted-media; gyroscope; picture-in-picture"" allowfullscreen><\/iframe>$";

            public const string YouTubeError = "Please enter valid YouTube embed code!";

            public static readonly string[] AllowedPictureTypes = { ".jpg", ".jpeg", ".png", ".gif", ".bmp" };
        }

        public static class Blog
        {
            public const string BlogPicturePath = "/img/blog-pictures";

            public const int TitleMaxLength = 100;

            public const int TitleMinLength = 2;

            public const int BodyMaxLength = 10000;

            public const int BodyMinLength = 100;

            public const int CategoryMaxLenght = 50;
        }

        public static class File
        {
            public const int UrlMaxLenght = 2048;

            public const int ExtensionMaxLenght = 5;

            public const int FileMaxLenght = 2048;

            public const int FileMaxSize = 5 * 1024 * 1024;
        }

        public static class Forum
        {
            public const string Like = "Like";

            public const string Dislike = "Dislike";

            public const string Unsolved = "Unsolved";

            public const int DescriptionMinLenght = 50;

            public const int DescriptionMAxLenght = 5000;

            public const int CommentMinLenght = 2;

            public const int CommentMaxLenght = 5000;

            public const int TitleMinLenght = 3;

            public const int TitleMaxLenght = 100;
        }

        public static class Job
        {
            public const int TitleMaxLength = 150;

            public const int TitleMinLength = 3;

            public const int BodyMaxLength = 50000;

            public const int BodyMinLength = 100;

            public const int CompanyMaxLength = 50;

            public const int CompanyMinLength = 2;

            public const int LocationMaxLength = 50;

            public const int LocationMinLength = 3;

            public const int ContactMaxLength = 250;

            public const int ContactMinLength = 6;
        }

        public static class Project
        {
            public const int NameMinLenght = 3;

            public const int NameMaxLenght = 100;

            public const int RoleMinLenght = 3;

            public const int RoleMaxLenght = 100;

            public const int DescriptionMinLenght = 3;

            public const int DescriptionMaxLenght = 500;
        }

        public static class PageEntities
        {
            public const int AdsCount = 8;

            public const int DefaultPageNumber = 1;

            public const int JobsCount = 10;

            public const int BlogsCount = 5;

            public const int ForumCount = 5;
        }

        public static class User
        {
            public const string AdministratorRole = "Administrator";

            public const string UserRole = "User";

            public const string ProfilePicturePath = "/img/profile-pictures";

            public const string DefaultAvatarPath = "/img/3_avatar-512.png";

            public const string UnableToLoadUser = "Unable to load user with ID";

            public const string UpdatedSuccessfully = "Your profile has been updated";

            public const string PhoneError = "Unexpected error when trying to set phone number.";

            public const string LoggedInConfirmation = "User logged in.";

            public const string LockedOut = "User account locked out.";

            public const string InvalidLoginAttemt = "Invalid login attempt.";

            public const string InvalidUsernameOrEmail = "The selected username or email is not available.";

            public const int CommentMinLenght = 3;

            public const int CommentMaxLenght = 500;

            public const int MinStars = 1;

            public const int MaxStars = 5;

            public const int NameMinLenght = 2;

            public const int NameMaxLenght = 50;

            public const int EducationMinLenght = 2;

            public const int EducationMaxLenght = 50;

            public const int InterestMinLenght = 2;

            public const int InterestMaxLenght = 100;

            public const int ContactMinLenght = 6;

            public const int ContactMaxLenght = 200;
        }
    }
}
