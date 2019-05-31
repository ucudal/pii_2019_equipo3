RESUMEN EJECUTIVO

El objetivo

Para este Proyecto, el centro Ignis se nos acercó con un propósito, crear una aplicación que implemente el desarrollo del programa Ignis Mercado.

Este programa incentiva el desarrollo del mercado audiovisual y la inserción al sector de estudiantes, egresados y docentes. De la forma que lo hace es unir técnicos capacitados en determinadas áreas (camarógrafos, sonidistas, etc) con clientes que buscan llevar a cabo sus propios proyectos audiovisuales.

Para llevar adelante esta consigna nos propusimos como objetivo principal el crear una interfaz accesible por los técnicos, los clientes y los empleados del centro Ignis que tengan acceso a la información del programa.

Otro de los pedidos que nos hizo el centro es la implementación de un sistema de retroalimentación o “feedback” con el cual, tras finalizado un proyecto, el cliente pueda describir su experiencia con el técnico y el servicio que este proporcionó.

Tras analizar las distintas alternativas llegamos a la conclusión de que la mejor manera de implementar esta instancia de feedback es dejando al cliente decidir si la experiencia fue positiva o negativa, y agregando un comentario justificándolo y detallando el desempeño del técnico.

La aplicación.

Se accede a la aplicación mediante una página de bienvenida, desde la cual se le permite al usuario ingresar a su cuenta.

La aplicación tiene acceso a información personal sobre todos los usuarios. Esta información es nombre completo, edad, mail y contraseña.

Al ingresar el usuario llega a una página de ingreso o Log In, en la cual deberá ingresar su correo electrónico y contraseña para acceder a su cuenta.

Al ingresar a la cuenta se despliega la página principal, la cual varia dependiendo del rol del usuario.

Técnicos.

Al ingresar ven 2 listados. Uno con los proyectos disponibles con los que cumplen los requisitos (especialización y nivel ya sea básico o avanzado) y otro de los proyectos que ya les han sido asignados.

Al clickear en un proyecto (sin importar el listado en el que se encuentra) , el técnico es redirigido a una página que muestra toda la información de éste.

En la página de un proyecto disponible, esta tambien la opción de aceptar el proyecto, y en la de los proyectos asignados tambien se muestra el feedback en caso de que el cliente ya lo haya proporcionado.


Clientes.

Los clientes tienen, en su página principal, un listado de los proyectos que tienen publicados, otro de los proyectos ya asignados a un técnico y la opción de agregar nuevos proyectos.


Al hacer click en un proyecto en particular son redireccionados a la página del proyecto.

Si es un proyecto publicado, la página muestra, ademas de la descripción del proyecto, una lista de los tecnicos disponibles. Si el cliente clickea en un técnico sera redireccionado a la pagina del técnico donde podra ver su perfil y tendrá la opción de elegirlo para el proyecto. Al elegirlo el proyecto deja de estar en la lista de proyectos publicados y pasa a la lista de proyectos asignados.

Si es un proyecto asignado, ademas de ver la descripción del proyecto, tiene la posibilidad de finalizar el proyecto. Para esto, debera ingresar el feedack, indicando si el desempeño del técnico fue positivo o negativo, y agregando un comentario.

Si en cambio, selecciona crear un nuevo proyecto, serán redireccionados a una página en la que deberán ingresar la información necesaria para ingresar este nuevo proyecto, y una vez finalizado aparecera en la lista de proyectos publicados.

Empleados.

Los empleados del centro Ignis ven desplegado un buscador que les permite buscar lo técnicos y los clientes que han sido registrados en el programa ingresando el correo del usuario a buscar.

Esta busqueda despliega la página del usuario, en la que ven la información del usuario.
Si el usuario es un cliente, ven además un listado de sus proyectos, tanto los publicados como los asignados. Si seleccionan un proyecto de la lista serán redireccionados a la página principal del proyecto que muestra la información de este y el técnico aplicado y el feedback (si esta asignado y el feedback ha sido ingresado).


