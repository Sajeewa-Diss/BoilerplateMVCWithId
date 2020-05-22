using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BoilerplateMVCWithId.Data;
using BoilerplateMVCWithId.Models;

namespace BoilerplateMVCWithId
{
    public class EFConfigurationProvider : ConfigurationProvider
    {    //a custom provider must inherit from ConfigurationProvider class
        public EFConfigurationProvider(Action<DbContextOptionsBuilder> optionsAction)
        {
            OptionsAction = optionsAction;
        }

        Action<DbContextOptionsBuilder> OptionsAction { get; }

        // Load config data from EF DB.
        public override void Load()
        {
            var builder = new DbContextOptionsBuilder<ApplicationDbContext>();

            OptionsAction(builder);

            using (var dbContext = new ApplicationDbContext(builder.Options))
            {
                dbContext.Database.EnsureCreated();  //create the DB if it is empty?

                Data = !dbContext.Values.Any()
                    ? CreateAndSaveDefaultValues(dbContext)   //what does this do??
                    : dbContext.Values.ToDictionary(c => c.Id, c => c.Value);
            }
        }

        private static IDictionary<string, string> CreateAndSaveDefaultValues(ApplicationDbContext dbContext)
        {
            // Quotes (c)2005 Universal Pictures: Serenity
            // https://www.uphe.com/movies/serenity
            var configValues = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase){  //because keys are case-insensitive
                { "quote1", "I aim to misbehave." },
                { "quote2", "I swallowed a bug." },
                { "quote3", "You can't stop the signal, Mal." }};

            dbContext.Values.AddRange(configValues
                .Select(kvp => new EFConfigurationValue
                {
                    Id = kvp.Key,
                    Value = kvp.Value
                }).ToArray());

            dbContext.SaveChanges();

            return configValues;
        }
    }
}
