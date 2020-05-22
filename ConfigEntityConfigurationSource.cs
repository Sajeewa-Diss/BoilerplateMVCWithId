using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;


namespace BoilerplateMVCWithId
{
    public class ConfigEntityConfigurationSource : IConfigurationSource
    {
        public Action<DbContextOptionsBuilder> OptionsAction { get; set; }

        public bool ReloadOnChange { get; set; }

        // Number of milliseconds that reload will wait before calling Load. This helps avoid triggering a reload before a change is completely saved. Default is 500.
        public int ReloadDelay { get; set; } = 500;

        public IConfigurationProvider Build(IConfigurationBuilder builder)
        {
            return new ConfigEntityConfigurationProvider(this);
        }
    }
}
