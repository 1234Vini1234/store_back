using store_front.Modules.Products.Models;

namespace store_front.Modules.Products.Repositories;

/// <summary>
/// Define operacoes de leitura e escrita para persistencia de produtos.
/// </summary>
public interface IProductRepository
{
    /// <summary>
    /// Le todos os produtos da fonte de dados ativa.
    /// </summary>
    /// <param name="cancellationToken">Token para cancelar a operacao.</param>
    /// <returns>Lista de produtos do repositorio.</returns>
    Task<IReadOnlyList<Product>> GetAllAsync(CancellationToken cancellationToken = default);
}
