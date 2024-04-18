using UnityEngine;

public class Mesa3 : MonoBehaviour
{
    public Temporizador3 temporizador3; // Referencia al script Temporizador
    void Start()
    {
        temporizador3 = GameObject.Find("Temporizador3").GetComponent<Temporizador3>(); // Obtiene la referencia al script Temporizador
    }

    public void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Comida") // Si el alimento colisiona con la mesa
        {
            temporizador3.DetenerTemporizador(); // Envía un evento para detener el temporizador
            temporizador3.enabled = false; // Desactiva el temporizador
        }
    }

}

