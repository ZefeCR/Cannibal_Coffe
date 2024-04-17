using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Vida : MonoBehaviour
{
    // Cantidad de vida inicial del jugador
    public int vidaInicial = 3;

    // Variable para almacenar la vida actual del jugador
    private int vidaActual;

    // Referencia al slider de vida
    public Slider sliderVida;

    // Array de referencias a los sliders de daño
    public Slider[] slidersDaño;

    // Umbral de daño para restar vida
    public float umbralDaño = 100f;

    // Variable para almacenar el daño acumulado
    public float dañoAcumulado = 0f;

    // Variable para indicar si el slider está activo
    private bool sliderActivo = false;

    void Start()
    {
        // Inicializar vida actual con la vida inicial
        vidaActual = vidaInicial;

        // Actualizar el slider de vida al iniciar
        ActualizarSliderVida();
    }

    void Update()
    {
        // Si el slider está activo
        if (sliderActivo)
        {
            // Recorrer los sliders de daño
            foreach (Slider slider in slidersDaño)
            {
                // Verificar si el valor del slider ha cambiado
                if (slider.value != 0f)
                {
                    // Acumular el daño
                    dañoAcumulado += slider.value;

                    // Reiniciar el valor del slider a 0
                    slider.value = 0f;
                }
            }

            // Comprobar si se ha alcanzado el umbral de daño
            if (dañoAcumulado >= umbralDaño)
            {
                // Restar vida al jugador
                vidaActual--;

                // Actualizar el slider de vida
                ActualizarSliderVida();

                // Reiniciar el daño acumulado
                dañoAcumulado = 0f;

                // Comprobar si el jugador ha perdido
                if (vidaActual <= 0)
                {
                    // Implementar la lógica de fin de partida o muerte del jugador
                    Debug.Log("¡El jugador ha perdido!");
                }
            }
        }
    }

    public void ActivarSliderDaño()
    {
        // Activar el slider
        sliderActivo = true;
    }

    private void ActualizarSliderVida()
    {
        // Calcular el porcentaje de vida restante
        float porcentajeVida = (float)vidaActual / (float)vidaInicial;

        // Establecer el valor del slider de vida
        sliderVida.value = porcentajeVida;
    }
}


