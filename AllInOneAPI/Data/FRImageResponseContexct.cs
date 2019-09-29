using AllInOneAPI.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AllInOneAPI.Data
{
    public class FRImageResponseContexct
    {
        private readonly IMongoDatabase _database = null;
        public FRImageResponseContexct(IOptions<Settings> settings)
        {
            var client = new MongoClient(settings.Value.ConnectionString);
            if (client != null)
                _database = client.GetDatabase(settings.Value.DatabseFR);
        }

        public IMongoCollection<FRResponseDetail> FRImageResponseDetail
        {
            get
            {
                return _database.GetCollection<FRResponseDetail>("ImageResponseDetail");
            }
        }
    }
}
