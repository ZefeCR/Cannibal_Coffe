using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComidaenMesa4 : MonoBehaviour
{

  public bool comida = false;

    public object MyVariableEvent { get; private set; }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Comida") // Si el alimento colisiona con la mesa
        {
           comida = true;
        }
    }
}
