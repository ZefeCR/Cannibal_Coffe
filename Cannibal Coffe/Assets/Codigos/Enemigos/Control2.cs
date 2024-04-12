using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class Control2 : MonoBehaviour
{
    public Transform objetivo;
    public Collision silla;

    // Start is called before the first frame update
    void Start()
    {
        new WaitForSecondsRealtime(1f);
        {

            NavMeshAgent agente = GetComponent<NavMeshAgent>();



            agente.destination = objetivo.position;
        }
           
     }

       
    
}
