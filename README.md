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

Para criação do postgresql no docker basta copiar o comando abaixo para um arquivo docker-compose.yml e executar: **docker-compose up -d**

```
version: '3.3'
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

## Executar o projeto no docker
**Precisa ter previamente o postgresql instalado**

DockerFile
```
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-env

WORKDIR /app

RUN apt-get update

RUN git clone https://github.com/NetoBatista/sirius

WORKDIR /app/sirius

RUN dotnet restore
RUN dotnet publish -c release -o output

FROM mcr.microsoft.com/dotnet/sdk:8.0
WORKDIR /app
COPY --from=build-env /app/sirius/output .

# Set the timezone to America/Sao_Paulo
ENV TZ=America/Sao_Paulo

# Install the pt-br locale for date formatting
RUN apt-get update && apt-get install -y locales && \
    echo "pt_BR.UTF-8 UTF-8" > /etc/locale.gen && \
    locale-gen pt_BR.UTF-8 && \
    update-locale LANG=pt_BR.UTF-8

# Set the locale to pt-br
ENV LC_ALL=pt_BR.UTF-8
ENV LANG=pt_BR.UTF-8
ENV LANGUAGE=pt_BR.UTF-8

ENV ASPNETCORE_ENVIRONMENT="Production"
ENV CONNECTION_STRING="Host=172.17.0.1;Database=sirius;Username=postgres;Password=Senha123!"

ENTRYPOINT ["dotnet", "Sirius.dll"]
```

Para subir o docker 
```sudo docker run -d --name sirius --restart always -p 5001:8080 sirius;```

Vídeo do projeto

https://github.com/NetoBatista/sirius/assets/23426240/0d1b3e42-87ee-4abc-89de-58dc57d89609




