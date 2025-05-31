# PackingServiceAPI

## Descrição

API REST em .NET Core para empacotamento de pedidos de uma loja de jogos online.  
Recebe uma lista de pedidos com produtos e suas dimensões, e retorna a melhor forma de embalar os produtos utilizando caixas pré-definidas, otimizando o uso do espaço.


### Caixas disponíveis:

| Caixa    | Altura (cm) | Largura (cm) | Comprimento (cm) |
|----------|-------------|--------------|------------------|
| Caixa 1  | 30          | 40           | 80               |
| Caixa 2  | 80          | 50           | 40               |
| Caixa 3  | 50          | 80           | 60               |

---

## Funcionalidades

- Recebe JSON com múltiplos pedidos e produtos.
- Para cada pedido, calcula quais caixas utilizar e quais produtos vão em cada caixa.
- Utiliza 3 modelos fixos de caixas com dimensões específicas.
- Informa quando produto não cabe em nenhuma caixa disponível.

---

## Requisitos

- .NET 6 ou superior
- Docker e Docker Compose
- SQL Server (rodando em container Docker)
- Visual Studio 2022 / VS Code (opcional para desenvolvimento local)

---

## Estrutura do Projeto

- **Models**: entidades de domínio (Pedido, Produto, Caixa, Dimensoes)
- **DTOs**: objetos para transferência de dados entre camadas
- **Services**: lógica de negócio para empacotamento
- **Controllers**: endpoints REST para comunicação com cliente
- **Dockerfile** e **docker-compose.yml** para containerização da API e banco de dados

---

## Como rodar o projeto com Docker

1. Clone este repositório:

```bash
git clone https://github.com/seuusuario/PackingServiceAPI.git
cd PackingServiceAPI
```
2. Ajuste as configurações de conexão no appsettings.json para apontar para o container do SQL Server.

3. Build e subir containers:

```bash
docker-compose up --build

```
4. Acesse a API via:

http://localhost:5000/swagger