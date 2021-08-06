namespace Dispatcher.Web.ViewModels.AdModels
{
    using System;
    using System.Collections.Generic;

    using static Dispatcher.Common.GlobalConstants;

    public class AllAdvertisementsViewModel
    {
        public int PageEntitiesCount => PageEntities.AdsCount;

        public int PagesCount => (int)Math.Ceiling(this.AdvertisementsCount * 1.0 / this.PageEntitiesCount);

        public int Page { get; set; }

        public bool HasPreviousPage => this.Page > 1;

        public int PreviousPage => this.Page - 1;

        public bool HasNextPage => this.Page < this.PagesCount;

        public int NextPage => this.Page + 1;

        public int AdvertisementsCount { get; set; }

        public IEnumerable<AdvertisementViewModel> Advertisements { get; set; }
    }
}
