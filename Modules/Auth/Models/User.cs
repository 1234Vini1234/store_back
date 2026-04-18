namespace store_front.Modules.Auth.Models;

/// <summary>
/// Representacao interna do usuario armazenado na tabela users.
/// </summary>
public class User
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string PasswordHash { get; set; } = string.Empty;
    public string TipoPerfil { get; set; } = string.Empty;
}
