## 💻 Configurações Iniciais

- Faça o download do docker file
- Rode os seguintes comandos no cmd
  ```docker build --pull --rm -f "Dockerfile" -t naobinariosapi:latest```
  ```docker run --rm -d -p 8081:80/tcp naobinariosapi:latest```
- Acesse a URL: http://localhost:8081/swagger
- Na url (swagger) contém o restante da documentação
