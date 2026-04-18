using store_front.Modules.Auth.Models;

namespace store_front.Modules.Auth.Repositories;

/// <summary>
/// Define acesso a dados de usuarios.
/// </summary>
public interface IUserRepository
{
    /// <summary>
    /// Busca um usuario pelo email.
    /// </summary>
    Task<User?> FindByEmailAsync(string email, CancellationToken cancellationToken = default);

    /// <summary>
    /// Cria um usuario novo na tabela users.
    /// </summary>
    Task<User> CreateAsync(User user, CancellationToken cancellationToken = default);
}
