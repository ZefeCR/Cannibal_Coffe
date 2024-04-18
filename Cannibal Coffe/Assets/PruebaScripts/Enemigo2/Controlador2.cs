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
    [SerializeField] private Transform posicionInicial; // Transform de la posición inicial del agente
    [SerializeField] private float duracionInteraccion = 5f; // Duración de la interacción en segundos

    private float tiempoInteraccion = 0f; // Temporizador para la duración de la interacción

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
            tiempoInteraccion = 0f; // Reinicia el temporizador al iniciar la interacción
            Debug.Log("Agente interactuando con el objetivo...");
        }
    }

    void OnTriggerStay(Collider otro)
    {
        if (otro.gameObject.tag == "Silla" && comidaenMesa == true) // Comprueba si colisiona con el objetivo
        {
            tiempoInteraccion += Time.deltaTime; // Incrementa el temporizador cada fotograma

            if (tiempoInteraccion >= duracionInteraccion) // Comprueba si la duración de la interacción ha pasado
            {
                if (!returnInitiated) 
               { 
                Debug.Log("Duración de la interacción completada. Devolviendo al agente a la posición inicial.");
                agente.speed = velocidadMovimiento;
                agente.SetDestination(posicionInicial.position); // Restablece la posición del agente
                }
            }
        
        }
    }

  

    void OnTriggerExit(Collider otro)
    {
        if (otro.gameObject.tag == "Silla" ) // Comprueba si sale de la colisión con el objetivo
        {
            tiempoInteraccion = 0f; // Reinicia el temporizador al finalizar la interacción
            Debug.Log("Interacción del agente con el objetivo finalizada.");
        }
    }
}
