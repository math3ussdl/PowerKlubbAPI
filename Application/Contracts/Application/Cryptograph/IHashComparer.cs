namespace PowerKlubbAPI.Application.Contracts.Application.Cryptograph;

public interface IHashComparer
{
	bool Compare(string plainText, string digest);
}
