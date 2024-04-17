using UnityEngine;

public class Silla2 : MonoBehaviour
{
    private Temporizador2 temporizador; // Referencia al script Temporizador

    void Start()
    {
        temporizador = GameObject.Find("Temporizador2").GetComponent<Temporizador2>(); // Obtiene la referencia al script Temporizador
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag ("Enemigo")) // Si el jugador colisiona con la silla
        {
            temporizador.IniciarTemporizador(); // Envía un evento para iniciar el temporizador
        }
    }

}
