﻿using Common.Infrastructure.Extensions.Logging;
using Microsoft.Extensions.Hosting;
using Serilog;

namespace Common.Infrastructure.Extensions
{
    /// <summary>Класс-расширение для <see cref="IHostBuilder"/></summary>
    public static class HostBuilderExtensions
    {
        /// <summary>Логирование</summary>
        /// <param name="hostBuilder"><see cref="IHostBuilder"/></param>
        /// <returns><seealso cref="IHostBuilder"/></returns>
        public static IHostBuilder UseLogging(this IHostBuilder hostBuilder) =>
            hostBuilder.UseSerilog((context, configuration) =>
            {
                configuration.UseLogging(context.Configuration);
            });
    }
}