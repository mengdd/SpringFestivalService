using Amazon.DynamoDBv2.DataModel;

namespace SpringFestivalService.Models
{
    [DynamoDBTable("Show")]
    public class Show : BaseModel
    {
        [DynamoDBHashKey] public string Id { get; set; }
        [DynamoDBGlobalSecondaryIndexHashKey] public string Name { get; set; }
        [DynamoDBProperty] public string Order { get; set; }
    }
}