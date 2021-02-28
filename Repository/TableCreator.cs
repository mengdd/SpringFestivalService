using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.Model;
using SpringFestivalService.ServiceRegistration;

namespace SpringFestivalService.Repository
{
    public class TableCreator
    {
        private readonly IAmazonDynamoDB _amazonDynamoDbClient;

        public TableCreator(IAmazonDynamoDB amazonDynamoDbClient)
        {
            _amazonDynamoDbClient = amazonDynamoDbClient;
        }

        public async Task CreateTable(DynamoDbOptions options)
        {
            var tableName = options.TablePrefix + "Show";

            var tables = await _amazonDynamoDbClient.ListTablesAsync();
            if (!tables.TableNames.Contains(tableName))
            {
                Console.WriteLine("Table not found, creating table => " + tableName);
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
                            AttributeName = "Key",
                            KeyType = KeyType.HASH
                        }
                    },
                    AttributeDefinitions = new List<AttributeDefinition>
                    {
                        new AttributeDefinition {AttributeName = "Name", AttributeType = ScalarAttributeType.S}
                    }
                };
                await _amazonDynamoDbClient.CreateTableAsync(createTableRequest);

                bool isTableAvailable = false;
                while (!isTableAvailable)
                {
                    Console.WriteLine("Waiting for table to be active...");
                    Thread.Sleep(2000);
                    var tableStatus = await _amazonDynamoDbClient.DescribeTableAsync(tableName);
                    isTableAvailable = tableStatus.Table.TableStatus == "ACTIVE";
                }
            }
        }
    }
}