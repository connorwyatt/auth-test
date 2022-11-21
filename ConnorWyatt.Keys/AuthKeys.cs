using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace ConnorWyatt.Keys;

public static class AuthKeys
{
  public static readonly SecurityKey SigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_signingSecretKey));

  public static readonly SecurityKey EncryptionKey =
    new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_encryptionSecretKey));

  private const string _signingSecretKey = "a6e00a1bb7b14d71b8f2fc65ad50dfbe";
  private const string _encryptionSecretKey = "5ebeebee18894228b49f7f5cd0c94afb";
}
