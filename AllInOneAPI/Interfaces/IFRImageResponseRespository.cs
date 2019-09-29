using AllInOneAPI.Infrastructure;
using AllInOneAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AllInOneAPI.Interfaces
{
    public interface IFRImageResponseRespository
    {
        Task AddFRResponseDetail(FRResponseDetail item);
        Task<IEnumerable<FRResponseDetail>> GetAllFRResponseDetail();
        Task<bool> RemoveAllImageResponseDetails();
        Task<string> CreateIndex();
    }
}
