using store_front.Modules.Auth.Dtos;

namespace store_front.Modules.Auth.Services;

/// <summary>
/// Define operacoes de autenticacao.
/// </summary>
public interface IAuthService
{
    Task<AuthResponse> RegisterAsync(RegisterRequest request, CancellationToken cancellationToken = default);

    Task<AuthResponse> LoginAsync(LoginRequest request, CancellationToken cancellationToken = default);
}
