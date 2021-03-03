using System.Threading.Tasks;
using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;
using Amazon.Runtime;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SpringFestivalService.Repository;

namespace SpringFestivalService.Configuration
{
    public static class DynamoDbRegistration
    {
        public static IServiceCollection AddDynamoDb(this IServiceCollection services,
            IConfiguration configuration,
            string dynamoDbOptionKey)
        {
            var dynamoDbOption = new DynamoDbOptions();
            var section = configuration.GetSection(dynamoDbOptionKey);
            section.Bind(dynamoDbOption);

            services.Configure<DynamoDbOptions>(section);
            services.AddOperationalDynamoDbStore(configuration, dynamoDbOption);

            return services;
        }

        private static IServiceCollection AddOperationalDynamoDbStore(this IServiceCollection services,
            IConfiguration configuration, DynamoDbOptions options)
        {
            var awsOptions = configuration.GetAWSOptions();
            awsOptions.DefaultClientConfig.ServiceURL = options.ServiceUrl;
            awsOptions.Credentials = new BasicAWSCredentials(options.AWS_ACCESS_KEY_ID, options.AWS_SECRET_ACCESS_KEY);

            services.AddDefaultAWSOptions(awsOptions);
            services.AddAWSService<IAmazonDynamoDB>(awsOptions);
            services.AddSingleton(x => new DynamoDBContextConfig());
            services.AddTransient(x =>
            {
                var client = x.GetService<IAmazonDynamoDB>();
                var config = x.GetService<DynamoDBContextConfig>();
                return new DynamoDBContext(client, config);
            });
            services.AddTransient<IDynamoDBContext, DynamoDBContext>();
            services.AddTransient<DynamoDbOptions>();
            services.AddTransient<ITableCreator, TableCreator>();
            
            return services;
        }
        
        public static async Task<IApplicationBuilder> WithDatabaseTables(this IApplicationBuilder app)
        {
            var creator = app.ApplicationServices.GetService<ITableCreator>();
            await creator.CreateTable();
            return app;
        }
    }
}