# RESTExercise
Ejercicio para crear una API REST con autenticación anónima.
Es un pequeño ejemplo con una estructura de proyectos orientada al dominio. 
El proyecto utiliza una base de datos de sql server local creada con code first.
La cadena de conexión apunta a (LocalDb)\MSSQLLocalDB. Esto puede ser modificado por cualquier servidor de sql server del que se disponga.
Antes de nada, desde la ventana Package Manager Console, seleccionando el proyecto Data, es necesario ejecutar el comando Update-DataBase.
Después ejecutar todos los Tests desde Test Explorer.
Para poder probarlo en modo debug es necesario levantar la API con una nueva instancia debug y el proyecto de consola con otra instancia.
El proyecto de consola sirve unicamente para mostrar los 4 procesos de la API.
