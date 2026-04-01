# Padrao de modulos

Este diretorio concentra os modulos de negocio da API.

## Regra principal

Cada modulo deve ser autocontido e ter suas proprias pastas:

- `Dtos`
- `Models`
- `Repositories`
- `Routes`
- `Services`
- `NomeDoModuloController.cs`

## Beneficios

- Facilita manutencao e onboarding
- Evita dependencia desnecessaria entre contextos
- Permite evoluir modulo por modulo

## Convencoes

- Controller nao contem regra de negocio
- Service concentra regras e fluxo
- Repository concentra acesso a dados
- DTO e o contrato externo da API
- Model e estrutura interna do modulo
