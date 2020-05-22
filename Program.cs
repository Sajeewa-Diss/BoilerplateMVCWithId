using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using BoilerplateMVCWithId.Models;
using Microsoft.EntityFrameworkCore.InMemory;

namespace BoilerplateMVCWithId
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args)
        { // =>
            var Dict = new Dictionary<string, string>  //new in-memory object 
                {
                   {"InMemoryKey", "InMemoryVal"},
                   {"InMemoryKey2:Subsection", "Dictionary_Title"}
                };

            return Host.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration((hostingContext, config) => 
                        {
                            config.AddJsonFile("MySubsection.json",  //add an extra configuration source using a new Json file.
                                optional: true,
                                reloadOnChange: true);
                            config.AddInMemoryCollection(Dict); //add an extra configuration source using in memory object above.
                            config.AddEFConfiguration(options => options.UseInMemoryDatabase("can-be-any-db-name1"));
                        })

                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                    //webBuilder.UseStartup<Startup>()
                    //.ConfigureAppConfiguration((hostingContext, config) => {
                    //    config.Add(new ConfigEntityConfigurationSource
                    //    {
                    //        OptionsAction = o => o.UseInMemoryDatabase("db", new InMemoryDatabaseRoot()),
                    //        ReloadOnChange = true
                    //    });
                    //});
                });
        }
        //public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>  //I think this is same as above.
        //    WebHost.CreateDefaultBuilder(args)
        //    .UseStartup<Startup>();
    }
}
