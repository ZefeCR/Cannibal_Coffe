using UnityEngine;

public class Silla4 : MonoBehaviour
{
    private Temporizador4 temporizador; // Referencia al script Temporizador

    void Start()
    {
        temporizador = GameObject.Find("Temporizador4").GetComponent<Temporizador4>(); // Obtiene la referencia al script Temporizador
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag ("Enemigo")) // Si el jugador colisiona con la silla
        {
            temporizador.IniciarTemporizador(); // Envía un evento para iniciar el temporizador
        }
    }

}
