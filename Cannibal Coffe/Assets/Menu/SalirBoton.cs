using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SalirBoton : MonoBehaviour
{
   public void Salir()
    {
        Application.Quit();
        Debug.Log("Juego Cerrado");
    }
}



