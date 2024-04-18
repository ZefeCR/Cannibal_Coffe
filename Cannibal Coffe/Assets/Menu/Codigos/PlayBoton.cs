using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayBoton : MonoBehaviour
{
    //Sonido
    public AudioSource sonidoBoton; // Referencia al componente AudioSource

    private void Start()
    {
        // Suponiendo que el GameObject del bot�n tiene un evento OnClick conectado a este m�todo
        sonidoBoton = GetComponent<AudioSource>(); // Obt�n el componente AudioSource
    }

    private void Update()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
    public void EscenaJuego()
    {
        if (sonidoBoton != null) // Comprueba si est� asignado el AudioSource
        {
            sonidoBoton.Play(); // Reproduce el clip de audio asignado
        }

        SceneManager.LoadScene("PantalladeCarga");
    }

    public void MenuRegreso()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
