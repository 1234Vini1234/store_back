namespace store_front.Modules.Auth.Dtos;

/// <summary>
/// Dados recebidos para autenticar um usuario.
/// </summary>
public record LoginRequest(string Email, string Password);
