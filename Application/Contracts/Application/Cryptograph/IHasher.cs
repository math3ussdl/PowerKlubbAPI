namespace PowerKlubbAPI.Application.Contracts.Application.Cryptograph;

public interface IHasher
{
	string Hash(string plainText);
}
