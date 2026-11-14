-- =========================================================
-- Vendinha - script de criação do banco (PostgreSQL)
-- =========================================================
-- 1) Crie o banco (rodar conectado no banco "postgres"):
--    CREATE DATABASE vendinha;
-- 2) Conecte no banco "vendinha" e rode o restante do script.

DROP TABLE IF EXISTS dividas;
DROP TABLE IF EXISTS clientes;

CREATE TABLE clientes (
    id              SERIAL       PRIMARY KEY,
    nome            VARCHAR(150) NOT NULL,
    cpf             CHAR(11)     NOT NULL,
    data_nascimento DATE         NOT NULL,
    email           VARCHAR(150) NULL,
    CONSTRAINT uq_clientes_cpf UNIQUE (cpf)          -- apenas um cliente por CPF
);

CREATE TABLE dividas (
    id             SERIAL        PRIMARY KEY,
    cliente_id     INTEGER       NOT NULL REFERENCES clientes (id) ON DELETE CASCADE,
    valor          NUMERIC(12,2) NOT NULL CHECK (valor > 0),
    paga           BOOLEAN       NOT NULL DEFAULT FALSE,
    data_criacao   TIMESTAMPTZ   NOT NULL DEFAULT NOW(),
    data_pagamento TIMESTAMPTZ   NULL,
    CONSTRAINT ck_dividas_pagamento CHECK (
        (paga = FALSE AND data_pagamento IS NULL) OR
        (paga = TRUE  AND data_pagamento IS NOT NULL)
    )
);

-- Regra de negócio garantida também no banco:
-- um cliente só pode ter UMA dívida em aberto
CREATE UNIQUE INDEX uq_dividas_uma_em_aberto
    ON dividas (cliente_id)
    WHERE paga = FALSE;

CREATE INDEX ix_dividas_cliente ON dividas (cliente_id);

-- ---------------------------------------------------------
-- Dados de exemplo (opcional)
-- ---------------------------------------------------------
INSERT INTO clientes (nome, cpf, data_nascimento, email) VALUES
    ('Maria da Silva',      '52998224725', '1990-05-10', 'maria@email.com'),
    ('João Pereira',        '11144477735', '1985-11-23', NULL),
    ('Ana Souza Oliveira',  '39053344705', '2001-02-14', 'ana.souza@email.com');

INSERT INTO dividas (cliente_id, valor, paga, data_criacao, data_pagamento) VALUES
    (1, 120.50, FALSE, NOW() - INTERVAL '5 days',  NULL),
    (1,  80.00, TRUE,  NOW() - INTERVAL '40 days', NOW() - INTERVAL '10 days'),
    (2,  45.90, FALSE, NOW() - INTERVAL '2 days',  NULL);
