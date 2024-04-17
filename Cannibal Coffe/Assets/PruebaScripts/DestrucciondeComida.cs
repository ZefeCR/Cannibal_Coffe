using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestrucciondeComida : MonoBehaviour
{

    // Etiqueta del objeto con el que se detectar� la colisi�n
    public string etiquetaParaDetectar = "Mesa"; // Reemplazar "EtiquetaObjetivo" con la etiqueta real

    void OnTriggerEnter(Collider other)
    {
        // Verificar si la colisi�n es con un objeto que tenga la etiqueta especificada
        if (other.gameObject.tag == etiquetaParaDetectar)
        {
            // Destruir el objeto actual (this)
            Destroy(gameObject);
        }
    }
}



