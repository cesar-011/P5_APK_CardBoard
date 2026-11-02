using UnityEngine;

public class Recolectable : MonoBehaviour
{
    // Esta función se ejecuta cuando la mirada (Raycast) toca el objeto
    public void OnPointerEnter() 
    {
        // Desactiva el objeto (simula que lo has recogido)
        gameObject.SetActive(false);
    }

    public void OnPointerExit() { }
}