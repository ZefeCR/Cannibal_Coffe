using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSCamera : MonoBehaviour
{
    public float Velocidad = 100f;
    float RotacionX = 0f;

    public Transform Player;

    //Menu Pausa
    public Pausa pausaScript; // Referencia al script Pausa

    void Start()
    {
        if (pausaScript == null)
        {
            Debug.LogError("No se ha asignado el script Pausa en el script FPSCamera.");
            return;
        }

        // Bloquear y ocultar el cursor inicialmente
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    void Update()
    {
      
        float MauseX = Input.GetAxis("Mouse X") * Velocidad * Time.deltaTime;
        float MauseY = Input.GetAxis("Mouse Y") * Velocidad * Time.deltaTime;

        RotacionX -= MauseY;
        RotacionX = Mathf.Clamp (RotacionX, -20, 72);

        transform.localRotation = Quaternion.Euler(RotacionX, 0f, 0f);
        Player.Rotate(Vector3.up * MauseX);
        // Manejar el estado del cursor según el menú de pausa
        if (pausaScript.menuPausa.gameObject.activeSelf)
        {
            // Mostrar y desbloquear el cursor cuando el menú de pausa está activo
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        else
        {
            // Bloquear y ocultar el cursor cuando el menú de pausa está inactivo
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }
}
