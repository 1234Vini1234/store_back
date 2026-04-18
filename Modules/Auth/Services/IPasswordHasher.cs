namespace store_front.Modules.Auth.Services;

/// <summary>
/// Abstrai hash e validacao de senha.
/// </summary>
public interface IPasswordHasher
{
    string Hash(string password);

    bool Verify(string password, string passwordHash);
}
