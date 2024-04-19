using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Flan : MonoBehaviour
{
    // Referencias a los componentes Raw Image y Text
    public RawImage imagenCruda; // Cambiado "Raw Image" a "imagenCruda" para español

    public Text texto;
    // Variable de temporizador para rastrear el tiempo transcurrido
    private float tiempo = 0f;

    private void Start()
    {
        // Inicialmente muestra el texto y oculta la Imagen Cruda

        imagenCruda.gameObject.SetActive(false);
        texto.gameObject.SetActive(true);
    }

    void Update()
    {
        // Comprueba si el temporizador ha llegado a los 7 segundos
        if (tiempo >= 7f)
        {
            // Carga la escena "Extras"
            SceneManager.LoadScene("Extras");
        }

        // Comprueba si se presiona la barra espaciadora para omitir
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene("Extras");
        }

        // Actualiza el temporizador
        tiempo += Time.deltaTime;
    }

    public void FlanBoton()
    {
        // Oculta el texto y muestra la Imagen Cruda
        texto.gameObject.SetActive(false);
        imagenCruda.gameObject.SetActive(true);

        // Reinicia el temporizador
        tiempo = 0f;
    }
}

