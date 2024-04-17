using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ControladorEnemigo1 : MonoBehaviour
{
    public Transform objetivo;

    private ComidaenMesa comidaenMesa;

    [SerializeField] private NavMeshAgent agente; // Referencia al componente NavMeshAgent
    [SerializeField] private Transform posicionInicial; // Transform de la posici�n inicial del agente
    [SerializeField] private float duracionInteraccion = 5f; // Duraci�n de la interacci�n en segundos

    private float tiempoInteraccion = 0f; // Temporizador para la duraci�n de la interacci�n

    public float velocidadMovimiento = 8f; // Ajusta este valor para la suavidad deseada

    public float returnTimer = 0f; // Temporizador para el regreso
    private bool returnInitiated = false; // Indica si el regreso ha sido iniciado
    void Start()
    {

        NavMeshAgent agente = GetComponent<NavMeshAgent>();
        agente.destination = objetivo.position;

        comidaenMesa = GameObject.Find("MesaEnemigo1").GetComponent<ComidaenMesa>();
        bool comida = comidaenMesa.comida;

    }
    void OnTriggerEnter(Collider otro)
    {
        if (otro.gameObject.tag == "Silla") // Comprueba si colisiona con el objetivo
        {
            tiempoInteraccion = 0f; // Reinicia el temporizador al iniciar la interacci�n
            Debug.Log("Agente interactuando con el objetivo...");
        }
    }

    void OnTriggerStay(Collider otro)
    {
        if (otro.gameObject.tag == "Silla" && comidaenMesa == true) // Comprueba si colisiona con el objetivo
        {
            tiempoInteraccion += Time.deltaTime; // Incrementa el temporizador cada fotograma

            if (tiempoInteraccion >= duracionInteraccion) // Comprueba si la duraci�n de la interacci�n ha pasado
            {
                if (!returnInitiated)
                {
                    Debug.Log("Duraci�n de la interacci�n completada. Devolviendo al agente a la posici�n inicial.");
                    agente.speed = velocidadMovimiento;
                    agente.SetDestination(posicionInicial.position); // Restablece la posici�n del agente
                }
            }

        }
    }



    void OnTriggerExit(Collider otro)
    {
        if (otro.gameObject.tag == "Silla") // Comprueba si sale de la colisi�n con el objetivo
        {
            tiempoInteraccion = 0f; // Reinicia el temporizador al finalizar la interacci�n
            Debug.Log("Interacci�n del agente con el objetivo finalizada.");
        }
    }
}
