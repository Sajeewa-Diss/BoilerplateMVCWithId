using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using BoilerplateMVCWithId.Models;
using BoilerplateMVCWithId.Data;

namespace BoilerplateMVCWithId
{
    public class ConfigEntityConfigurationProvider : ConfigurationProvider
    {
        private readonly ConfigEntityConfigurationSource _source;

        public ConfigEntityConfigurationProvider(ConfigEntityConfigurationSource source)
        {
            _source = source;
        }

        //public override void Load()
        //{
        //    var builder = new DbContextOptionsBuilder<ApplicationDbContext>();
        //    _source.OptionsAction(builder);

        //    using (var context = new ApplicationDbContext(builder.Options))
        //    {
        //        context.Database.EnsureCreated();

        //        var config = context.ConfigEntity.SingleOrDefault();
        //        if (config == null) return;

        //        Data = new Dictionary<string, string>();
        //        Data.Add($"{nameof(ConfigOptions)}.{nameof(ConfigOptions.BackgroundColor)}", config.BackgroundColor);
        //        Data.Add($"{nameof(ConfigOptions)}.{nameof(ConfigOptions.ItemsPerPage)}", config.ItemsPerPage);
        //        Data.Add($"{nameof(ConfigOptions)}.{nameof(ConfigOptions.ShowHeader)}", config.ShowHeader);
        //    }
        //}
    }
}
