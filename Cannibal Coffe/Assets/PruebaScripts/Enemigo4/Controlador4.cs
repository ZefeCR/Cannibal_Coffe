using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class Controlador4 : MonoBehaviour
{

    public Transform objetivo;

    private ComidaenMesa4 comidaenMesa;

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

        comidaenMesa = GameObject.Find("MesaEnemigo4").GetComponent<ComidaenMesa4>();
        bool comida = comidaenMesa.comida;

    }

    void Update()
    {
        Vector3 velocity = navAgent.velocity;
        animator.SetFloat("VelX", velocity.x);
        animator.SetFloat("VelZ", velocity.z);

        // Rotar al personaje hacia el objetivo
        Vector3 direccionObjetivo = target.position - transform.position;
        Quaternion rotacionObjetivo = Quaternion.LookRotation(direccionObjetivo);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotacionObjetivo, velocidadRotacion * Time.deltaTime);

        RaycastHit impacto;
        if (Physics.Raycast(transform.position + transform.forward * 0.5f, direccionObjetivo, out impacto, distanciaMaximaRaycast, 20 << LayerMask.NameToLayer("Obstaculos")))
        {
            // Si se detecta un obstáculo, ajustar la rotación según el punto de impacto
            Vector3 direccionAjustada = impacto.point - transform.position;
            Quaternion rotacionAjustada = Quaternion.LookRotation(direccionAjustada);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotacionAjustada, velocidadRotacion * Time.deltaTime);
        }
        else
        {
            // Si no se detecta obstáculo, rotar directamente hacia el objetivo
            transform.rotation = Quaternion.Slerp(transform.rotation, rotacionObjetivo, velocidadRotacion * Time.deltaTime);
        }
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
                    returnInitiated = true; // Indica que el regreso ha sido iniciado
                }
            }

        }
    }

    void OnTriggerExit(Collider otro)
    {
        if (otro.gameObject.tag == "Silla") // Comprueba si sale de la colisión con el objetivo
        {
            tiempoInteraccion = 0f; // Reinicia el temporizador al finalizar la interacción
            Debug.Log("Interacción del agente con el objetivo finalizada.");

           
        }
    }

}
