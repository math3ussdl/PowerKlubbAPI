using PowerKlubbAPI.Application.Contracts.Application.Cryptograph;

namespace PowerKlubbAPI.Infrastructure.Application;

public class JwtAdapter : IEncrypter, IDecrypter
{
    public string Encrypt(string plainText)
    {
        throw new NotImplementedException();
    }

    public string Decrypt(string plainText)
    {
        throw new NotImplementedException();
    }
}
