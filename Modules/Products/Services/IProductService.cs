using store_front.Modules.Products.Dtos;

namespace store_front.Modules.Products.Services;

/// <summary>
/// Define operacoes de negocio do modulo de produtos.
/// </summary>
public interface IProductService
{
    /// <summary>
    /// Retorna todos os produtos mapeados para o contrato de saida da API.
    /// </summary>
    /// <param name="cancellationToken">Token para cancelar a operacao.</param>
    /// <returns>Lista de produtos em formato DTO.</returns>
    Task<IReadOnlyList<ProductDto>> GetAllAsync(CancellationToken cancellationToken = default);
}
