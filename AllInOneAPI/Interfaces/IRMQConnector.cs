using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AllInOneAPI.Interfaces
{
    public interface IRMQConnector
    {
        void InitRabbitMQ();

        bool PublishMessage(List<KeyValuePair<string, string>> imageDetailsForPikleGeneration);
    }
}