Casos de interacción 
https://github.com/ucudal/pii_2019_equipo3/blob/federico/CasosInteraccion.png

Al entrar a la aplicación el usuario  va a tener una página de log in, la siguiente página va a variar según el tipo de usuario (cliente, técnico o empleado).

Clientes

⦁	En WebLogIn el cliente debe ingresar el nombre de usuario y la contraseña y clickear “ingresar”. La clase LogInValidate va a pedirle a la clase ClientDirectory que busque en la lista de clientes si el mail dado corresponde con la contraseña dada; si los datos son válidos el cliente es redirigido a la página WebMainClient.

⦁	Si el cliente clickea en “crear nuevo proyecto”, es redireccionado a la página WebClientProjectMaker.

⦁	Si en WebClientProjectMaker llena los datos requerido y clickea en “crear” la clase ProjectAllocator llama al método AddProject() de la clase cliente, creándose una nueva instancia de la clase Project (la cual aparece en la lista de proyectos publicados en WebMainClient).

⦁	Si el cliente clickea en su proyecto que aparece publicado en  WebMainClient (todavía no asignados a un técnico) se lo direcciona a la página WebClientProjectPublished del proyecto.

⦁	Si clickea en uno de los técnicos (que aparecen en WebClientProjectPublished) se redireccionará a la página WebClientTechnicianViewer donde podrá ver el feedback que tiene un técnico.

⦁	Si clickea en seleccionar técnico, la clase FinalTechnicianSelector ejecuta un método que borra el proyecto de la lista de proyectos publicados, y lo agrega al técnico seleccionado con  el método AddProject de ProjectAllocator .

⦁	En WebMainClient, si el cliente clickea en un proyecto en la lista de proyectos asignados, se redirecciona a la página WebClientProjectAssigned del proyecto.

⦁	Si en WebClientProjectAssigned el cliente selecciona “finalizar proyecto” se le redirecciona a la página “WebClientProjectFinisher”.

En WebClientProjectFinisher deberá ingresar el feedback, seleccionar positivo o negativo y agregar un comentario el cual va a ser guardado en un archivo por la clase Feedback para luego agregarlo al técnico. 


Técnicos

⦁ 	En WebLogIn el técnico debe ingresar el nombre de usuario y la contraseña y clickear “ingresar”. La clase LogInValidate va a pedirle a la clase TechniciansDirectory que busque en la lista de tecnicos si el mail dado corresponde con la contraseña dada; si los datos son válidos el cliente es redirigido a la página WebMainTechnicians.

⦁	Si el técnico clickea en un proyecto de la lista de proyectos disponibles será direccionado a la página WebTechnicianProjectAvailable del proyecto donde podrá ver la información de ese proyecto.

⦁	Si en WebTechnicianProjectAvailable el técnico clickea en “aceptar propuesta” se ejecutará un método de la clase ProjectAllocator el cual agrega el proyecto a la lista de la clase Technicians (sólo podrá aceptarla si no está en un proyecto actualmente )

⦁	Si en WebMainTechnician clickea en un proyecto que ya le asignaron  se le redireccionará a la página WebTechnicianProjectAssigned del proyecto con la información del mismo.


Empleados

⦁	En WebLogIn el empleado debe ingresar el nombre de usuario y la contraseña y clickear “ingresar”. La clase LogInValidate va a pedirle a la clase EmployeeDirectory que busque en la lista de empleados  si el mail dado corresponde con la contraseña dada; si los datos son válidos el cliente es redirigido a la página WebMainEmployee.


En WebMainEmployee el empleado debe ingresar un correo en el buscador y seleccionar una de las tres opciones (clickeando en el botón correspondiente).

⦁	Si clickea en “buscar técnico” se redireccionará a la página WebEmployeeTechnicianViewer del técnico que tiene el email ingresado.

⦁	Si clickea en “buscar cliente” se redireccionará a la página WebEmployeeClientViewer del cliente  que tiene el email ingresado. Tambien podra ver los proyectos de cada cliente en el WebEmployeeViewerProject.
