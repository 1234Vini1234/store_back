namespace store_front.Modules.Auth.Dtos;

/// <summary>
/// Dados recebidos para criar um usuario.
/// </summary>
public record RegisterRequest(string Name, string Email, string Password, string? TipoPerfil = null);
