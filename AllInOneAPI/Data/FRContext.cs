using AllInOneAPI.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace AllInOneAPI.Data
{
    public class FRContext
    {
        private readonly IMongoDatabase _database = null;

        public FRContext(IOptions<Settings> settings)
        {
            var client = new MongoClient(settings.Value.ConnectionString);
            if (client != null)
                _database = client.GetDatabase(settings.Value.DatabseFR);
        }

        public IMongoCollection<EnrollerDetail> FREnrollerDetail
        {
            get
            {
                return _database.GetCollection<EnrollerDetail>("EnrollerDetail");
            }
        }
    }
}
