using UnityEngine;

public class Silla3 : MonoBehaviour
{
    private Temporizador3 temporizador3; // Referencia al script Temporizador

    void Start()
    {
        temporizador3 = GameObject.Find("Temporizador3").GetComponent<Temporizador3>(); // Obtiene la referencia al script Temporizador
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag ("Enemigo")) // Si el jugador colisiona con la silla
        {
            temporizador3.IniciarTemporizador(); // Envía un evento para iniciar el temporizador
        }
    }

}
