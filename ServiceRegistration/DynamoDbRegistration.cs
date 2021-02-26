using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace SpringFestivalService.ServiceRegistration
{
    public static class DynamoDbRegistration
    {
        public static IServiceCollection AddDynamoDb(this IServiceCollection services, 
            IConfiguration configuration)
        {
            services.AddDefaultAWSOptions(configuration.GetAWSOptions());
            services.AddAWSService<IAmazonDynamoDB>();
            
            services.AddTransient<IDynamoDBContext, DynamoDBContext>();
            return services;
        }
    }
}