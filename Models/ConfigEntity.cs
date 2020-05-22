using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BoilerplateMVCWithId.Models
{
    public class ConfigEntity
    {
        public string BackgroundColor { get; set; }
        public int ItemsPerPage { get; set; }
        public bool ShowHeader { get; set; }
    }
}
