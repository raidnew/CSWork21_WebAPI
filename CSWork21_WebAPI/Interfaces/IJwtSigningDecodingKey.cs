using Microsoft.IdentityModel.Tokens;

namespace CSWork21_WebAPI.Interfaces
{
    public interface IJwtSigningDecodingKey
    {
        SecurityKey GetKey();
    }
}
