using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Configuration;


namespace AzureDevOps_API
{
    public class LoadAdoSettings
    {
        public static IConfigurationRoot Configuration;

        public static AdoSettings LoadSettings()
        {
            AdoSettings settings = new AdoSettings();
            var builder = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .AddUserSecrets<LoadAdoSettings>()
                .Build();

            //builder.Bind(settings);
            settings = builder.Get<AdoSettings>();
            return settings;
        }
    }
}
