namespace Dispatcher.Data.Models.ForumModels
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using Dispatcher.Data.Common.Models;

    public class Category : BaseDeletableModel<int>
    {
        public Category()
        {
            this.Discussions = new HashSet<Discussion>();
        }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        public IEnumerable<Discussion> Discussions { get; set; }
    }
}
