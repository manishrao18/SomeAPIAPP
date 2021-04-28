using System.Collections.Generic;
using SomeAPIAPP.Models;

namespace SomeAPIAPP.Data.Contracts
{
    public interface ISomeAPIAppRepo
    {
        bool SaveChanges();
        IEnumerable<SomeAPIModel> GetAllAPIs();
        SomeAPIModel GetAPIDetailByID(int id);
        void AddAPIDetail(SomeAPIModel model);
        void UpdateAPIDetail(SomeAPIModel model);
        void DeleteAPIDetail(SomeAPIModel model);
    }
}