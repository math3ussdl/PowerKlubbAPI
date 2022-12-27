using PowerKlubbAPI.Application.Contracts.Application.Cryptograph;
using BC = BCrypt.Net.BCrypt;

namespace PowerKlubbAPI.Infrastructure.Application;

public class BCryptAdapter : IHasher, IHashComparer
{
    public string Hash(string plainText)
    {
        return BC.HashPassword(plainText);
    }

    public bool Compare(string plainText, string digest)
    {
        return BC.Verify(plainText, digest);
    }
}
