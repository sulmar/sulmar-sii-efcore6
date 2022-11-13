using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Logging;

namespace Interceptors.Incerceptors
{
    internal class DebugViewInterceptor : SaveChangesInterceptor
    {
        private readonly ILogger<DebugViewInterceptor> logger;

        public DebugViewInterceptor(ILogger<DebugViewInterceptor> logger)
	    {
            this.logger = logger;
	    }

        public override InterceptionResult<int> SavingChanges(DbContextEventData eventData, InterceptionResult<int> result)
        {
            if (eventData.LogLevel == LogLevel.Debug)
            {
                logger.LogDebug(eventData.Context.ChangeTracker.DebugView.LongView);
            }

            return base.SavingChanges(eventData, result);
        }
    }
}
