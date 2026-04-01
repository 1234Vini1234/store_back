using store_front.Modules.Products.Dtos;
using store_front.Modules.Products.Repositories;

namespace store_front.Modules.Products.Services;

/// <summary>
/// Implementa o fluxo de negocio de produtos e o mapeamento para DTO.
/// </summary>
public class ProductService : IProductService
{
    private readonly IProductRepository _repository;

    /// <summary>
    /// Inicializa o servico com o repositorio de produtos.
    /// </summary>
    /// <param name="repository">Repositorio responsavel por obter os dados.</param>
    public ProductService(IProductRepository repository)
    {
        _repository = repository;
    }

    /// <summary>
    /// Busca produtos no repositorio e converte para DTO de resposta.
    /// </summary>
    /// <param name="cancellationToken">Token para cancelar a operacao.</param>
    /// <returns>Lista de produtos pronta para retorno na API.</returns>
    public async Task<IReadOnlyList<ProductDto>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        var products = await _repository.GetAllAsync(cancellationToken);

        // Mantem mapeamento explicito para desacoplar payload da API do modelo interno.
        return products
            .Select(p => new ProductDto(p.Id, p.Name, p.Price, p.Stock))
            .ToList();
    }
}
