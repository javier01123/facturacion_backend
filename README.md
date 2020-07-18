# Implementación de una Clean Architecture en .NET

Implementación de una arquitectura limpia con .NET utilizando los principios de [Domain Driven Design](https://martinfowler.com/bliki/DomainDrivenDesign.html)

## Objetivo

Implementar una arquitectura limpia y escalable que sirva como referencia a los desarrolladores que comienzan
a trabajar con ella y con Domain Driven Design, resolver las dudas mas comunes a traves del ejemplo.

## Alcance

* Escogí implementar un back-end de facturación electrónica mexicano simplemente porque es en lo que tengo mas experiencia y puedo implementar casos de uso de la vida real, con el tiempo se implementarán mas funcionalidades, pero el principal objetivo de este proyecto no es un software de facturación que cumpla la legislación mexicana para facturación, sino una referencia técnica sobre arquitectura.
* El código debe mantenerse multiplataforma (compatible Linux y Windows)

## Estatus del proyecto

Este proyecto se encuentra en desarrollo

## Front-end implementado con React Js

Repositorio [Git](https://github.com/javier01123/facturacion_frontend)
Hospedado [aquí](https://facturacion-frontend-dev.herokuapp.com/)

## Onion Architecture
Onion Architecture se basa en el principio de inversión de control. 
Onion Architecture se compone de múltiples capas concéntricas que se interconectan entre sí hacia el núcleo que representa el dominio.
La arquitectura no depende de la capa de datos como en las arquitecturas clásicas de varios niveles, sino de los modelos de dominio reales.

![Capas en una Onion Architecture](https://raw.githubusercontent.com/javier01123/facturacion_backend/master/docs/onion_architecture.png)

## Diagrama Entidad-Relación

![EDR Diagram](https://raw.githubusercontent.com/javier01123/facturacion_backend/master/docs/FacturacionDb_EDR.png)

## Recursos

* Introducción Domain Driven Design [link](https://martinfowler.com/bliki/DomainDrivenDesign.html)
* Domain driven design de Scott Millet [link](https://www.oreilly.com/library/view/patterns-principles-and/9781118714706/)
* Clean Architecture [link](https://blog.cleancoder.com/uncle-bob/2012/08/13/the-clean-architecture.html)
* CQRS [link](https://martinfowler.com/bliki/CQRS.html)
* Hashing [link](https://docs.microsoft.com/en-us/dotnet/api/system.string.compareto?view=netcore-3.1)

## Herramientas

* PostgreSql [link](https://www.postgresql.org/)
* .NET Core 3.1 [link](https://dotnet.microsoft.com/download/dotnet-core/thank-you/sdk-3.1.302-windows-x64-installer)
* MediatR (bus de comunicación)[link](https://github.com/jbogard/MediatR)
* Visual Studio 2019 [link](https://visualstudio.microsoft.com/es/vs/community/)
* Docker [link](https://www.docker.com/)
