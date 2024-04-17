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

    // Array de referencias a los sliders de da�o
    public Slider[] slidersDa�o;

    // Umbral de da�o para restar vida
    public float umbralDa�o = 100f;

    // Variable para almacenar el da�o acumulado
    public float da�oAcumulado = 0f;

    // Variable para indicar si el slider est� activo
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
        // Si el slider est� activo
        if (sliderActivo)
        {
            // Recorrer los sliders de da�o
            foreach (Slider slider in slidersDa�o)
            {
                // Verificar si el valor del slider ha cambiado
                if (slider.value != 0f)
                {
                    // Acumular el da�o
                    da�oAcumulado += slider.value;

                    // Reiniciar el valor del slider a 0
                    slider.value = 0f;
                }
            }

            // Comprobar si se ha alcanzado el umbral de da�o
            if (da�oAcumulado >= umbralDa�o)
            {
                // Restar vida al jugador
                vidaActual--;

                // Actualizar el slider de vida
                ActualizarSliderVida();

                // Reiniciar el da�o acumulado
                da�oAcumulado = 0f;

                // Comprobar si el jugador ha perdido
                if (vidaActual <= 0)
                {
                    // Implementar la l�gica de fin de partida o muerte del jugador
                    Debug.Log("�El jugador ha perdido!");
                }
            }
        }
    }

    public void ActivarSliderDa�o()
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


