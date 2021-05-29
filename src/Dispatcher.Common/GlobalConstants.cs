namespace Dispatcher.Common
{
    public static class GlobalConstants
    {
        public const string SystemName = "Dispatcher";

        public const string AdministratorRoleName = "Administrator";

        public const string Like = "Like";

        public const string Dislike = "Dislike";

        public const int JobBodyMinLength = 100;

        public const int AdsPageEntitiesCount = 9;

        public const int DefaultPageNumber = 1;

        public const int JobsPageEntitiesCount = 10;

        public const int BlogPageEntitiesCount = 10;

        public const int ForumPageEntitiesCount = 5;

        public const int BlogBodyMinLength = 100;

        public const int DiscussionDescriptionMinLength = 50;

        public const string YouTubeRegexPattern = @"^<iframe width=""[0-9]+"" height=""[0-9]+"" src=""https:\/\/www\.youtube\.[a-z]{2,}\/embed\/[A-z0-9]+"" title=""YouTube video player"" frameborder=""0"" allow=""accelerometer; autoplay; clipboard-write; encrypted-media; gyroscope; picture-in-picture"" allowfullscreen><\/iframe>$";

        public static readonly string[] AllowedPictureTypes = { ".jpg", ".jpeg", ".png", ".gif", ".bmp" };
    }
}
