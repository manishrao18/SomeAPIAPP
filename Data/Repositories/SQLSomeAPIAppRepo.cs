using System;
using System.Collections.Generic;
using System.Linq;
using SomeAPIAPP.Data.Contracts;
using SomeAPIAPP.Models;

namespace SomeAPIAPP.Data.Repositories
{
    public class SQLSomeAPIAppRepo : ISomeAPIAppRepo
    {
        private readonly SomeAPIContext _context;

        public SQLSomeAPIAppRepo(SomeAPIContext context)
        {
            _context = context;
        }

        public void AddAPIDetail(SomeAPIModel model)
        {
            if(model == null)
            {
                throw new ArgumentNullException(nameof(model));    
            }
            _context.SomeAPIs.Add(model);
        }

        public void DeleteAPIDetail(SomeAPIModel model)
        {
            if(model == null)
            {
                throw new ArgumentNullException(nameof(model));    
            }
            _context.SomeAPIs.Remove(model);
            //throw new NotImplementedException();
        }

        public IEnumerable<SomeAPIModel> GetAllAPIs()
        {
            return _context.SomeAPIs.ToList();
            //throw new System.NotImplementedException();
        }

        public SomeAPIModel GetAPIDetailByID(int id)
        {
            return _context.SomeAPIs.FirstOrDefault(p => p.ID == id);
            //throw new System.NotImplementedException();
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
            //throw new System.NotImplementedException();
        }

        public void UpdateAPIDetail(SomeAPIModel model)
        {
            
            //throw new NotImplementedException();
        }
    }
}