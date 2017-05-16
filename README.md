<h1>RESTExercise</h1>

<p>Ejercicio para crear una API REST con autenticación anónima.</p>
<p>Es un pequeño ejemplo con una estructura de proyectos orientada al dominio.</p>
<p>El proyecto utiliza una base de datos de sql server local creada con code first.</p>
<p>La cadena de conexión apunta a (LocalDb)\MSSQLLocalDB. Esto puede ser modificado por cualquier servidor de sql server del que se disponga.</p>
<p>Antes de nada, desde la ventana Package Manager Console, seleccionando el proyecto Data, es necesario ejecutar el comando Update-DataBase.</p>
<p>Después ejecutar todos los Tests desde Test Explorer.</p>
<p>Para poder probarlo en modo debug es necesario levantar la API con una nueva instancia debug y el proyecto de consola con otra instancia.</p>
<p>El proyecto de consola sirve unicamente para mostrar los 4 procesos de la API.</p>
<p>En el controlador de la API no se ha introducido lógica para enviar el resultado de la petición. Siempre se envía OK. En lugar de NotFound se enviará una excepción del Tipo BusinessException.</p>
