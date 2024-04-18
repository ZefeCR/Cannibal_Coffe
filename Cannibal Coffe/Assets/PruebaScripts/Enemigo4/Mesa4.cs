using UnityEngine;

public class Mesa4 : MonoBehaviour
{
    public Temporizador4 temporizador4; // Referencia al script Temporizador
    void Start()
    {
        temporizador4 = GameObject.Find("Temporizador4").GetComponent<Temporizador4>(); // Obtiene la referencia al script Temporizador
    }

    public void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Comida") // Si el alimento colisiona con la mesa
        {
            temporizador4.DetenerTemporizador(); // Envía un evento para detener el temporizador
            temporizador4.enabled = false; // Desactiva el temporizador
        }
    }

}

