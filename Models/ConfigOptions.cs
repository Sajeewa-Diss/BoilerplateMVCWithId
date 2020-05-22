using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BoilerplateMVCWithId.Models
{
    public class ConfigOptions
    {
        public string BackgroundColor { get; set; }
        public int ItemsPerPage { get; set; }
        public bool ShowHeader { get; set; }

        // this property will not be overridden by ConfigEntity
        public string ApiKey { get; set; }
    }
}
