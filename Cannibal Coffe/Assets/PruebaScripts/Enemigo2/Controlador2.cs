using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Controlador2 : MonoBehaviour
{
    
    public Transform objetivo;

    private ComidaenMesa2 comidaenMesa;

    [SerializeField] private NavMeshAgent agente; // Referencia al componente NavMeshAgent
    [SerializeField] private Transform posicionInicial; // Transform de la posici�n inicial del agente
    [SerializeField] private float duracionInteraccion = 5f; // Duraci�n de la interacci�n en segundos

    private float tiempoInteraccion = 0f; // Temporizador para la duraci�n de la interacci�n

    public float velocidadMovimiento = 8f; // Ajusta este valor para la suavidad deseada

    public float returnTimer = 0f; // Temporizador para el regreso
    private bool returnInitiated = false; // Indica si el regreso ha sido iniciado

    //Animacion
    private NavMeshAgent navAgent;
    private Animator animator;

    public Transform target; // Objeto GameObject objetivo
    public float velocidadRotacion;
    public float distanciaMaximaRaycast;
    void Start()
    {
        //Animacion
        animator = GetComponent<Animator>();

        NavMeshAgent agente = GetComponent<NavMeshAgent>();
        agente.destination = objetivo.position;

        //Animacion
        navAgent = GetComponent<NavMeshAgent>();
        navAgent.destination = objetivo.position;

      

        comidaenMesa = GameObject.Find("MesaEnemigo2").GetComponent<ComidaenMesa2>();
        bool comida = comidaenMesa.comida;
        
    }

    void Update()
    {

        Vector3 velocity = navAgent.velocity;
        animator.SetFloat("VelX", velocity.x);
        animator.SetFloat("VelZ", velocity.z); 
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
        if (otro.gameObject.tag == "Silla" ) // Comprueba si sale de la colisi�n con el objetivo
        {
            tiempoInteraccion = 0f; // Reinicia el temporizador al finalizar la interacci�n
            Debug.Log("Interacci�n del agente con el objetivo finalizada.");
        }
    }
}
