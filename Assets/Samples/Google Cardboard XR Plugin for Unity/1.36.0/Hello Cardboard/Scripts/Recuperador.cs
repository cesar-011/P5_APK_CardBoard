using UnityEngine;

public class Recuperador : MonoBehaviour
{
    public Transform jugador; // Arrastra el XR-Rig (Player) aquí en el Inspector
    public GameObject[] objetosRecolectables; // Arrastra todos tus recolectables aquí en el Inspector

    public void OnPointerEnter()
    {
        foreach (GameObject obj in objetosRecolectables)
        {
            if (!obj.activeSelf) // Si está recogido (inactivo)
            {
                // Mueve el objeto a la posición del jugador y actívalo
                obj.transform.position = jugador.position + (jugador.forward * 2f); // Aparece justo delante
                obj.SetActive(true);
            }
        }
    }

    public void OnPointerExit() { }
}