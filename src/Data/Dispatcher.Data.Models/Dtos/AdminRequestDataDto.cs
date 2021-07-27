namespace Dispatcher.Data.Models.Dtos
{
    using System.Collections.Generic;

    public class AdminRequestDataDto
    {
        public string DataType { get; set; }

        public IEnumerable<SearchDataDto> Data { get; set; }
    }
}
