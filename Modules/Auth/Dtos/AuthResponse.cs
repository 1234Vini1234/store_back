namespace store_front.Modules.Auth.Dtos;

/// <summary>
/// Contrato de resposta com os dados publicos do usuario autenticado.
/// </summary>
public record AuthResponse(Guid Id, string Name, string Email, string TipoPerfil);
