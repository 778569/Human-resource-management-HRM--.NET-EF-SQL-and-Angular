using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test_HRM.Application.PersisteanceInterfaces;

namespace Test_HRM.Persistence.Repositories
{
    public abstract class BaseRepository 
    {
        private readonly HRMDBContext _dBContext;

        public BaseRepository(HRMDBContext dBContext)
        {
            _dBContext = dBContext;
        }


        public async Task<int> SaveChangesAsync(CancellationToken token)
        {
            return await _dBContext.SaveChangesAsync(token);
        }
    }
}
