using AutoMapper;
using CoreWebhook.Core;
using Microsoft.Extensions.Logging;

namespace CoreWebhook.Infrastructure
{
    public class UnitOfWork : IUnitOfWork,IDisposable
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger _logger;
        private readonly IMapper _mapper;
        public UnitOfWork(ApplicationDbContext context,ILoggerFactory logger,IMapper mapper) 
        {
            _context= context;
            _logger = logger.CreateLogger("logs");
            _mapper = mapper;
            
        }

        

        public async Task CompleteAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
