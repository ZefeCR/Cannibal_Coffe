using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Temporizador3 : MonoBehaviour
{
    public Slider sliderTemporizador; // Referencia al slider del temporizador
    public float tiempoTotal; // Tiempo total del temporizador

    private float tiempoRestante; // Tiempo restante del temporizador
    private bool temporizadorEncendido = false; // Indica si el temporizador está encendido

    void Start()
    {
        sliderTemporizador.maxValue = tiempoTotal; // Establece el valor máximo del slider
        sliderTemporizador.value = tiempoTotal; // Establece el valor inicial del slider

        tiempoRestante = tiempoTotal; // Inicializa el tiempo restante
    }
    
    public void IniciarTemporizador()
    {
        temporizadorEncendido = true; // Enciende el temporizador
        StartCoroutine(ActualizaTemporizador()); // Inicia la coroutine de actualización
    }

    public void DetenerTemporizador()
    {
        temporizadorEncendido = false;
        sliderTemporizador.value = tiempoTotal;
        enabled = false;
        // Apaga el temporizador
    }


    IEnumerator ActualizaTemporizador()
    {
        while (temporizadorEncendido)
        {
            tiempoRestante -= Time.deltaTime; // Disminuye el tiempo restante

            if (tiempoRestante <= 0)
            {
                tiempoRestante = 0; // Asegura que el slider no baje de 0
                // Implementar la lógica de finalización del temporizador aquí
            }

            sliderTemporizador.value = tiempoRestante; // Actualiza el valor del slider

            yield return new WaitForSeconds(0.01f); // Espera un pequeño intervalo
        }
    }
}
