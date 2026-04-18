using Npgsql;
using store_front.Modules.Auth.Models;

namespace store_front.Modules.Auth.Repositories;

/// <summary>
/// Implementacao PostgreSQL para persistencia de usuarios.
/// </summary>
public class UserRepository : IUserRepository
{
    private readonly NpgsqlDataSource _dataSource;

    public UserRepository(NpgsqlDataSource dataSource)
    {
        _dataSource = dataSource;
    }

    public async Task<User?> FindByEmailAsync(string email, CancellationToken cancellationToken = default)
    {
        const string sql = @"SELECT id, name, email, password_hash, tipo_perfil
                             FROM public.users
                             WHERE email = @email
                             LIMIT 1";

        await using var connection = await _dataSource.OpenConnectionAsync(cancellationToken);
        await using var command = new NpgsqlCommand(sql, connection);
        command.Parameters.AddWithValue("email", email);

        await using var reader = await command.ExecuteReaderAsync(cancellationToken);
        if (!await reader.ReadAsync(cancellationToken))
        {
            return null;
        }

        return new User
        {
            Id = reader.GetGuid(0),
            Name = reader.GetString(1),
            Email = reader.GetString(2),
            PasswordHash = reader.GetString(3),
            TipoPerfil = reader.GetString(4)
        };
    }

    public async Task<User> CreateAsync(User user, CancellationToken cancellationToken = default)
    {
        const string sql = @"INSERT INTO public.users (name, email, password_hash, tipo_perfil)
                             VALUES (@name, @email, @password_hash, @tipo_perfil)
                             RETURNING id";

        await using var connection = await _dataSource.OpenConnectionAsync(cancellationToken);
        await using var command = new NpgsqlCommand(sql, connection);
        command.Parameters.AddWithValue("name", user.Name);
        command.Parameters.AddWithValue("email", user.Email);
        command.Parameters.AddWithValue("password_hash", user.PasswordHash);
        command.Parameters.AddWithValue("tipo_perfil", user.TipoPerfil);

        var createdId = (Guid)(await command.ExecuteScalarAsync(cancellationToken))!;
        user.Id = createdId;
        return user;
    }
}
