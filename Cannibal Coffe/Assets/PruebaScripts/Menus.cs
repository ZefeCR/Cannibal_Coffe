using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class Menus : MonoBehaviour
{
    [SerializeField] private GameObject menuGameOver;
    public GameObject finish;
    private bool play;

    private void ActivarMenu(object sender, EventArgs e)
    {
        menuGameOver.SetActive(true);
        finish.SetActive(true);

        
    }
    //Botones
    public void Reiniciar()
    {
        SceneManager.LoadScene("Juego");

    }
    public void MenuInicial(string nombre)
    {
        SceneManager.LoadScene(nombre);
    }

    public void SalirJuego()
    {
        Application.Quit();
        Debug.Log("Juego Cerrado");
    }
}
