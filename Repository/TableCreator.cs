using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.Model;
using Microsoft.Extensions.Logging;
using SpringFestivalService.Configuration;

namespace SpringFestivalService.Repository
{
    public class TableCreator
    {
        private readonly IAmazonDynamoDB _amazonDynamoDbClient;
        private readonly ILogger<TableCreator> _logger;
        private readonly DynamoDbOptions _options;

        public TableCreator(IAmazonDynamoDB amazonDynamoDbClient, DynamoDbOptions options, ILogger<TableCreator> logger)
        {
            _amazonDynamoDbClient = amazonDynamoDbClient;
            _options = options;
            _logger = logger;
        }

        public async Task CreateTable()
        {
            var tableName = "Show";

            var tables = await _amazonDynamoDbClient.ListTablesAsync();
            if (!tables.TableNames.Contains(tableName))
            {
                _logger.Log(LogLevel.Information, "Table not found, creating table => " + tableName);
                var createTableRequest = new CreateTableRequest
                {
                    TableName = tableName,
                    ProvisionedThroughput = new ProvisionedThroughput
                    {
                        ReadCapacityUnits = 3,
                        WriteCapacityUnits = 1
                    },
                    KeySchema = new List<KeySchemaElement>
                    {
                        new KeySchemaElement
                        {
                            AttributeName = "Id",
                            KeyType = KeyType.HASH
                        },
                        new KeySchemaElement
                        {
                            AttributeName = "Time",
                            KeyType = KeyType.RANGE
                        }
                    },
                    AttributeDefinitions = new List<AttributeDefinition>
                    {
                        new AttributeDefinition {AttributeName = "Id", AttributeType = ScalarAttributeType.S},
                        new AttributeDefinition {AttributeName = "Time", AttributeType = ScalarAttributeType.S},
                    }
                };

                await _amazonDynamoDbClient.CreateTableAsync(createTableRequest);

                bool isTableAvailable = false;
                while (!isTableAvailable)
                {
                    _logger.Log(LogLevel.Debug, "Waiting for table to be active...");
                    Thread.Sleep(2000);
                    var tableStatus = await _amazonDynamoDbClient.DescribeTableAsync(tableName);
                    isTableAvailable = tableStatus.Table.TableStatus == "ACTIVE";
                }

                _logger.Log(LogLevel.Information, "Table is ACTIVE");
            }
            else
            {
                _logger.Log(LogLevel.Information, "Table already exists");
            }
        }
    }
}