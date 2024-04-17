using UnityEngine;

public class Mesa : MonoBehaviour
{
    public Temporizador temporizador; // Referencia al script Temporizador
    void Start()
    {
        temporizador = GameObject.Find("Temporizador1").GetComponent<Temporizador>(); // Obtiene la referencia al script Temporizador
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Comida") // Si el alimento colisiona con la mesa
        {
            temporizador.DetenerTemporizador(); // Envía un evento para detener el temporizador
        }
    }

}

