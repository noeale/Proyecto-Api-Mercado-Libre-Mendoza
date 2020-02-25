# Proyecto-Api-Mercado-Libre-Mendoza
Api para verificar mutantes
http://testmutante.azurewebsites.net/mutant/
http://testmutante.azurewebsites.net/stats/

### Especificaciones

* El Objetivo principal del proyecto era detectar que si el ADN ingresado era de un mutante o una persona.
Pasos que se realizaron para llevar a cabo el objetivo propuesto:
  * 1-Lo primero que se tuvo en cuenta fue verificar que matriz sea de NXN.
  * 2-Despues se lee el arreglo que del ADN y se lo convierte en una matriz analizando a su vez que este dentro de los parametros de Nitrogenada. Una vez analizado eso se previo los dos casos posibles:
      * a- Caso 1: el ADN analizado no es correcto -> se muestra un error que el ADN analizado no es correcto por encontrarse fuera de                      los paremetros.
      * b- Caso 2: El ADN esta dentro de la base Nitrogenada por lo cual se puede buscar si es o no un mutante.
  * 3- Se realiza las búsqueda donde si se ecuentran mas de dos secuencia de cuatro letras seguidas igualesde forma vertical, horizontal y oblicua(tanto de izquierda a derecha como derecha a izquierda) se dice que ES UN MUTANTE caso contrario es un humano y se guarda en la base de datos como tal.
  
* Lo otro que se realizo fue traer también en el servicio la estadistica donde muestra las cantidad de mutantes, humanos y su ratio.


### Implementacion y tecnologias usadas

- Se utilizó como lenguaje de programacion .Net C# netCore
- Base de datos SQL Server
- Para realizar las pruebas unitarias XUnites
- Para probar la Api se utilizo como herramienta[swagger](https://swagger.io/)
- Arquitectura utilizada [N Capas](https://www.bing.com/images/search?view=detailV2&ccid=sexn%2b%2fYm&id=4599D6E8FA2FACABAB3EF1AE7D22BEC516AAE16E&thid=OIP.sexn-_YmKsfkSKYeq3WQswHaFj&mediaurl=https%3a%2f%2fi.ytimg.com%2fvi%2fVRQplnnYdZ0%2fhqdefault.jpg&exph=360&expw=480&q=arquitectura+en+capas&simid=608034825958788231&selectedIndex=0&qpvt=arquitectura+en+capas&ajaxhist=0)

### Comentarios relevantes
Cuando comence a realizar el ejercicio lo desarrolle con NET Core por lo que tuve la oportunidad de aprender y llevarlo acabo asi tambien como el uso de los Test y Azure.






