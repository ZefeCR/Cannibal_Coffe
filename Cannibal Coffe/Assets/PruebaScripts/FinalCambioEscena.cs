using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinalCambioEscena : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemigo")) // Si el jugador colisiona con la silla
        {
            SceneManager.LoadScene("Final");
        }
        
    }
}
