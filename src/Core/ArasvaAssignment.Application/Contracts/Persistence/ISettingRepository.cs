using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArasvaAssignment.Application.Contracts.Persistence
{
    public interface ISettingRepository
    {
        Task<int> GetBorrowingDurationAsync(); 
    }
}
