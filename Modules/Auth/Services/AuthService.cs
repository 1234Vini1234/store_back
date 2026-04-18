using store_front.Modules.Auth.Dtos;
using store_front.Modules.Auth.Models;
using store_front.Modules.Auth.Repositories;

namespace store_front.Modules.Auth.Services;

/// <summary>
/// Implementa cadastro e login de usuarios.
/// </summary>
public class AuthService : IAuthService
{
    private const string DefaultProfile = "cliente";

    private readonly IUserRepository _userRepository;
    private readonly IPasswordHasher _passwordHasher;

    public AuthService(IUserRepository userRepository, IPasswordHasher passwordHasher)
    {
        _userRepository = userRepository;
        _passwordHasher = passwordHasher;
    }

    public async Task<AuthResponse> RegisterAsync(RegisterRequest request, CancellationToken cancellationToken = default)
    {
        var existingUser = await _userRepository.FindByEmailAsync(request.Email, cancellationToken);
        if (existingUser is not null)
        {
            throw new InvalidOperationException("Ja existe um usuario cadastrado com este email.");
        }

        var user = new User
        {
            Name = request.Name.Trim(),
            Email = request.Email.Trim().ToLowerInvariant(),
            PasswordHash = _passwordHasher.Hash(request.Password),
            TipoPerfil = string.IsNullOrWhiteSpace(request.TipoPerfil) ? DefaultProfile : request.TipoPerfil.Trim()
        };

        var createdUser = await _userRepository.CreateAsync(user, cancellationToken);
        return new AuthResponse(createdUser.Id, createdUser.Name, createdUser.Email, createdUser.TipoPerfil);
    }

    public async Task<AuthResponse> LoginAsync(LoginRequest request, CancellationToken cancellationToken = default)
    {
        var user = await _userRepository.FindByEmailAsync(request.Email.Trim().ToLowerInvariant(), cancellationToken);
        if (user is null)
        {
            throw new UnauthorizedAccessException("Email ou senha invalidos.");
        }

        var passwordIsValid = _passwordHasher.Verify(request.Password, user.PasswordHash);
        if (!passwordIsValid)
        {
            throw new UnauthorizedAccessException("Email ou senha invalidos.");
        }

        return new AuthResponse(user.Id, user.Name, user.Email, user.TipoPerfil);
    }
}
