namespace Dispatcher.Data.Models.MessengerModels
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using Dispatcher.Data.Common.Models;

    public class Group : BaseDeletableModel<int>
    {
        public Group()
        {
            this.UsersGroups = new HashSet<UserGroup>();
        }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        public virtual ICollection<UserGroup> UsersGroups { get; set; }
    }
}
