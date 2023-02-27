# ByCoders
Estrutura

Muito embora esteja em uma Unica Solution, ela foi construida em cima de critérios usados em arquitetura de microserviços, cada api, consegue ser completamente
independente

O aplicativo é segregado em 4 projetos
1 website
2 Identity
3 API
4 Core
------------------------------------------------------------
1- Web
uma camada MVC com núcleo razor asp.net que basicamente é a interface visual do aplicativo
------------------------------------------------------------
2- Identity

Para o contexto de usuários do sistema, configurei uma API segregada, usando Identity (https://jakeydocs.readthedocs.io/en/latest/security/authentication/identity.html)
Cuja única responsabilidade é cuidar dos usuários que o aplicativo usa
------------------------------------------------------------

3- Domain API

Outra api segregada, que já obedece critérios DDD e princípios SOLID, as Entidades são mapeadas dentro da camada Domínio.
E fiz uso do padrão mediator (https://www.dotnettricks.com/learn/designpatterns/mediator-design-pattern-c-sharp)
Não aproveitei totalmente a arquitetura CQRS, pois não criei outro projeto para ler os dados, guardei apenas em um
------------------------------------------------------------
4 -Core

um projeto Class Lib que é basicamente onde eu uso o compartilhamento TOKEN.
Porque o mesmo token que é gerado na camada 2 -Identity,
também é usado na camada 3- Domínio API
------------------------------------------------------------


Formato de Autenticação

Para os critérios de autenticação trabalhei com JWT, e o mesmo token gerado é compartilhado entre todas as aplicações

é possível atribuir várias funcionalidades como SSO e Refresh Token, acredito que você esteja trabalhando com IdentityServer, por isso você pediu para usar OAUTH
------------------------------------------------------------
Resiliência

Para problemas de resiliência, estou trabalhando com Polly e Circuit Breaker (https://www.twilio.com/blog/using-polly-circuit-breakers-resilient-net-web-service-consumers)
Pode ser visto na camada 1-teia

------------------------------------------------------------

Testes Unitarios

Não implementei uma camada de teste, porque já estava com pouco tempo, mas gosto muito de trabalhar com o XUNIT



Obs: Para que a aplicaçao rode, deve ser executado simultaneamente as aplicaçao 1,2,3. irei vincular uma imagem para facilitar a compreensão, junto com o script de base de 
dados.


Todas as aplicações que fizeram uso de base de dados, foi usado EF Core e Migrations.

Espero que gostem =)
