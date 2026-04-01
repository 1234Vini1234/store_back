using Microsoft.AspNetCore.Mvc;
using store_front.Modules.Products.Dtos;
using store_front.Modules.Products.Routes;
using store_front.Modules.Products.Services;

namespace store_front.Modules.Products;

/// <summary>
/// Expoe endpoints HTTP do modulo de produtos.
/// </summary>
[ApiController]
[Route(ProductsRoutes.Base)]
public class ProductsController : ControllerBase
{
    private readonly IProductService _productService;

    /// <summary>
    /// Inicializa o controller com o servico de produtos.
    /// </summary>
    /// <param name="productService">Servico com regras de negocio de produtos.</param>
    public ProductsController(IProductService productService)
    {
        _productService = productService;
    }

    /// <summary>
    /// Retorna o catalogo de produtos para o cliente.
    /// </summary>
    /// <param name="cancellationToken">Token para cancelar a operacao.</param>
    /// <returns>Lista de produtos em formato de resposta da API.</returns>
    [HttpGet]
    [ProducesResponseType(typeof(IReadOnlyList<ProductDto>), StatusCodes.Status200OK)]
    public async Task<ActionResult<IReadOnlyList<ProductDto>>> GetAll(CancellationToken cancellationToken)
    {
        var products = await _productService.GetAllAsync(cancellationToken);
        return Ok(products);
    }
}
