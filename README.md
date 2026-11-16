# Vendinha

Trabalho da materia Plataforma de Desenvolvimento de Sistemas (UNIMAR 2026/2), cenario 1: Vendinha.

Sistema para controlar as contas penduradas (fiado) dos clientes de uma vendinha.

## Integrantes
RA: 2037913
- Mateus Oliveira
-----------
RA: 2025953
- Carlos Heinrich 


## O que o sistema faz

- Cadastro, edicao, consulta e exclusao de clientes (nome, CPF, data de nascimento e e-mail)
- Mostra a idade do cliente calculada pela data de nascimento
- Cadastro de dividas para cada cliente e opcao de marcar como paga
- Listagem de clientes ordenada por quem deve mais, de 10 em 10, com busca por nome
- Na listagem aparece a idade e o total que o cliente deve

Regras:

- Nome, CPF e data de nascimento sao obrigatorios
- O CPF tem que ser valido e nao pode repetir
- O e-mail so e validado se for preenchido
- Cada cliente so pode ter uma divida em aberto
- O valor da divida tem que ser maior que zero

## Estrutura

- `Vendinha` - classes do sistema (models, validacao de CPF, contexto do banco e services com as regras)
- `Vendinha.Desktop` - telas em Windows Forms
- `Vendinha.Api` - API REST
- `database/schema.sql` - script do banco

Feito em C# com .NET 8, Entity Framework Core e PostgreSQL.

## Como rodar

### Banco

1. Instalar o PostgreSQL
2. Criar o banco: `CREATE DATABASE vendinha;`
3. Rodar o script `database/schema.sql` no banco vendinha

A conexao usada e:

```
Host=localhost;Port=5432;Database=vendinha;Username=postgres;Password=postgres
```

Se a senha do seu postgres for outra, muda em `Vendinha/Configuracao.cs` (desktop) e em `Vendinha.Api/appsettings.json` (api).

### Desktop

Abrir o `Vendinha.sln` no Visual Studio, colocar o `Vendinha.Desktop` como projeto de inicializacao e rodar. Ou:

```
dotnet run --project Vendinha.Desktop
```

### API

```
dotnet run --project Vendinha.Api
```

Depois abrir `http://localhost:5080/swagger`. Tem exemplos de requisicao no arquivo `Vendinha.Api/Vendinha.Api.http`.

## Rotas da API

| Metodo | Rota | O que faz |
|---|---|---|
| GET | `/api/clientes?pesquisa=&pagina=1` | Lista os clientes |
| GET | `/api/clientes/{id}` | Busca um cliente |
| POST | `/api/clientes` | Cadastra cliente |
| PUT | `/api/clientes/{id}` | Altera cliente |
| DELETE | `/api/clientes/{id}` | Exclui cliente |
| GET | `/api/clientes/{id}/dividas` | Lista as dividas do cliente |
| POST | `/api/clientes/{id}/dividas` | Cadastra divida |
| PUT | `/api/dividas/{id}/pagar` | Marca divida como paga |
| DELETE | `/api/dividas/{id}` | Exclui divida |

Exemplo para cadastrar cliente:

```json
{
  "nome": "Maria da Silva",
  "cpf": "529.982.247-25",
  "dataNascimento": "1990-05-10",
  "email": "maria@email.com"
}
```

Exemplo para cadastrar divida:

```json
{ "valor": 50.00 }
```
