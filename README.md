# CleanArchMVC

Este projeto é uma aplicação Razor Pages baseada nos princípios de Clean Architecture, desenvolvida em .NET 9 e C# 13.0. O objetivo é fornecer uma estrutura robusta, escalável e de fácil manutenção para sistemas web, separando claramente as responsabilidades entre as camadas de domínio, aplicação, infraestrutura e apresentação.

## Sumário

- [Visão Geral](#visão-geral)
- [Estrutura do Projeto](#estrutura-do-projeto)
- [Principais Funcionalidades](#principais-funcionalidades)
- [Requisitos](#requisitos)
- [Como Executar](#como-executar)
- [Testes](#testes)
- [Padrões e Boas Práticas](#padrões-e-boas-práticas)
- [Contribuição](#contribuição)
- [Licença](#licença)

---

## Visão Geral

O CleanArchMVC implementa um sistema de cadastro de produtos e categorias, utilizando validações de domínio e seguindo o padrão anêmico para entidades. O projeto serve como referência para aplicações Razor Pages modernas, com foco em separação de responsabilidades e testabilidade.

## Estrutura do Projeto


## Principais Funcionalidades

- Cadastro, edição e exclusão de produtos e categorias
- Validação de regras de negócio no domínio
- Associação entre produtos e categorias
- Separação clara entre camadas (Domain, Application, Infrastructure, Web)
- Utilização de Razor Pages para a interface web

## Requisitos

- [.NET 9 SDK](https://dotnet.microsoft.com/download)
- Visual Studio 2022 ou superior
- SQL Server (ou outro banco de dados, conforme configuração)

## Como Executar

1. **Clone o repositório:**

git clone https://github.com/boscobecker/CleanArchMVC.git

2. **Restaure os pacotes:**

` dotnet restore
`

3. **Configure a string de conexão no arquivo `appsettings.json` da camada Web.**

4. **Execute as migrações (se aplicável):**

` dotnet ef database update --project CleanArchMVC.Infrastructure
`

5. **Inicie a aplicação:**
`
  dotnet run --project CleanArchMVC.Web
`
6. **Acesse no navegador:**
Abra o navegador e acesse `https://localhost:5001` ou `http://localhost:5000`.


## Testes

- Os testes unitários devem ser implementados na pasta `CleanArchMVC.Tests`.
- Para rodar os testes:


## Padrões e Boas Práticas

- **Clean Architecture:** Separação de responsabilidades e dependências invertidas.
- **Validação de Domínio:** Todas as regras de negócio são validadas nas entidades.
- **Razor Pages:** Interface web moderna e produtiva.
- **Injeção de Dependência:** Utilização do DI nativo do .NET.

## Contribuição

1. Faça um fork do projeto
2. Crie uma branch (`git checkout -b feature/NovaFuncionalidade`)
3. Commit suas alterações (`git commit -am 'Adiciona nova funcionalidade'`)
4. Push para a branch (`git push origin feature/NovaFuncionalidade`)
5. Abra um Pull Request

## Licença

Este projeto está licenciado sob a licença MIT.

> Dúvidas ou sugestões? Abra uma issue ou entre em contato!