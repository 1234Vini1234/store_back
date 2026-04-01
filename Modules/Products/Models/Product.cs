namespace store_front.Modules.Products.Models;

/// <summary>
/// Representacao interna de produto usada nas camadas de negocio e persistencia.
/// </summary>
public class Product
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public int Stock { get; set; }
}
