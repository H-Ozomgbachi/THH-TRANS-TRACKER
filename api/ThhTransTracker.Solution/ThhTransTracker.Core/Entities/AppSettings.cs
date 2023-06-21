namespace ThhTransTracker.Core.Entities
{
    public class AppSettings
    {
        public string DbConnection { get; set; }
        public string FileServerBaseUrl { get; set; }
        public string FileServerSingle { get; set; }
        public string TheHaulageHubBaseUrl { get; set; }
        public string TheHaulageHubAuthenticate { get; set; }
    }
}
