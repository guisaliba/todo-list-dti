# todo-list-dti

<h1 align="center">To-Do List</h1>

<p align="center">
  <a href="#-tecnologias">Tecnologias</a>&nbsp;&nbsp;&nbsp;|&nbsp;&nbsp;&nbsp;
  <a href="#-projeto">Projeto</a>&nbsp;&nbsp;&nbsp;|&nbsp;&nbsp;&nbsp;
  <a href="#%EF%B8%8F-funcionalidades">Funcionalidades</a>&nbsp;&nbsp;&nbsp;|&nbsp;&nbsp;&nbsp;
  <a href="#-como-executar">Como executar</a>
</p>

## ✨ Tecnologias

Esse projeto foi desenvolvido com as seguintes tecnologias:

- C#
- ASP.NET Core MVC
- SQLite 

## 💻 Projeto

Aplicação desenvolvida em C# utilizando o framework ASP.NET Core MVC. Essa aplicação permite que o usuário adicione e exclua lembretes.

## 🕹️ Funcionalidades

- Criação de lembretes informando nome e data do lembrete
-Validações ao criar um novo lembrete:
  - O campo "Nome" deve estar preenchido
  - O campo "Data" deve estar preenchido, e tem de estar no futuro
  - Caso os valores do campo sejam válidos, um novo lembrete é criado
  - Caso a data do lembrete já exista, ele é inserido dentro da lista referente àquele dia; caso não, um novo dia é exibido contendo o novo lembrete
- Visualizar os lembretes em forma de lista, em ordem cronológica
- Deletar um determinado lembrete

## 🚀 Como executar

Instale as dependências do projeto com o comando:

<pre> dotnet restore</pre>

### Para executar a aplicação:

- Execute o comando `dotnet run`

    <pre>dotnet run</pre>

Pronto, a aplicação já pode ser acessada em https://localhost:7253 ou http://localhost:5141
