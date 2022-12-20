namespace PowerKlubbAPI.Application.Contracts.Application.Cryptograph;

public interface IDecrypter
{
	Task<string> DecryptAsync(string cipherText);
}
