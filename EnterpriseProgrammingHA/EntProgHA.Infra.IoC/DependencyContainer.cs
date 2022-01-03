using EntProgHA.Application.Interfaces;
using EntProgHA.Application.Services;
using EntProgHA.Domain.Interfaces;
using EntProgHA.Infra.Data.Repository;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace EntProgHA.Infra.IoC
{
    public class DependencyContainer
    {
        public static void RegisterServices(IServiceCollection services)
        {
            //Application Layer
            services.AddScoped<IFileTransferService, FileTransferService>();

            //Data Layer
            services.AddScoped<IFileTransferRepository, FileTransferRepository>();
        }
    }
}
