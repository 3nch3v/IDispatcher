namespace Dispatcher.Web.Tests
{
    using System;

    using Dispatcher.Data;
    using Microsoft.EntityFrameworkCore;

    public static class DataBaseMock
    {
        public static ApplicationDbContext Instance
        {
            get
            {
                var dbContextOptions = new DbContextOptionsBuilder<ApplicationDbContext>()
                    .UseInMemoryDatabase(Guid.NewGuid().ToString()).Options;

                return new ApplicationDbContext(dbContextOptions);
            }
        }
    }
}
