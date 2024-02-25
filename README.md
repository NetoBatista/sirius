# Sirius

### O que é ?
É um projeto de acompanhamento financeiro, voltado para pagamentos recorrentes mensais.

### Features
* Categoria
* Pagamentos
* Registros
* Dashboard

### Como executar ?

É necessário ter um postgresql instalado, basta executar o projeto (dotnet run) e modificar a variavel ambiente CONNECTION_STRING caso seja necessário

```
Comando: dotnet run

CONNECTION_STRING=Host=localhost;Database=sirius;Username=postgres;Password=Senha123!
```

Para criação do postgresql no docker basta copiar o comando abaixo para um arquivo Dockerfile e executar: docker-compose up -d

```
name: postgres
services:
  postgres:
    image: postgres
    environment:
      POSTGRES_PASSWORD: "Senha123!"
    ports:
      - "5432:5432"
    volumes:
      - ./postgres-data:/var/lib/postgresql/data
    networks:
      - postgres-network
      
  pgadmin:
    image: dpage/pgadmin4
    environment:
      PGADMIN_DEFAULT_EMAIL: "admin@admin.com"
      PGADMIN_DEFAULT_PASSWORD: "Senha123!"
    ports:
      - "8080:80"
    depends_on:
      - postgres
    networks:
      - postgres-network

networks: 
  postgres-network:
    driver: bridge
```

Após o banco criado basta executar o projeto, as tabelas e relacionamentos do banco é criado via migration, sem a necessidade de realizar configuração

Vídeo do projeto

https://github.com/NetoBatista/sirius/assets/23426240/48848a21-07d7-4bdd-9b1a-47bf757655fd

