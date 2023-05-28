using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain
{
    public class AppInformation
    {
        public Guid Id  { get; set; }
        public string BackendFramework { get; set; }
        public string Pattern { get; set; }
    }
}