# picpay-api-dotnet

[![NuGet Badge](https://buildstats.info/nuget/PicPayDotnet)](https://www.nuget.org/packages/PicPayDotnet)
![GitHub repo size](https://img.shields.io/github/repo-size/ManuMelva/picpay-api-dotnet?style=for-the-badge)
![GitHub language count](https://img.shields.io/github/languages/count/ManuMelva/picpay-api-dotnet?style=for-the-badge)
![GitHub forks](https://img.shields.io/github/forks/ManuMelva/picpay-api-dotnet?style=for-the-badge)
![Bitbucket open issues](https://img.shields.io/bitbucket/issues/ManuMelva/picpay-api-dotnet?style=for-the-badge)
![Bitbucket open pull requests](https://img.shields.io/bitbucket/pr-raw/ManuMelva/picpay-api-dotnet?style=for-the-badge)

<img src="PicPayDotnet/Icon/PicPay.png" alt="PicPay Image">

> Métodos responsáveis para consumir e utilizar a api do PicPay, com alguns adicionais.

## Índice - C#
- [Instalação](#instalação)
- [Configurações Iniciais](#configurações-iniciais)
- [Métodos](#usando-a-api)
  - [Criar request de pagamento](#criar-request-de-pagamento)
  - [Consultar request de Pagamento](#consultar-request-de-pagamento)
  - [Cancelar request de Pagamento](#cancelar-request-de-pagamento)

## 🚀 Instalação

Execute o comando para instalar via [NuGet](https://www.nuget.org/packages/PicPayDotnet/):

```.net cli
> dotnet add package PicPayDotnet
```

## 💻 Configurações Iniciais
Para configurar o ambiente e utilizar o client existem duas formas distintas e cabe ao desenvolvedor escolher a que mais se adeque ao projeto.

A primeira forma é utilizando por meio do IHttpClientFactory e de um Service Provider, e deixando a extensão da Microsoft fazer o gerenciamento do HttpClient durante a vida da sua aplicação.
Exemplo:
```C#
public static ServiceProvider ServiceProvider { get; set; }
public const string PicPayClient = "PicPayClient"; // Este deve ser sempre o Nome do HttpClient nomeado

// Geralmente esta configuração é feita em algum momento da sua aplicação e se mantém por toda ela

var serviceCollection = new ServiceCollection().AddHttpClient();
serviceCollection.AddHttpClient(PicPayClient, Client =>
{
    Client.BaseAddress = new Uri("https://appws.picpay.com/ecommerce/public/");
    Client.DefaultRequestHeaders.Add("x-picpay-token", "Your-Token-HERE");
    Client.DefaultRequestHeaders.Add("user-agent", JSONExtension.GetUserAgent());
    Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
});
ServiceProvider = serviceCollection.BuildServiceProvider();

var client = new PicPayClient(ServiceProvider);
```

Ou ainda pode ser feita por meio da Dependency Injection, atráves do PicPayConfiguration. Exemplo:
```C#

var config = new PicPayConfiguration
{
    URL = "URL-API",
    PicPayToken = "Your-Token-HERE"
};

var client = new PicPayClient(config);
```

Quaisquer dúvidas adicionais, segue a documentação oficial: [API Refence](https://picpay.github.io/picpay-docs-digital-payments/checkout/resources/api-reference)

## ☕ Usando a API

## Criar request de pagamento
```C#
var request = new PicPayPaymentRequest
{
    ReferenceId = "1029",
    CallbackUrl = "http://www.sualoja.com.br/",
    ReturnUrl = "http://www.picpay.com/#transacaoConcluida",
    ExpiraEm = DateTime.Now.AddMinutes(30),
    Valor = 1,
    Buyer = new PicPayBuyer
    {
        Nome = "TesTe",
        Sobrenome = "Teste",
        Documento = "99999999999",
    }
};

var response_pagamento = await _client.CreateRequest(request);
```

## Consultar request de Pagamento
```C#
var response = await _client.GetStatusAsync("1029");
```

## Cancelar request de Pagamento
```C#
var request = new PicPayPaymentRequest
{
    AuthorizationId = "555008cef7f321d00ef236333",
    Valor = 1,
    ReferenceId = "1029"
};

var response_cancel = await _client.CancelRequestAsync(request);
```

## 📫 Contribuindo para PicPay_API

Para contribuir com PicPay_API, siga estas etapas:

1. Bifurque este repositório.
2. Crie um branch: `git checkout -b <Nome da Branch>`.
3. Faça suas alterações e confirme-as: `git commit -m 'Sua Mensagem'`
4. Envie para o branch original: `git push origin picpay-api-dotnet / <local>`
5. Crie a solicitação de pull.

Como alternativa, consulte a documentação do GitHub em [como criar uma solicitação pull](https://help.github.com/en/github/collaborating-with-issues-and-pull-requests/creating-a-pull-request).

## 🤝 Colaboradores

Agradecemos às seguintes pessoas que contribuíram para este projeto:

<table>
  <tr>
    <td align="center">
      <a href="https://github.com/ManuMelva" title="">
        <img src="https://github.com/ManuMelva.png" width="100px;" alt=""/><br>
        <sub>
          <b>Emmanuel Silva</b>
        </sub>
      </a>
    </td>
  </tr>
</table>

## 📝 Licença

Esse projeto está sob licença MIT. Veja o arquivo [LICENÇA](LICENSE) para mais detalhes.
