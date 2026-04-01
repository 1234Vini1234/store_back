# store_back

API backend em .NET 10 organizada por modulo (feature-first).

## Objetivo

Este projeto expoe endpoints HTTP para o sistema da loja e foi estruturado para escalar por modulos, evitando concentrar toda a logica em um unico ponto.

## Stack atual

- .NET 10 (ASP.NET Core Web API)
- CORS configurado para frontends locais
- Injecao de dependencia nativa do ASP.NET Core

## Estrutura do projeto

Cada modulo possui tudo o que precisa dentro da propria pasta.

```text
store_back/
	Modules/
		Products/
			Dtos/
			Models/
			Repositories/
			Routes/
			Services/
			ProductsController.cs
	Program.cs
	appsettings.json
	appsettings.Development.json
```

## Responsabilidade de cada camada

- `ProductsController`: recebe a requisicao HTTP e devolve a resposta HTTP.
- `Services`: aplica regras de negocio e orquestra o fluxo.
- `Repositories`: acesso a dados (hoje em memoria; depois pode migrar para EF Core).
- `Dtos`: contratos de entrada e saida da API.
- `Models`: representacao interna do dominio do modulo.
- `Routes`: centraliza constantes de rota para evitar strings espalhadas.

## Fluxo de uma requisicao

1. Cliente chama `GET /api/products`.
2. `ProductsController` recebe a chamada.
3. Controller chama `IProductService`.
4. Service consulta `IProductRepository`.
5. Repositorio retorna dados.
6. Service mapeia para `ProductDto`.
7. Controller retorna `200 OK` com os DTOs.

## CORS

A policy `FrontendPolicy` permite as origens abaixo para desenvolvimento local:

- http://localhost:5173
- http://localhost:3000

Se o frontend usar outra porta, atualize no `Program.cs`.

## Como executar localmente

1. Restaurar pacotes:

```powershell
dotnet restore .\store_front\store_back.csproj
```

2. Executar a API:

```powershell
dotnet run --project .\store_back\store_back.csproj
```

3. Testar endpoint principal:

```http
GET /api/products
```

## Como criar um novo modulo

Use o mesmo padrao de `Products`:

1. Criar `Modules/NomeDoModulo`.
2. Adicionar `Dtos`, `Models`, `Repositories`, `Routes`, `Services` e `NomeDoModuloController.cs`.
3. Registrar interfaces e implementacoes no `Program.cs`.
4. Expor endpoints no controller.

## Proximas evolucoes recomendadas

1. Substituir repositorio em memoria por EF Core + banco.
2. Adicionar validacao de entrada (FluentValidation).
3. Implementar autenticacao JWT.
4. Adicionar testes unitarios e de integracao.
