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
- [ ] Parte 2 - Regras de negócio (serviços)
- [ ] Parte 3 - Aplicação Desktop (Windows Forms)
- [ ] Parte 4 - API REST

## Banco de dados

1. Instale o PostgreSQL.
2. Crie o banco: `CREATE DATABASE vendinha;`
3. Execute o script [`database/schema.sql`](database/schema.sql).
