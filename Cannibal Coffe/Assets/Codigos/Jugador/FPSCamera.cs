using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSCamera : MonoBehaviour
{
    public float Velocidad = 100f;
    float RotacionX = 0f;

    public Transform Player;

    //Menu Pausa
    Pausa pausa;

    void Start()
    {
        Cursor.visible = false;

        //Menu Pausa
        pausa = GameObject.Find("ControladorMenu").GetComponent<Pausa>();
        Canvas menuPausa = pausa.menuPausa;
    }
    void Update()
    {
      
        float MauseX = Input.GetAxis("Mouse X") * Velocidad * Time.deltaTime;
        float MauseY = Input.GetAxis("Mouse Y") * Velocidad * Time.deltaTime;

        RotacionX -= MauseY;
        RotacionX = Mathf.Clamp (RotacionX, -20, 72);

        transform.localRotation = Quaternion.Euler(RotacionX, 0f, 0f);
        Player.Rotate(Vector3.up * MauseX);

        if (!pausa.gameObject ==true)
        {
            // Ocultar el cursor mientras el juego se ejecuta
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = true;
        }
        else
        {
            // Mostrar el cursor cuando el menú de pausa está activo
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = false;
        }
    }
}
