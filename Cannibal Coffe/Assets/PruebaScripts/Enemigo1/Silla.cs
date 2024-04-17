using UnityEngine;

public class Silla : MonoBehaviour
{
    private Temporizador temporizador; // Referencia al script Temporizador

    void Start()
    {
        temporizador = GameObject.Find("Temporizador1").GetComponent<Temporizador>(); // Obtiene la referencia al script Temporizador
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag ("Enemigo")) // Si el jugador colisiona con la silla
        {
            temporizador.IniciarTemporizador(); // Envía un evento para iniciar el temporizador
        }
    }

}
