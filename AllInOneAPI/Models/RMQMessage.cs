using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AllInOneAPI.Models
{
    public class RMQMessage
    {
        public List<KeyValuePair<string, string>> ImageDetailsForPikleGeneration { get; set; }
    }
}
