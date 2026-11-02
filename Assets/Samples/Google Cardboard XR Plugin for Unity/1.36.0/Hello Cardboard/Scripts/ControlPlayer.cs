using UnityEngine;

public class ControlPlayer : MonoBehaviour
{
    public Transform camara; 
    
    public float speed = 3f; // Velocidad del jugador

    void Update()
    {
        // Detecta si se está tocando la pantalla del móvil o haciendo clic en el editor
        if (Input.GetMouseButton(0) || Input.touchCount > 0)
        {
            // Obtiene la dirección hacia la que mira la cámara
            Vector3 direccion = camara.forward;
            
            // Anulamos el eje Y para que el jugador no vuele ni se hunda en el terreno al mirar arriba o abajo
            direccion.y = 0;
            direccion.Normalize();
            
            // Desplaza al objeto Player
            transform.position += direccion * speed * Time.deltaTime;
        }
    }
}