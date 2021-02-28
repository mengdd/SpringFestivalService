using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;
using Amazon.DynamoDBv2.Model;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SpringFestivalService.Repository;

namespace SpringFestivalService.ServiceRegistration
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

        public static IServiceCollection AddOperationalDynamoDbStore(this IServiceCollection services,
            IConfiguration configuration, DynamoDbOptions options)
        {
            var awsOptions = configuration.GetAWSOptions();
            awsOptions.DefaultClientConfig.ServiceURL = options.ServiceUrl;

            services.AddDefaultAWSOptions(awsOptions);
            services.AddAWSService<IAmazonDynamoDB>(awsOptions);
            services.AddSingleton(x => new DynamoDBContextConfig {TableNamePrefix = options.TablePrefix});
            services.AddTransient(x =>
            {
                var client = x.GetService<IAmazonDynamoDB>();
                var config = x.GetService<DynamoDBContextConfig>();
                return new DynamoDBContext(client, config);
            });
            services.AddTransient<IDynamoDBContext, DynamoDBContext>();
            services.AddTransient<TableCreator>();

            return services;
        }
    }
}