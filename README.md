# Proyectos desarrollados en ASP.NET Core

## Problema con las bases de datos
Los proyectos presentados en este repositorio estaban conectados a bases de datos alojados en servidores otorgados por los profesores del proyecto, ya no posee acceso al servidor por lo que no puedo obtener la información almacenada en la base de datos (caso del WebApi) y, en caso del blog, la base de datos estaba relacionada a una imagen adaptada para Docker, pero al cambiar de equipo perdí dicha imagen, por lo que tampoco me es posible consultar dicha información.

## Web Api

Una API es un servicio(s) que permite que otros servicios se comunique con ella y acceda a sus funcionalidades sin conocer detalles de como se implementa. Está API permite agregar u obtener información almacenada en una base de datos de elementos de la universidad que se deseaban representar en un mundo virtual creado en Unity. 

En dicho proyecto el API permitía que una página web, desarrollada con Blazor que también pertenece a ASP.NET Core, y un videojuego, desarrollado en Unity usando C#, obtenga o agregue información para que se represente la información obtenida de una manera gráfica.

Está desarrollada utilizanda: 
- **Arquitectura limpia**: Separado en capas, donde cada una realiza las siguientes tareas:
  - **Dominio**: Contiene las entidades y las reglas de negocio del dominio de la aplicación.
  - **Aplicación**: Define las funcionalidades que realiza el sistema y gestiona las reglas de negocio de la apliación.
  - **Infraestructura**: Se ocupa la comunicación con servicios externos de los que extrae información, en este caso una base de datos.
  - **Presentación**: Se encarga de interactuar con el usuario final y todo lo relacionado a la presentación de información y captación de entrada de usuario.
- **Pruebas**: La API tiene pruebas en las capas de Dominio, Aplicación e Infraestructura que permiten asegurar que el sistema cumple con el comportamiento esperado.
-  **Base de datos**: El API obtiene información de una base de datos relacional en Microsoft SQL Server 2019 a través de consultas realizadas a través de SQL.

## Web Blog

Este proyecto consistía en programar un blog utilizando la arquitectura de Modelo Vista Controlador (MVC) que permita tener usuarios, leer y crear publicaciones, asociadas a un usuario que se considera su autor, que puede recibir comentarios por parte de otros usuarios sobre el tema tratado.

Está desarrollado utilizando:
- **Arquitectura Modelo-Vista-Controlador**: Dividido en tres capas con responsabilidades claras:
  - **Modelo**: Se encarga de la lógica de negocio y manejo de datos (comunicación con bases de datos y manipulación de estos).
  - **Vista**: Se encarga de la presentación de la interfaz de usuario y las interacciones con estos.
  - **Controlador**: Maneja las acciones del usuario, su interpretación y como reaccionar a dichas acciones. Actúa como intermediario entre el Modelo y la Vista.
- **Usuarios**: Maneja usuarios almacenados en Azure, con su respectivo usuario, correo electrónico, datos personales y contraseñas relacionados. Aprovecha la protección de datos proporcionada por Azure. 
- **Base de datos**: El API obtiene información de una base de datos relacional en Microsoft SQL Server 2019 a través de consultas realizadas a través de SQL.
- **Docker**: Se hizo uso de Docker para ejecutar una imagen de la base de datos para que no sea necesario un servidor para hacer uso de la base de datos del programa.
