namespace HRMS.Shared
{
    public class ConnectionStrings
    {
        public string SqlConnection { get; set; }
        public string RedisConnection { get; set; }
        public string MongoConnection { get; set; }
    }

    public class Cryptography
    {
        public int Iterations { get; set; }
        public string Password { get; set; }
    }
    public class AppSettings
    {
        public ConnectionStrings ConnectionStrings { get; set; }
        public int RedisDatabaseNumber { get; set; }
        public string TokenSecret { get; set; }
        public Cryptography Cryptography { get; set; }
        public Storage Storage { get; set; }
        public OTPSettings OTPSettings { get; set; }
        public AppTokens Token { get; set; }
        public Email Mail { get; set; }
    }

    public class Storage
    {
        public string ConnectionString { get; set; }
        public string BlobContainer { get; set; }
    }
    public class OTPSettings
    {
        public int Length { get; set; }
    }

    public class AppTokens
    {
        public TokenConfigration Login { get; set; }
        public TokenConfigration ResetPassword { get; set; }
    }
    public class TokenConfigration
    {
        public int Creation { get; set; }
        public int Expiration { get; set; }
        public string TokenSecret { get; set; }
    }

    public class Email
    {
        public bool Dummy { get; set; }
        public string EmailId { get; set; }
    }
}
