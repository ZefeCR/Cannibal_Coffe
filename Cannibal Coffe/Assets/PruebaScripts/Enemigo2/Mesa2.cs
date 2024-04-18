using UnityEngine;

public class Mesa2 : MonoBehaviour
{
    public Temporizadorv2 temporizador2; // Referencia al script Temporizador
    void Start()
    {
        temporizador2 = GameObject.Find("Temporizador2").GetComponent<Temporizadorv2>(); // Obtiene la referencia al script Temporizador
    }

    public void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Comida") // Si el alimento colisiona con la mesa
        {
            temporizador2.DetenerTemporizador(); // Envía un evento para detener el temporizador
            temporizador2.enabled = false; // Desactiva el temporizador
        }
    }
}

