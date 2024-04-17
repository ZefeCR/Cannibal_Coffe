using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pausa : MonoBehaviour
{
    [SerializeField ]public Canvas menuPausa { get; private set; }
    public Canvas find;

    private void Start()
    {
        menuPausa = find;
        
    }
    public void MostrarMenuPausa()
    {
        menuPausa.gameObject.SetActive(true);
        Time.timeScale = 0f; // Pausar el tiempo del juego
    }

    public void OnBotonReanudarClick()
    {
        // Ocultar el menú de pausa
        menuPausa.gameObject.SetActive(false);

        // Reanudar el tiempo del juego
        Time.timeScale = 1f;
    }

    public void Salir()
    {
        Application.Quit();
        Debug.Log("Juego Cerrado");
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            MostrarMenuPausa();
        }
    }

}
