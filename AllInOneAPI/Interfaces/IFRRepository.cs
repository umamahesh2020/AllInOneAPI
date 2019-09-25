using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AllInOneAPI.Models;

namespace AllInOneAPI.Interfaces
{
    public interface IFRRepository
    {

        Task AddFREnrollerDetails(EnrollerDetail item);


        Task<string> CreateIndex();


        Task<IEnumerable<EnrollerDetail>> GetAllEnrollerDetails();


        Task<EnrollerDetail> GetEnrollerDetail(string id);


        Task<IEnumerable<EnrollerDetail>> GetEnrollerDetail(string bodyText, DateTime updatedFrom, long headerSizeLimit);


        Task<bool> RemoveAllEnrollerDetails();


        Task<bool> RemoveEnrollerDetail(string id);


        Task<bool> UpdateEnrollerDetail(string id, string body);

        Task<bool> UpdateEnrollerDetailDocument(string id, string body);
    }
}
