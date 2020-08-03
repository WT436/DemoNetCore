using B5_ApiTutorial.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace B5_ApiTutorial.Installer
{
    public class DIIInstaller : IInstaller
    {
        public void InstallerServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IIdentitiService, IdentitiService>();
        }
    }
}
