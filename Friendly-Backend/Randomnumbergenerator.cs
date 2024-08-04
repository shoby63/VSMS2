using System.Security.Cryptography;
using Microsoft.IdentityModel.Tokens;


namespace api.Data;

public class KeyGenerator
{
    public static SymmetricSecurityKey GenerateKey()
    {
        // Generate a new key
        byte[] keyBytes = new byte[128]; // 32 bytes = 256 bits
        using (var rng = RandomNumberGenerator.Create())
        {
            rng.GetBytes(keyBytes);
        }

        // Convert to SymmetricSecurityKey
        return new SymmetricSecurityKey(keyBytes);
    }
}
