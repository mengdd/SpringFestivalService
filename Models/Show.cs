using Amazon.DynamoDBv2.DataModel;

namespace SpringFestivalService.Models
{
    [DynamoDBTable("Show")]
    public class Show : BaseModel
    {
        [DynamoDBHashKey] public string Id { get; set; }
        [DynamoDBRangeKey] public string Time { get; set; }
        [DynamoDBProperty] public string Name { get; set; }
    }
}
