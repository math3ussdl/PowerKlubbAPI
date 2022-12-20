namespace PowerKlubbAPI.Application.Contracts.Application.Cryptograph;

public interface IHashComparer
{
	Task<bool> CompareAsync(string plainText, string digest);
}
