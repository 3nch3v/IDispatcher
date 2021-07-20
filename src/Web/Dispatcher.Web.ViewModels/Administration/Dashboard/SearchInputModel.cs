namespace Dispatcher.Web.ViewModels.Administration.Dashboard
{
    using System.ComponentModel.DataAnnotations;

    using Dispatcher.Data.Models.Enums;

    public class SearchInputModel
    {
        [Required]
        [EnumDataType(typeof(RepositoriesDataTypes))]
        public string SearchData { get; set; }

        [Required]
        [EnumDataType(typeof(SearchMethod))]
        public string SearchMethod { get; set; }

        [Required]
        [MaxLength(150)]
        public string SearchTerm { get; set; }
    }
}
