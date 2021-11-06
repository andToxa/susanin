using Application.Common.Events;
using Application.Common.Extensions;
using Application.Example.Commands;
using Application.Example.Events;
using Application.Example.Queries;
using Domain.Example.Events;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Example.Extensions
{
    /// <summary>Класс-расширение для <see cref="IServiceCollection"/></summary>
    public static class ServiceCollectionExtensions
    {
        /// <summary>Добавление сервисов уровня приложения</summary>
        /// <param name="services"><see cref="IServiceCollection"/></param>
        /// <param name="configuration"><see cref="IConfiguration"/></param>
        /// <returns><seealso cref="IServiceCollection"/></returns>
        public static IServiceCollection AddApplication(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddApplicationCommon(configuration);

            // обработчики команд
            services.AddScoped<IRequestHandler<ExampleCommand, Unit>, ExampleCommandHandler>();

            // обработчики запросов
            services.AddScoped<IRequestHandler<ExampleQuery, ExampleQueryResult>, ExampleQueryHandler>();

            // обработчики событий
            services.AddScoped<INotificationHandler<Event<ExampleEvent>>, ExampleEventHandler>();

            return services;
        }
    }
}