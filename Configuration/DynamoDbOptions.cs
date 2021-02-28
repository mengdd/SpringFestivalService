namespace SpringFestivalService.ServiceRegistration
{
    public class DynamoDbOptions
    {
        public string ServiceUrl { get; set; }

        public string Environment { get; set; }

        public string TablePrefix => $"{Environment}-";
    }
}