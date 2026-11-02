using UnityEngine;

public class CameraPointer : MonoBehaviour
{
    private const float maxDistance = 20f; // Distancia máxima del Raycast
    private GameObject gazedAtObject = null;

    void Update()
    {
        RaycastHit hit;
        // Lanza el rayo desde el origen (cámara) hacia adelante
        if (Physics.Raycast(transform.position, transform.forward, out hit, maxDistance))
        {
            // Si el rayo choca con un objeto nuevo
            if (gazedAtObject != hit.transform.gameObject)
            {
                // Avisamos al objeto anterior que ya no lo miramos
                if (gazedAtObject != null)
                {
                    gazedAtObject.SendMessage("OnPointerExit", SendMessageOptions.DontRequireReceiver);
                }
                
                // Registramos el nuevo objeto y le avisamos que lo estamos mirando
                gazedAtObject = hit.transform.gameObject;
                gazedAtObject.SendMessage("OnPointerEnter", SendMessageOptions.DontRequireReceiver);
            }
        }
        else
        {
            // Si el rayo no choca con nada pero antes mirábamos un objeto
            if (gazedAtObject != null)
            {
                gazedAtObject.SendMessage("OnPointerExit", SendMessageOptions.DontRequireReceiver);
                gazedAtObject = null;
            }
        }
    }
}