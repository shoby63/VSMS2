namespace PrimeAutoMobiles_API.Data
{
    public class JwtSettings
    {
        public string Secret { get; set; }
        public int ExpirationInMinutes { get; set; }
    }
}
