# FC4 - Event-Driven Architecture

Repositório do curso **Event-Driven Architecture** da [FullCycle](https://fullcycle.com.br).

## Sobre o Projeto

Este projeto implementa um sistema de **Reservas de Hotel** utilizando uma arquitetura de **Modular Monolith** com práticas de Event-Driven Design. O sistema é composto por módulos independentes que se comunicam através de eventos de domínio e eventos de integração.

## Módulos

| Módulo | Descrição |
|--------|-----------|
| **Catalog** | Gerenciamento de hotéis e tipos de quartos |
| **Guests** | Gerenciamento de hóspedes |
| **Reservations** | Criação e gerenciamento de reservas |
| **Payments** | Processamento de pagamentos |

## Tecnologias

- .NET / C#
- Entity Framework Core
- PostgreSQL
- MongoDB (Read Store - CQRS)
- RabbitMQ (Mensageria)
- Docker / Docker Compose

## Branches e Conteúdo das Aulas

### `master`
Projeto inicial com a estrutura base do monolito modular.

### `sections/unit_of_work`
- **3.03** - Dispatching events no Unit of Work

### `sections/locks`
- **02** - Criar teste para verificar controle de race condition
- **03** - Pessimistic Lock
- **05** - Implementar Optimistic Lock

### `sections/cqrs`
- **4.02** - Criar teste para verificar controle de race condition
- **4.03** - Pessimistic Lock
- **4.05** - Implementar Optimistic Lock
- **5.04** - Alterar estrutura de pastas
- **5.05** - List Reservations Query
- **5.06** - Refatorar use cases restantes
- **5.08** - Raising Domain Events
- **5.09** - Criar Event Handlers e Integration Events
- **5.10** - Criar Consumers
- **5.11** - Implementar interfaces do Read Store
- **5.12** - Registrar dependências
- **5.13** - Atualizar query side para consultar MongoDB
- **5.14** - Enriquecer eventos
- **5.15** - Remover testes de queries de reservas
- **5.16** - Implementar Outbox Pattern

### `sections/event_sourcing`
- **6.04** - Ajustar domínio para aplicar Event Sourcing
- **6.05** - Criar Event Store
- **6.07** - Carregar agregados a partir do histórico
- **6.08** - Criar Event Store Repository
- **6.09** - Projeções síncronas
- **6.10** - Corrigir testes de integração
- **6.11** - Otimização com Snapshots
- **6.12** - Corrigir serialização de Snapshots
- **6.13** - Ajustes finais

## Como Executar

### Pré-requisitos
- Docker e Docker Compose
- .NET SDK

### Subindo a infraestrutura

```bash
docker-compose up -d
```

### Executando as migrations

```bash
./update-db.sh
```

### Executando a aplicação

```bash
dotnet run --project src/FC4.HotelReservation.WebApi
```

## Estrutura do Projeto

```
├── modules/
│   ├── Catalog/          # Módulo de Catálogo
│   ├── Guests/           # Módulo de Hóspedes
│   ├── Payments/         # Módulo de Pagamentos
│   └── Reservations/     # Módulo de Reservas
├── shared/               # Código compartilhado (Domain, Infrastructure, Application)
├── src/                  # WebApi (host)
└── tests/                # Testes de integração
```

## Conceitos Abordados

- **Domain Events** — Comunicação entre módulos via eventos de domínio
- **Unit of Work** — Garantia de consistência transacional
- **Pessimistic & Optimistic Locking** — Controle de concorrência
- **CQRS** — Separação de comandos e consultas
- **Outbox Pattern** — Garantia de entrega de eventos
- **Event Sourcing** — Persistência baseada em eventos
- **Snapshots** — Otimização de reconstrução de agregados

