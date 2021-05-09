﻿namespace Dispatcher.Web.ViewModels.JobModels
{
    using Dispatcher.Data.Models.AdvertisementModels;
    using Dispatcher.Services.Mapping;

    public class JobInputModel : BaseJobInputModel, IMapTo<Job>
    {
    }
}
