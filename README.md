· Primera prueba de actuación en clase de tecnologías

Ortdur's Gate 3 es la tercera entrada del aclamado videojuego RPG Ortdur's Gate, ideado por los estudiantes de Desarrollo de Videojuegos 2 de Ingeniería en Sistemas y Producción 4 de Licenciatura en Animación y Videojuegos. El alcance de la electiva es acotado, y la Proof of Concept (PoC) fue implementada en una herramienta de scripting visual.

![alt text](https://github.com/jirabedra/pac-1-grooming/blob/main/poster.png?raw=true)


Para poder llevar el proyecto a un nuevo nivel, las funcionalidades de la PoC del juego deben implementarse en un lenguaje de programación tradicional. Por fortuna, los estudiantes de la electiva están familiarizados con el motor de videojuegos Unity. Unity usa .NET C#.

Es por esto que le pidieron ayuda a los estudiantes de DA2. Para poder ayudarlos, los estudiantes de DA2 deben trabajar en las funcionalidades de:
- Obtener inventario de un personaje
- Actualizar el inventario de un personaje
- Crear un personaje

Cada estudiante debe elegir dos de las tres funcionalidades (endpoints) disponibles. Además deben:

- Completar las pruebas unitarias del controlador que se encuentra en la API de la solución InventoryApi.Tests. Se deben elegir DOS de las TRES funcionalidades.
- Implementar, a partir de TDD, la capa de servicios. Deben tener un total de TRES pruebas unitarias en la capa de servicios, para los métodos elegidos. Al menos UNA debe ser una prueba para caso de error.
- Deben implementar inyección de dependencias para para poder probar la colección de pruebas de Postman sencilla que brindamos.
- Ya tienen implementada una capa de acceso a datos con acceso a una base de datos en memoria que funciona. No deben modificar esto (no les conviene :D )
- La prueba es individual, con material (perfectamente pueden usar inteligencia artificial generativa), presencial y el límite es de 45 minutos.

No se olviden de pushear sus cambios antes del límite de tiempo.

Cuentan con un objeto DataInitializer con datos de prueba muy útiles y realistas si quieren realizar pruebas funcionales de vuestro sistema. Esto no es obligatorio.
