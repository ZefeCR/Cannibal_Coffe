using UnityEngine;

public class Mesa3 : MonoBehaviour
{
    public Temporizador3 temporizador2; // Referencia al script Temporizador
    void Start()
    {
        temporizador2 = GameObject.Find("Temporizador3").GetComponent<Temporizador3>(); // Obtiene la referencia al script Temporizador
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Comida") // Si el alimento colisiona con la mesa
        {
            temporizador2.DetenerTemporizador(); // Envía un evento para detener el temporizador
        }
    }

}

