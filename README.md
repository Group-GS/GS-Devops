# AgroSpace API - Global Solution 🚀

## 📋 Descrição do Projeto
A API AgroSpace é a ponte entre a nossa aplicação de monitoramento agrícola e o banco de dados. Desenvolvida em **.NET 10.0**, ela gerencia dados de biomas, locais, sensores e alertas, utilizando o **Entity Framework Core** para persistência em um banco **Oracle**. Toda a infraestrutura foi conteinerizada utilizando **Docker** e está hospedada na nuvem **Microsoft Azure**.

## 🏗️ Arquitetura da Solução
<img width="372" height="826" alt="Diagrama DEVOPS-Página-1 drawio" src="https://github.com/user-attachments/assets/bba21ff8-16f3-42b1-87f1-58aaeb514152" />


## 🛠️ Tecnologias Utilizadas
* **C# / .NET 10.0**
* **Oracle Database** (`container-registry.oracle.com/database/free:latest`)
* **Docker & Docker Compose**
* **Microsoft Azure** (Máquina Virtual Linux)

## Vídeo demonstrativo (YOUTUBE)
* Link do vídeo: https://www.youtube.com/watch?v=yz-t-3xJido

## 🚀 Como Executar o Projeto na Nuvem (How-To)

Siga este passo a passo para clonar o repositório e subir a infraestrutura completa em um ambiente Linux (Debian/Ubuntu):

### 1. Clonar o Repositório
```bash
git clone https://github.com/Group-GS/GS-Devops.git
cd GS-Devops
```
### 2. Subir a Infraestrutura (Docker Compose)

Para compilar a API e iniciar os contêineres do banco de dados e da aplicação na mesma rede, execute:
```bash
sudo COMPOSE_HTTP_TIMEOUT=200 docker-compose up -d --build
```

### 3. Verificar o Status

Após o processo, verifique se os dois contêineres (api_RM563088 e oracle_RM563088) estão no ar e operacionais:
```bash
sudo docker ps
```

### 4. Testar a Conexão e Persistência

Para garantir que as tabelas da aplicação foram criadas corretamente pelo Entity Framework, acesse o contêiner do banco de dados:
```bash
sudo docker exec -it oracle_RM563088 sqlplus system/300107@FREEPDB1
```
### 5. Oracle

No terminal do Oracle, execute a consulta abaixo para listar as tabelas criadas:
```SQL
SELECT table_name FROM user_tables;
```

### Desenvolvido por: 
* Aluno: Lucas Rafael Solimene / RM: 565194

* Aluno: Samyr Couto Oliveira / RM: 565562

* Aluno: Henrique Teixeira Cesar / RM: 563088
