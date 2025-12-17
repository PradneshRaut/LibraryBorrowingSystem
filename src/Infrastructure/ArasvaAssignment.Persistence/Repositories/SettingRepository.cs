using ArasvaAssignment.Application.Contracts.Persistence;
using ArasvaAssignment.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace ArasvaAssignment.Persistence.Repositories
{
    public class SettingRepository : ISettingRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;
        public SettingRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
        public async Task<int> GetBorrowingDurationAsync()
        {
            var value = await _applicationDbContext.Settings
              .Where(s => s.KeyName == "BorrowingDuration")
              .Select(s => s.Value)
              .FirstOrDefaultAsync();

            return int.TryParse(value, out var days) ? days : 7;
        }

        
    }
}
