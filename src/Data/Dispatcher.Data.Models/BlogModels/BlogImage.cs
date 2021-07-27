namespace Dispatcher.Data.Models.BlogModels
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using Dispatcher.Data.Common.Models;

    using static Dispatcher.Common.GlobalConstants.Data;

    public class BlogImage : BaseDeletableModel<string>
    {
        public BlogImage()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        [MaxLength(UrlMaxLenght)]
        public string Extension { get; set; }

        public int BlogId { get; set; }

        public virtual Blog Blog { get; set; }
    }
}
