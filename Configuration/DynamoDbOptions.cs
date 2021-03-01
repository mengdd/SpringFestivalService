namespace SpringFestivalService.Configuration
{
    public class DynamoDbOptions
    {
        public string ServiceUrl { get; set; }
        public string AWS_ACCESS_KEY_ID { get; set; }
        public string AWS_SECRET_ACCESS_KEY { get; set; }
        public string Environment { get; set; }
    }
}