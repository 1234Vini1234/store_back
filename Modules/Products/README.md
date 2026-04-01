# Modulo Products

Este modulo e responsavel por expor e tratar operacoes de produtos.

## Arquivos e responsabilidade

- `ProductsController.cs`
  - Camada HTTP.
  - Define endpoints e status code.

- `Routes/ProductsRoutes.cs`
  - Define constantes de rota do modulo.

- `Services/IProductService.cs`
  - Contrato da regra de negocio.

- `Services/ProductService.cs`
  - Implementa fluxo de negocio.
  - Mapeia `Model` para `Dto`.

- `Repositories/IProductRepository.cs`
  - Contrato de acesso a dados.

- `Repositories/InMemoryProductRepository.cs`
  - Implementacao em memoria para fase inicial.

- `Models/Product.cs`
  - Estrutura interna de produto.

- `Dtos/ProductDto.cs`
  - Estrutura de resposta da API.

## Endpoint atual

- `GET /api/products`
  - Retorna lista de produtos.
  - Resposta: `200 OK` com `IReadOnlyList<ProductDto>`.

## Fluxo interno

1. Controller chama `IProductService.GetAllAsync`.
2. Service chama `IProductRepository.GetAllAsync`.
3. Repository devolve lista de `Product`.
4. Service converte para `ProductDto`.
5. Controller devolve a resposta para o cliente.

## Evolucao para banco

Quando migrar para EF Core:

1. Criar contexto e configuracao de entidade.
2. Criar implementacao de repositorio com DbContext.
3. Substituir `InMemoryProductRepository` por repositorio de banco no `Program.cs`.
4. Criar migrations e atualizar banco.
