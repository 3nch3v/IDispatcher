﻿namespace Dispatcher.Services.Data.Dtos
{
    using System.Collections.Generic;

    public class AdminRequestDataDto
    {
        public IEnumerable<SearchDataDto> Data { get; set; }

        public string DataType { get; set; }
    }
}
