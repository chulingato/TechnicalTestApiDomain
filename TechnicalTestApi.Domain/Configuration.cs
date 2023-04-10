using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechnicalTestApi.Domain
{
    public class Configuration
    {
        public Guid configurationId {get; set;} 
        public string key { get; set;}  
        public string value { get; set;}
    }
}
