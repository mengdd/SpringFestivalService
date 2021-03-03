using Amazon.DynamoDBv2.DataModel;

namespace SpringFestivalService.Models
{
    [DynamoDBTable("Show")]
    public class Show : BaseModel
    {
        [DynamoDBHashKey] public string Year { get; set; }
        [DynamoDBRangeKey] public string Id { get; set; }
        [DynamoDBProperty] public string Name { get; set; }
        [DynamoDBProperty] public int Vote { get; set; }
        
    }
}