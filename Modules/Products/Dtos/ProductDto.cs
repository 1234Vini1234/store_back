namespace store_front.Modules.Products.Dtos;

/// <summary>
/// Contrato publico de saida retornado pelos endpoints de produtos.
/// </summary>
public record ProductDto(Guid Id, string Name, decimal Price, int Stock);
