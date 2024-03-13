## 💻 Configurações Iniciais

Passo 1: Download do Dockerfile
- Faça o download do docker file

Passo 2: Executar os Comandos no Terminal
- Rode os seguintes comandos no cmd
  <br>
  ```docker build --pull --rm -f "Dockerfile" -t naobinariosapi:latest```<br>
  ```docker run --rm -d -p 8081:80/tcp naobinariosapi:latest```
- Acesse a URL: http://localhost:8081/swagger
- Na url (swagger) contém o restante da documentação da API.
