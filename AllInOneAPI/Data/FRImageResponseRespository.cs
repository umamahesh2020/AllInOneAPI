using AllInOneAPI.Interfaces;
using AllInOneAPI.Models;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AllInOneAPI.Data
{
    public class FRImageResponseRespository : IFRImageResponseRespository
    {
        private readonly FRImageResponseContexct _context = null;

        public FRImageResponseRespository(IOptions<Settings> settings)
        {
            _context = new FRImageResponseContexct(settings);
        }
        public Task AddFRResponseDetail(FRResponseDetail frResponseDetail)
        {
            try
            {
                try
                {
                    return _context.FRImageResponseDetail.InsertOneAsync(frResponseDetail);
                }
                catch (Exception ex)
                {
                    // log or manage the exception
                    throw ex;
                }

            }
            catch (Exception ex)
            {
                // log or manage the exception
                throw ex;
            }
        }

        public async Task<string> CreateIndex()
        {

            try
            {
                IndexKeysDefinition<FRResponseDetail> keys = Builders<FRResponseDetail>
                                                    .IndexKeys                                                  
                                                    .Ascending(item => item.Body);

                return await _context.FRImageResponseDetail.Indexes.CreateOneAsync(new CreateIndexModel<FRResponseDetail>(keys));
            }
            catch (Exception ex)
            {
                // log or manage the exception
                throw ex;
            }
        }


        public async Task<IEnumerable<FRResponseDetail>> GetAllFRResponseDetail()
        {
            try
            {
                return await _context.FRImageResponseDetail.Find(_ => true).ToListAsync();
            }
            catch (Exception ex)
            {
                // log or manage the exception
                throw ex;
            }
        }

        public async Task<bool> RemoveAllImageResponseDetails()
        {
            try
            {
                DeleteResult actionResult = await _context.FRImageResponseDetail.DeleteManyAsync(new BsonDocument());
                return actionResult.IsAcknowledged && actionResult.DeletedCount > 0;
            }
            catch (Exception ex)
            {
                // log or manage the exception
                throw ex;
            }
        }
    }
}
