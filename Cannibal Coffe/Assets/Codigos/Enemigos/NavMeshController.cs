using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavMeshController : MonoBehaviour
{

    public Transform objetivo;
    public float velocidad = 0f;
    // Start is called before the first frame update
    void Start()
    {
        NavMeshAgent agente = GetComponent<NavMeshAgent>();
        agente.destination = objetivo.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
