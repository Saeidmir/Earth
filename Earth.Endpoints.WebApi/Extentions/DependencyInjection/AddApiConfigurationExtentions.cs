﻿using Earth.Endpoints.WebApi.Middlewares.ApiExceptionHandler;
using Microsoft.Data.SqlClient;
using FluentValidation;
using FluentValidation.AspNetCore;

namespace Earth.Endpoints.WebApi.Extentions.DependencyInjection;

public static class AddApiConfigurationExtentions
{
    public static IServiceCollection AddProjectApiCore(this IServiceCollection services, params string[] assemblyNamesForLoad)
    {
        services.AddControllers(options =>
        {
           // options.Filters.Add(typeof(TrackActionPerformanceFilter));
        }).AddFluentValidation();
        services.AddProjectDependencies(assemblyNamesForLoad);
        return services;
    }


    public static void UseZaminApiExceptionHandler(this IApplicationBuilder app)
    {
        app.UseApiExceptionHandler(options =>
        {
            options.AddResponseDetails = (context, ex, error) =>
            {
                if (ex.GetType().Name == typeof(SqlException).Name)
                {
                    error.Detail = "Exception was a database exception!";
                }
            };
            options.DetermineLogLevel = ex =>
            {
                if (ex.Message.StartsWith("cannot open database", StringComparison.InvariantCultureIgnoreCase) ||
                    ex.Message.StartsWith("a network-related", StringComparison.InvariantCultureIgnoreCase))
                {
                    return LogLevel.Critical;
                }
                return LogLevel.Error;
            };
        });

    }




}