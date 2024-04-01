# DocumentManager API

## Sobre o Projeto
DocumentManager é uma API REST construída com .NET 8 para gerenciamento de documentos, oferecendo funcionalidades de armazenamento e compartilhamento com foco em segurança e controle de acesso.

## Funcionalidades
- **POST - Criação de documentos**:
Usuários com role "Admin" podem criar documentos públicos ou confidenciais

- **GET - Busca de documentos por ID**:
É necessário estar autenticado para acessar o endpoint. Documentos públicos podem ser recuperados por usuários com role "User" ou "Admin". Documentos confidenciais só podem ser acessados por usuários com role "Admin".

## Tecnologias Utilizadas
- **.NET 8**: Framework para construção da API.
- **SQL Server**: Banco de dados.
- **MediatR**: Implementação do padrão CQRS.
- **ExceptionFilters**: Para tratamento de exceções.
- **Autenticação JWT**: Segurança no controle de acesso.

## Como Executar

### Configuração do Banco de Dados
A API utiliza SQL Server. Modifique a string de conexão no arquivo `appsettings.json`.
```json
{
  "ConnectionStrings": {
    "DefaultConnection": "<sua-string-de-conexão>"
  }
}
```
## Integração com UserManager API para Autenticação

A DocumentManager API trabalha em conjunto com a [UserManager API](https://github.com/MariRodrigues/UserManager) para autenticação de usuários.

### Autenticação via UserManager API
- **Geração e Uso de Tokens**: A DocumentManager API não gera seus próprios tokens de acesso. Em vez disso, utiliza tokens JWT gerados pela [UserManager API](https://github.com/MariRodrigues/UserManager).
- **Chave JWT Compartilhada**: Para que a autenticação funcione de maneira correta, ambas as APIs - DocumentManager e UserManager - devem estar configuradas com a mesma chave JWT (`SecretKey`). Isso permite que um token JWT gerado pela UserManager API seja validamente usado para acessar endpoints protegidos na DocumentManager API.
- **Procedimento de Login**: Os usuários devem primeiro autenticar-se na UserManager API, onde suas credenciais são verificadas e um token JWT é emitido. Com este token, eles podem então acessar endpoints protegidos na DocumentManager API.

### Configuração da Chave JWT
É necessário que a `SecretKey` utilizada para a geração de tokens na UserManager API seja a mesma configurada na DocumentManager API. Isso assegura a validade e a segurança na comunicação entre as duas APIs.
```json
"JwtSettings": {
  "SecretKey": "<mesma-chave-secreta-utilizada-na-UserManager>"
}
