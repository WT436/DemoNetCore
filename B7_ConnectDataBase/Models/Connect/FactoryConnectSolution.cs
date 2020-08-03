using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace B7_ConnectDataBase.Models.Connect
{
    //public class FactoryConnectSolution : IDesignTimeDbContextFactory<XaHuyenTinhContext>
    //{
    //    //public XaHuyenTinhContext CreateDbContext(string[] args)
    //    //{
    //    //    // EF Core uses this method at design time to access the DbContext
    //    //    IConfigurationRoot configuration = new ConfigurationBuilder()
    //    //                                        .SetBasePath(Directory.GetCurrentDirectory())
    //    //                                        .AddJsonFile("appsettings.json")
    //    //                                        .Build();

    //    //    var connectionString = configuration.GetConnectionString("ConnectDatabaseContextString");
    //    //    var optionsBuilder = new DbContextOptionsBuilder<XaHuyenTinhContext>();
    //    //    optionsBuilder.UseSqlServer(connectionString);

    //    //    return new XaHuyenTinhContext(optionsBuilder.Options);
    //    //}
    //}
}