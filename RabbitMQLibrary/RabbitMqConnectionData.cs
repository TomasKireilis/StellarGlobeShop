namespace RabbitMQLibrary
{
    public class RabbitMqConnectionData
    {
        public RabbitMqConnectionData(string userName, string password, string virtualHost, string hostName)
        {
            UserName = userName;
            Password = password;
            VirtualHost = virtualHost;
            HostName = hostName;
        }

        public string UserName { get; set; }
        public string Password { get; set; }
        public string VirtualHost { get; set; }
        public string HostName { get; set; }
    }
}