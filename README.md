# Práctica 1: Realidad Virtual con Google Cardboard

**Asignatura:** Interfaces Inteligentes
**Alumno:** César Navarro Santos
**Entorno de desarrollo:** Unity (Ubuntu Linux)
**Plataforma de destino:** Android (APK)

## Descripción del Proyecto
Esta práctica consiste en el desarrollo de una experiencia básica de Realidad Virtual utilizando el SDK de Google Cardboard para Unity. El objetivo principal es implementar mecánicas de interacción y locomoción basadas en la vista (gaze tracking) en un entorno 3D.

## Elementos de la Escena
La escena principal (`SampleScene`) está compuesta por los siguientes elementos:
*   **Terreno y Entorno:** Se ha diseñado un escenario utilizando un terreno básico de Unity decorado con objetos importados de la Asset Store (Paquete utilizado: *Low Poly Desert*
*   **Jugador (Player):** Configurado con la cámara principal y el sistema de puntero/retícula de Cardboard para detectar hacia dónde mira el usuario.
*   **Objetos Recolectables:** Diversos elementos distribuidos por el escenario con los que el jugador puede interactuar.

## Mecánicas Implementadas

### 1. Desplazamiento del Jugador
Se ha implementado un sistema de locomoción basado en la dirección de la mirada del usuario. Al no disponer de un mando físico, el jugador avanza de manera continua en la dirección hacia la que apunta la cámara (la vista). Esto se gestiona mediante un script personalizado asignado al jugador que actualiza el `Transform` basándose en `Camera.main.transform.forward`.

### 2. Sistema de Recuperación de Objetos
Se ha designado un objeto específico en la escena que actúa como "Recuperador". El comportamiento es el siguiente:
*   El objeto cuenta con un evento tipo *Pointer Enter*.
*   Cuando el jugador centra su vista (retícula de Cardboard) sobre este objeto, se ejecuta un script que localiza los objetos recolectables de la escena.
*   Los objetos recolectables se teletransportan instantáneamente a una posición justo frente al jugador (a 2 metros de distancia) y se reactivan, cumpliendo con el requisito de que "se dirigen hacia el jugador".

## Corrección de Errores (CardboardStartup.cs)
Para permitir la correcta compilación del proyecto y evitar el error `Please initialize Cardboard XR loader before calling this function` en el editor, se ha modificado el script proporcionado `CardboardStartup.cs`. 

Se han añadido directivas de preprocesador en la línea 70 para aislar la función `Api.UpdateScreenParams()`, quedando de la siguiente manera:

```csharp
#if !UNITY_EDITOR //Modificación
   Api.UpdateScreenParams(); //Línea en el código
#endif //Modificación
```

## Notas de Compilación y Testeo
El proyecto ha sido configurado y compilado exitosamente generando el archivo `.apk` adjunto en esta entrega. 

**Nota para la evaluación:** El desarrollo, la configuración de los perfiles de Android y la *Build* final se han realizado íntegramente en un entorno **Ubuntu**. Debido a la falta de disponibilidad de un dispositivo físico Android/VR para realizar pruebas (*Build And Run*), el funcionamiento de las mecánicas ha sido validado exclusivamente a través del simulador del propio editor de Unity.
