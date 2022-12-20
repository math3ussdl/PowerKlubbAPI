namespace PowerKlubbAPI.Application.Contracts.Application.Cryptograph;

public interface IHasher
{
	Task<string> HashAsync(string plainText);
}
