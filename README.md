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

## Documentación del API utilizando Swagger

Lo puedes consultar en el hosting para demostración en [heroku](https://facturacion-backend-dev.herokuapp.com/)

## Onion Architecture
Onion Architecture se basa en el principio de inversión de control. 
Onion Architecture se compone de múltiples capas concéntricas que se interconectan entre sí hacia el núcleo que representa el dominio.
La arquitectura no depende de la capa de datos como en las arquitecturas clásicas de varios niveles, sino de los modelos de dominio reales.

![Capas en una Onion Architecture](https://raw.githubusercontent.com/javier01123/facturacion_backend/master/docs/onion_architecture.png)


## Front-end implementado con React Js

Repositorio [Git](https://github.com/javier01123/facturacion_frontend)
Hospedado [aquí](https://facturacion-frontend-dev.herokuapp.com/)


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

## Github Actions

El repositorio utiliza Gihub Actions para ejecutar las pruebas cada vez que se sube un commit al repositorio, si las pruebas pasan entonces se hace el deploy automáticamente a heroku.

El archivo del workflow es [este](https://raw.githubusercontent.com/javier01123/facturacion_backend/master/.github/workflows/test_and_deploy.yml)

Para la autenticación en heroku a traves de consola se debe obtener el token [aquí](https://devcenter.heroku.com/articles/authentication) y crear el SECRET en github.


## Autenticación

El API utiliza una cookie HTTP Only para la autenticación de los usuarios. Este tipo de cookies no se pueden manipuar con javascript, lo que la hace mas seguro, el navegador y cliente http se encargan de almacenarla.  

En las pruebas de integración por eso debe llamarse primero a la API para autenticarse y despues utilizar ese misma instancia del cliente para realizar los requests.

## Lista de pendientes

* Implementar un Unit Of Work que incluya los repositorios para simplificar la inyeccion.
* Crear pruebas unitarias a nivel de caso de uso para simplificar y disminuir el coupling entre los unit test y la implementación del modelo.
* Agregar ejemplos para manejo de eventos internos
* Agregar ejemplos del uso de Fakes. Documentar diferencias Mocks vs Fakes.

## Recursos

* Introducción Domain Driven Design [link](https://martinfowler.com/bliki/DomainDrivenDesign.html)
* Domain driven design de Scott Millet [link](https://www.oreilly.com/library/view/patterns-principles-and/9781118714706/)
* Clean Architecture [link](https://blog.cleancoder.com/uncle-bob/2012/08/13/the-clean-architecture.html)
* Architecture Patterns with Python, un libro muy útil incluso para otros lenguajes. También planeo una implementación en este lenguaje [link](https://www.oreilly.com/library/view/architecture-patterns-with/9781492052197/)
* CQRS [link](https://martinfowler.com/bliki/CQRS.html)
* Hashing [link](https://docs.microsoft.com/en-us/dotnet/api/system.string.compareto?view=netcore-3.1)

## Herramientas

* PostgreSql 12.3 [link](https://www.postgresql.org/)
* .NET Core 3.1 [link](https://dotnet.microsoft.com/download/dotnet-core/thank-you/sdk-3.1.302-windows-x64-installer)
* MediatR (bus de comunicación)[link](https://github.com/jbogard/MediatR)
* Visual Studio 2019 [link](https://visualstudio.microsoft.com/es/vs/community/)
* Docker [link](https://www.docker.com/)
* Swagger [link](https://swagger.io/)
* NUnit [Test Framework](https://nunit.org/)