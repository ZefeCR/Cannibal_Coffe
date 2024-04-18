using UnityEngine;

public class Silla2 : MonoBehaviour
{
    private Temporizadorv2 temporizador2; // Referencia al script Temporizador

    void Start()
    {
        temporizador2 = GameObject.Find("Temporizador2").GetComponent<Temporizadorv2>(); // Obtiene la referencia al script Temporizador
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag ("Enemigo")) // Si el jugador colisiona con la silla
        {
            temporizador2.IniciarTemporizador(); // Envía un evento para iniciar el temporizador
        }
        
    }

}
