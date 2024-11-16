using Metricas.Data;
using Metricas.Models;
using System;
using System.Threading.Tasks;

namespace Metricas.Services
{
    public class LogService
    {
        private readonly AppDbContext _context;

        public LogService(AppDbContext context)
        {
            _context = context;
        }

        public async Task LogEventAsync(string eventType, string action, bool isError, int? userId, string details)
        {
            var log = new Log
            {
                Timestamp = DateTime.Now,
                EventType = eventType,
                Action = action,
                IsError = isError,
                UserId = userId,
                Details = details
            };

            _context.Logs.Add(log);
            await _context.SaveChangesAsync();
        }
    }
}
