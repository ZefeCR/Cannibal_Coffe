using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;
using UnityEngine.UI;

public class CogerObjeto : MonoBehaviour
{
    public GameObject handPoint;

    private GameObject pickedObject = null;

    public Text uiTextElement;


    public float tiempoVisualizacionMensaje = 2f; // Tiempo en segundos para mostrar el mensaje
    private float tiempoInicioMensaje;



    void Update()
    {
        if (pickedObject != null)
        {
            if (Input.GetKey("r"))
            {
                pickedObject.GetComponent<Rigidbody>().useGravity = true;

                pickedObject.GetComponent<Rigidbody>().isKinematic = false;

                pickedObject.gameObject.transform.SetParent(null);

                pickedObject = null;
            }
        }
        if (Time.time - tiempoInicioMensaje > tiempoVisualizacionMensaje)
        {
            uiTextElement.text = ""; // Borra el texto del mensaje
            uiTextElement.gameObject.SetActive(false); // Oculta la interfaz del mensaje
        }

    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Comida"))
        {
            if (Input.GetKey("e") && pickedObject == null)
            {
                other.GetComponent<Rigidbody>().useGravity = false;

                other.GetComponent<Rigidbody>().isKinematic = true;

                other.transform.position = handPoint.transform.position;

                other.gameObject.transform.SetParent(handPoint.gameObject.transform);

                pickedObject = other.gameObject;
            }
        }
        if (other.gameObject.CompareTag("Puerta"))
        {
            // Check for interaction with "E" key and no object currently picked
            if (Input.GetKeyDown(KeyCode.E) && pickedObject == null)
            {
                // ... (Raycast check for nearby objects)
                // ... (Check if object cannot be opened)

                // Trigger "Cannot Open" feedback
                uiTextElement.text = "Todavia quedan postres hechos";
                uiTextElement.gameObject.SetActive(true);
                tiempoInicioMensaje = Time.time;
            }
        }

    }
}
