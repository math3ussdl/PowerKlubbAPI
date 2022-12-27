namespace PowerKlubbAPI.Application.Contracts.Application.Cryptograph;

public interface IDecrypter
{
	string Decrypt(string cipherText);
}
