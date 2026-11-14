# Vendinha – Controle de contas penduradas

Projeto final da disciplina **Plataforma de Desenvolvimento de Sistemas** (UNIMAR – 2026/2) – **Cenário 1: Vendinha**.

## Integrantes do grupo

- Mateus Oliveira
- _Nome do integrante 2_
- _Nome do integrante 3_
- _Nome do integrante 4_

## Sobre o sistema

Uma vendinha precisa substituir o caderno de "fiado" por um sistema. O dono cadastra os clientes e pendura as compras como dívidas, que são acertadas no fim do mês.

### Funcionalidades

- CRUD de clientes (nome completo, CPF, data de nascimento e e-mail)
- Idade calculada a partir da data de nascimento
- Cadastro de dívidas por cliente (valor, situação, data de criação e data de pagamento)
- Marcar dívida como paga
- Listagem de clientes:
  - ordenada de quem **mais deve** para quem **menos deve**
  - paginação de **10 em 10**
  - busca por nome (texto contido, sem diferenciar maiúsculas/minúsculas)
  - mostra idade atualizada e total de dívidas em aberto

### Regras de negócio

| Regra | Onde é garantida |
|---|---|
| Nome, CPF e data de nascimento são obrigatórios | `Cliente` (DataAnnotations) + `ClienteService.Validar` |
| CPF precisa ser válido (dígitos verificadores) | `Validations/CpfAttribute` |
| E-mail é validado se for informado | `[EmailAddress]` em `Cliente` |
| Apenas um cliente por CPF | `ClienteService.Validar` + `UNIQUE (cpf)` no banco |
| Cliente só pode ter **uma** dívida em aberto | `DividaService.Criar` (em transação) + índice único parcial no banco |
| Valor da dívida maior que zero | `DividaService.Criar` + `CHECK (valor > 0)` |

## Andamento

- [x] Parte 1 - Estrutura da solução, modelos, validação de CPF, contexto do banco e script SQL
- [x] Parte 2 - Regras de negócio (serviços)
- [x] Parte 3 - Aplicação Desktop (Windows Forms)
- [x] Parte 4 - API REST

## Arquitetura (3 camadas)

```
Vendinha.sln
├── Vendinha/                 → Negócio + Dados (biblioteca de classes)
│   ├── Models/               → Cliente, Divida, ClienteResumo, Pagina<T>
│   ├── Validations/          → CpfAttribute
│   ├── Contexts/             → VendinhaDbContext (Entity Framework Core + PostgreSQL)
│   └── Services/             → ClienteService, DividaService (regras de negócio)
├── Vendinha.Desktop/         → Apresentação: Windows Forms
│   ├── Form1                 → menu principal
│   └── Screens/              → CadastroCliente, ListarClientes, DividasCliente
├── Vendinha.Api/             → Apresentação: Web API REST (Swagger)
│   └── Controllers/          → ClientesController, DividasController
└── database/schema.sql       → script de criação do banco
```

- **Apresentação** (Desktop e API): só recebe a entrada e mostra o resultado.
- **Negócio** (`Services`): valida e decide o que pode ou não acontecer.
- **Dados** (`Contexts` + PostgreSQL): persiste as informações.

Os dois front-ends usam a **mesma** camada de negócio.

## Tecnologias

- C# / .NET 8 (roda também com .NET 9/10 – `RollForward=Major`)
- Entity Framework Core 8 + Npgsql
- PostgreSQL
- Windows Forms
- ASP.NET Core Web API + Swagger

## Como executar

### 1. Banco de dados

1. Instale o PostgreSQL.
2. Crie o banco:
   ```sql
   CREATE DATABASE vendinha;
   ```
3. Conectado ao banco `vendinha`, execute o script [`database/schema.sql`](database/schema.sql) (pgAdmin, DBeaver ou `psql -d vendinha -f database/schema.sql`).

String de conexão padrão:

```
Host=localhost;Port=5432;Database=vendinha;Username=postgres;Password=postgres
```

Para mudar:

- **Desktop**: defina a variável de ambiente `VENDINHA_DB` ou altere `Vendinha/Configuracao.cs`.
- **API**: altere `ConnectionStrings:Postgres` em `Vendinha.Api/appsettings.json`.

### 2. Aplicação Desktop (Windows)

```bash
dotnet run --project Vendinha.Desktop
```

Ou abra `Vendinha.sln` no Visual Studio e defina **Vendinha.Desktop** como projeto de inicialização.

### 3. API

```bash
dotnet run --project Vendinha.Api
```

Abra `http://localhost:5080/swagger` para testar. Também há exemplos prontos em `Vendinha.Api/Vendinha.Api.http`.

## Endpoints da API

| Método | Rota | Descrição |
|---|---|---|
| GET | `/api/clientes?pesquisa=&pagina=1` | Lista clientes (maior dívida primeiro, 10 por página) |
| GET | `/api/clientes/{id}` | Busca um cliente |
| POST | `/api/clientes` | Cria cliente |
| PUT | `/api/clientes/{id}` | Atualiza cliente |
| DELETE | `/api/clientes/{id}` | Exclui cliente (e suas dívidas) |
| GET | `/api/clientes/{id}/dividas` | Lista dívidas do cliente |
| POST | `/api/clientes/{id}/dividas` | Pendura uma dívida `{ "valor": 50.00 }` |
| PUT | `/api/dividas/{id}/pagar` | Marca dívida como paga |
| DELETE | `/api/dividas/{id}` | Exclui dívida |

### Exemplo – criar cliente

```json
POST /api/clientes
{
  "nome": "Maria da Silva",
  "cpf": "529.982.247-25",
  "dataNascimento": "1990-05-10",
  "email": "maria@email.com"
}
```

Resposta (201):

```json
{
  "id": 1,
  "nome": "Maria da Silva",
  "cpf": "52998224725",
  "dataNascimento": "1990-05-10T00:00:00",
  "email": "maria@email.com",
  "idade": 36,
  "cpfFormatado": "529.982.247-25"
}
```

### Exemplo – listagem

```json
GET /api/clientes?pagina=1
{
  "itens": [
    { "id": 1, "nome": "Maria da Silva", "cpf": "52998224725", "dataNascimento": "1990-05-10T00:00:00",
      "email": "maria@email.com", "totalDividas": 120.50, "idade": 36 }
  ],
  "numeroPagina": 1,
  "tamanhoPagina": 10,
  "totalItens": 3,
  "totalPaginas": 1,
  "temProxima": false,
  "temAnterior": false
}
```

Erros de validação retornam **400** no formato:

```json
{ "erros": ["CPF inválido.", "O cliente já possui uma dívida em aberto. Quite-a antes de lançar outra."] }
```
