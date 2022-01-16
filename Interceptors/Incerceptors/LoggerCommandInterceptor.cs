using Microsoft.EntityFrameworkCore.Diagnostics;
using System.Data.Common;

namespace Interceptors.Incerceptors
{
    internal class LoggerCommandInterceptor : DbCommandInterceptor
    {
        public override DbDataReader ReaderExecuted(DbCommand command, CommandExecutedEventData eventData, DbDataReader result)
        {
            Console.BackgroundColor = ConsoleColor.Green;
            Console.WriteLine($"Started {eventData.StartTime} {eventData.Command.CommandText} {eventData.Duration} ms");
            Console.ResetColor();

            return base.ReaderExecuted(command, eventData, result);
        }
    }
}
