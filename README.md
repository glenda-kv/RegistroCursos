\# Sistema de Registro de Cursos



\## Descripción



Aplicación web desarrollada para gestionar el registro de estudiantes en cursos académicos.



El sistema permite administrar la información de estudiantes, cursos, docentes, carreras y facultades, además de realizar inscripciones de estudiantes a cursos.



\## Tecnologías utilizadas



\- Lenguaje: C#

\- Framework: ASP.NET Core MVC (.NET 8)

\- IDE: Visual Studio 2022

\- Base de datos: PostgreSQL

\- ORM: Entity Framework Core





\## Base de datos



Motor utilizado:



PostgreSQL



Nombre de la base de datos:



RegistroCursosDB



\#Configuración de la base de Datos



1\. Crear una base de datos llamada:



RegistroCursosDB



2\. Ejecutar el archivo:



datos.sql



3\. Modificar la contraseña del usuario PostgreSQL en:



appsettings.json



4\. Ejecutar el proyecto desde Visual Studio.





\## Modo de conexión



La aplicación utiliza Entity Framework Core mediante la clase:



ApplicationDbContext



para realizar la conexión entre la aplicación desarrollada en C# y PostgreSQL.





\## Funcionalidad CRUD implementada



Entidad seleccionada:



Inscripción





Operaciones disponibles:



\- Crear una inscripción de estudiante a un curso.

\- Listar inscripciones registradas.

\- Actualizar información de una inscripción.

\- Eliminar una inscripción.





\## Estructura del proyecto



\- Models: contiene las entidades del sistema.

\- Data: contiene la configuración de conexión a la base de datos.

\- Controllers: contiene la lógica de la aplicación.

\- Views: contiene la interfaz gráfica.

