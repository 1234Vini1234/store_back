using store_front.Modules.Products.Models;

namespace store_front.Modules.Products.Repositories;

/// <summary>
/// Repositorio temporario usado enquanto a integracao com banco nao esta ativa.
/// </summary>
public class InMemoryProductRepository : IProductRepository
{
    private static readonly IReadOnlyList<Product> Products =
    [
        new Product { Id = Guid.Parse("11111111-1111-1111-1111-111111111111"), Name = "Notebook", Price = 4200.00m, Stock = 10 },
        new Product { Id = Guid.Parse("22222222-2222-2222-2222-222222222222"), Name = "Mouse", Price = 120.50m, Stock = 150 },
        new Product { Id = Guid.Parse("33333333-3333-3333-3333-333333333333"), Name = "Teclado", Price = 250.00m, Stock = 80 }
    ];

    /// <summary>
    /// Retorna os produtos fixos em memoria para desenvolvimento inicial.
    /// </summary>
    /// <param name="cancellationToken">Token para cancelar a operacao.</param>
    /// <returns>Lista de produtos em memoria.</returns>
    public Task<IReadOnlyList<Product>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return Task.FromResult(Products);
    }
}
