using GitNode.Application.Common.Interfaces;
using GitNode.Infrastructure.Cryptography;
using GitNode.Infrastructure.ExternalApis;
using GitNode.Infrastructure.ExternalApis.Interfaces;
using GitNode.Infrastructure.ExternalApis.Mappers;
using GitNode.Infrastructure.Identity;
using GitNode.Infrastructure.Options;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GitNode.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            var google = configuration.GetSection(IdentityOptions.OptionName);
            var configurationService = new GoogleConfigurationService();
            var configurationManager = new ConfigurationManager(configurationService);
            
            services
                .AddSingleton<IApiProvider, ApiProvider>()
                .AddSingleton<IGitHubMapper, GitHubMapper>()
                .AddSingleton<IBitbucketMapper, BitbucketMapper>()
                .AddSingleton<IGitLabMapper, GitLabMapper>();

            services
                .Configure<IdentityOptions>(google)
                .Configure<GitHubOptions>(configuration.GetSection(GitHubOptions.OptionName))
                .Configure<BitbucketOptions>(configuration.GetSection(BitbucketOptions.OptionName))
                .Configure<GitLabOptions>(configuration.GetSection(GitLabOptions.OptionName))
                .Configure<CryptographyOptions>(configuration.GetSection(CryptographyOptions.OptionName));

            services
                .AddHttpClient()
                .AddSingleton<IGoogleConfigurationService>(configurationService)
                .AddSingleton<IUserManager, UserManager>()
                .AddSingleton<ICryptography, CryptographyService>();
            
            services
                .AddAuthentication(GoogleDefaults.AuthenticationScheme)
                .AddJwtBearer(GoogleDefaults.AuthenticationScheme, GoogleDefaults.DisplayName, options =>
                {
                    options.ConfigurationManager = configurationManager;
                    options.Audience = google.Get<IdentityOptions>().ClientId;
                    options.RefreshInterval = GoogleConfigurationService.DefaultMinimalRefreshInterval;
                    options.AutomaticRefreshInterval = GoogleConfigurationService.DefaultAbsoluteExpiration;
                });

            return services;
        }
    }
}