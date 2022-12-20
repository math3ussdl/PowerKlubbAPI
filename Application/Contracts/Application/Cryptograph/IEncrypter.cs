namespace PowerKlubbAPI.Application.Contracts.Application.Cryptograph;

public interface IEncrypter
{
	Task<string> EncryptAsync(string plainText);
}
