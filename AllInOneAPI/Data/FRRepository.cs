using AllInOneAPI.Interfaces;
using AllInOneAPI.Models;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AllInOneAPI.Data
{
    public class FRRepository : IFRRepository
    {
        private readonly FRContext _context = null;

        public FRRepository(IOptions<Settings> settings)
        {
            _context = new FRContext(settings);
        }
        public async Task AddFREnrollerDetails(EnrollerDetail item)
        {
            try
            {
                await _context.FREnrollerDetail.InsertOneAsync(item);
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
                IndexKeysDefinition<EnrollerDetail> keys = Builders<EnrollerDetail>
                                                    .IndexKeys
                                                    .Ascending(item => item.UserId)
                                                    .Ascending(item => item.Body);

                return await _context.FREnrollerDetail
                                .Indexes.CreateOneAsync(new CreateIndexModel<EnrollerDetail>(keys));
            }
            catch (Exception ex)
            {
                // log or manage the exception
                throw ex;
            }
        }
    

        public async Task<IEnumerable<EnrollerDetail>> GetAllEnrollerDetails()
        {
            try
            {
                return await _context.FREnrollerDetail.Find(_ => true).ToListAsync();
            }
            catch (Exception ex)
            {
                // log or manage the exception
                throw ex;
            }
        }

        public async Task<EnrollerDetail> GetEnrollerDetail(string id)
        {
            try
            {
                ObjectId internalId = GetInternalId(id);
                return await _context.FREnrollerDetail
                                .Find(FREnrollerDetail => FREnrollerDetail.Id == id || FREnrollerDetail.InternalId == internalId)
                                .FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                // log or manage the exception
                throw ex;
            }
        }

        public async Task<IEnumerable<EnrollerDetail>> GetEnrollerDetail(string bodyText, DateTime updatedFrom, long headerSizeLimit)
        {
            try
            {
                var query = _context.FREnrollerDetail.Find(enroller => enroller.Body.Contains(bodyText) &&
                                       enroller.UpdatedOn >= updatedFrom);
                                       //&&
                                       //enroller.EImage.ImageSize <= headerSizeLimit);

                return await query.ToListAsync();
            }
            catch (Exception ex)
            {
                // log or manage the exception
                throw ex;
            }
        }

        public async Task<bool> RemoveAllEnrollerDetails()
        {
            try
            {
                DeleteResult actionResult = await _context.FREnrollerDetail.DeleteManyAsync(new BsonDocument());

                return actionResult.IsAcknowledged
                    && actionResult.DeletedCount > 0;
            }
            catch (Exception ex)
            {
                // log or manage the exception
                throw ex;
            }
        }

        public async Task<bool> RemoveEnrollerDetail(string id)
        {
            try
            {
                DeleteResult actionResult = await _context.FREnrollerDetail.DeleteOneAsync(
                     Builders<EnrollerDetail>.Filter.Eq("Id", id));

                return actionResult.IsAcknowledged
                    && actionResult.DeletedCount > 0;
            }
            catch (Exception ex)
            {
                // log or manage the exception
                throw ex;
            }
        }

        public async Task<bool> UpdateEnrollerDetail(string id, string body)
        {
            var filter = Builders<EnrollerDetail>.Filter.Eq(s => s.Id, id);
            var update = Builders<EnrollerDetail>.Update
                            .Set(s => s.Body, body)
                            .CurrentDate(s => s.UpdatedOn);

            try
            {
                UpdateResult actionResult = await _context.FREnrollerDetail.UpdateOneAsync(filter, update);

                return actionResult.IsAcknowledged
                    && actionResult.ModifiedCount > 0;
            }
            catch (Exception ex)
            {
                // log or manage the exception
                throw ex;
            }
        }

        public async Task<bool> UpdateEnrollerDetailDocument(string id, string body)
        {
            var item = await GetEnrollerDetail(id) ?? new EnrollerDetail();
            item.Body = body;
            item.UpdatedOn = DateTime.Now;

            return await UpdateEnrollerDetailDocument(id, item);
        }

        public async Task<bool> UpdateEnrollerDetailDocument(string id, EnrollerDetail item)
        {
            try
            {
                ReplaceOneResult actionResult = await _context.FREnrollerDetail.ReplaceOneAsync(n => n.Id.Equals(id), item , new UpdateOptions { IsUpsert = true });
                return actionResult.IsAcknowledged
                    && actionResult.ModifiedCount > 0;
            }
            catch (Exception ex)
            {
                // log or manage the exception
                throw ex;
            }
        }



        private ObjectId GetInternalId(string id)
        {
            if (!ObjectId.TryParse(id, out ObjectId internalId))
                internalId = ObjectId.Empty;

            return internalId;
        }
    }
}
