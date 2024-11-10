using Microsoft.IdentityModel.Tokens;

namespace CSWork21_WebAPI.Interfaces
{
    public interface IJwtSigningEncodingKey
    {
        string SigningAlgorithm { get; }

        SecurityKey GetKey();
    }
}
