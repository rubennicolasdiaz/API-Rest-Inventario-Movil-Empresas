# API Rest Inventario Móvil Empresas
API Rest Inventario Móvil Empresas es una API Rest para cargar y descargar ficheros, pensada para ser consumida por una app Android para el control y gestión de inventarios. 

### Funcionamiento
La API Rest funciona con una serie de endpoints donde podremos subir y bajar ficheros, pero sólo de tipo Json. Además, se ha incorporado un login con una base de datos en la nube compartido con la app Android. Para simular un entorno profesional, la autenticación para usar la API se realiza con JWT (Json Web Token). Este token se le proporciona al usuario autenticado tanto en la app Android como en la API Rest y es válido mientras dure la sesión.

Durante dicha sesión, podremos descargar de nuestra API los ficheros de productos correspondientes a nuestra empresa, ya que cada email de usuario para el login tiene un único código de empresa en la base de datos. De este modo, dependiendo del email del usuario que se autentique, se bajarán y subirán sólo los ficheros correspondientes a su empresa. 

Una vez que el usuario ha terminado de usar la App Android y ha finalizado el conteo o actualización de stock de sus productos, se sube un fichero a la API Rest actualizando las unidades de los productos que haya registrado. De esta forma, se automatiza la actualización de stocks del inventario de cualquier empresa registrada. 

### Ubicación y alcance de la API
La API Rest de momento funciona en un entorno local y simula un entorno similar al empresarial, donde tendríamos decenas o cientos de empresas registradas en nuestra base de datos. A cada una de estas empresas se le gestiona el inventario, conteo y cambios en el stock de su catálogo de productos. 

Para mayor información, se puede revisar el código fuente en este mismo repositorio o visitar el vídeo explicativo del funcionamiento de la app: https://youtu.be/BRw1Nm-OryU