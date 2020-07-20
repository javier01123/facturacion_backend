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


## Onion Architecture
Onion Architecture se basa en el principio de inversión de control. 
Onion Architecture se compone de múltiples capas concéntricas que se interconectan entre sí hacia el núcleo que representa el dominio.
La arquitectura no depende de la capa de datos como en las arquitecturas clásicas de varios niveles, sino de los modelos de dominio reales.

![Capas en una Onion Architecture](https://raw.githubusercontent.com/javier01123/facturacion_backend/master/docs/onion_architecture.png)


## Estrucutra de los proyectos

**Facturacion.API (Presentation)**  
En esta capa se encuentra la implementacion de la Web API y la configuración para el inicio de la aplicación.

**Facturacion.Domain**  
Es la capa central de la aplicación, aquí se debe implementar toda la lógica de negocio. Debe ser ignorante de otras capas y sobre todo de la base de datos.   

**Facturacion.Application**  
En esta capa se implementan los casos de uso y las transacciones.  
Se encarga de cordinar las llamadas a los objetos de dominio y llamadas a servicios externos a través de sus interfaces.

**Facturacion.Infrastructure**  
En esta capa se deben implementar las dependencias a servicios externos como Web services, bases de datos, servicios de email, etc.,por tanto, esta capa es la que tiene depenencia a las librerias, librando a las otras capas de [complejidad accidental.](https://www.nutshell.com/blog/accidental-complexity-software-design/)

## Documentación del API utilizando Swagger

Lo puedes consultar en el hosting para demostración [link](https://facturacion-backend-dev.herokuapp.com/)

## Front-end implementado con React Js

Repositorio [Git](https://github.com/javier01123/facturacion_frontend)
Hospedado [aquí](https://facturacion-frontend-dev.herokuapp.com/)

## Diagrama Entidad-Relación

![EDR Diagram](https://raw.githubusercontent.com/javier01123/facturacion_backend/master/docs/FacturacionDb_EDR.png)

## Testing

### Pruebas unitarias (Unit Tests)

* Estas pruebas automatizadas deben validar pequeñas partes de código.
* No deben llamar servicios externos, estos deben reemplazarse con [Mocks](https://en.wikipedia.org/wiki/Mock_object)
* Deben ser rápidas.

### Pruebas de integración (Integration Tests)

* Se utilizan para verificar que el sistema funciona como un todo.
* Pueden llamar a servicios externos (como bases de datos)
* Deben probar servicios de los cuales se tiene el control total (Bases de datos). 
* Servicios externos  no controlados que producen salidas visibles a softwares externos deben ser reemplazados con un Mock. (Smtp servers)

La relación de pruebas unitarias y pruebas de integración  pueden variar en cada proyecto, pero la regla general es probar la mayoria de edge cases posibles con pruebas unitarias. Probar un happy path con con la pruebas de integración y edge cases que no se puedan abarcar con pruebas unitarias.

## Recursos

* Introducción Domain Driven Design [link](https://martinfowler.com/bliki/DomainDrivenDesign.html)
* Domain driven design de Scott Millet [link](https://www.oreilly.com/library/view/patterns-principles-and/9781118714706/)
* Clean Architecture [link](https://blog.cleancoder.com/uncle-bob/2012/08/13/the-clean-architecture.html)
* CQRS [link](https://martinfowler.com/bliki/CQRS.html)
* Hashing [link](https://docs.microsoft.com/en-us/dotnet/api/system.string.compareto?view=netcore-3.1)

## Herramientas

* PostgreSql 12.3 [link](https://www.postgresql.org/)
* .NET Core 3.1 [link](https://dotnet.microsoft.com/download/dotnet-core/thank-you/sdk-3.1.302-windows-x64-installer)
* MediatR (bus de comunicación)[link](https://github.com/jbogard/MediatR)
* Visual Studio 2019 [link](https://visualstudio.microsoft.com/es/vs/community/)
* Docker [link](https://www.docker.com/)
* Swagger [link](https://swagger.io/)
* NUnit (Test Framework)[https://nunit.org/]