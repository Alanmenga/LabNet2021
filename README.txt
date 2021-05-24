Este es mi trabajo de frontend en angular.
Es una aplicacion que desde la seccion productos/regiones muestra un listado de los mismos cargados en una base de datos.
Cuenta con una seccion de agregar o modificar productos/regiones.


Hay un error en la parte de regiones. Al querer agregar una region no me deja porque desde la base de datos esta seteado que el RegionId no sea auto-incremental. Trate de solucionarlo desde el SSMS pero no pude.


Tambien tuve errores de parte de Chrome a la hora de hacer algunas peticiones porque no me daba la autorizacion de los CORS lo solucione cambiando las propiedades del navegador.
Haciendo click derecho en el acceso directo del google chrome, en la pestaña de Shortcut
el item Target copie la siguiente linea -->"C:\Program Files (x86)\Google\Chrome\Application\chrome.exe" --user-data-dir="C:/Chrome dev session" --disable-web-security<--
y con eso me funciono perfectamente.