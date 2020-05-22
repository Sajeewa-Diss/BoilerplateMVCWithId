using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BoilerplateMVCWithId.Models
{
    public class PositionOptions //this POCO class will only ever hold one variable at a time - not designed as a table row.
    {
        public string Title { get; set; }
        public string Name { get; set; }
    }
}
