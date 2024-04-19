using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class Cupcake : MonoBehaviour
{
    public VideoPlayer videoPlayer; // Referencia al componente VideoPlayer
    public GameObject Steve;
    public GameObject Donut;
    public GameObject Muffin;
    public GameObject Canvas;

    private float tiempo = 0f; // Variable de temporizador para rastrear el tiempo transcurrido

    private void Start()
    {
        videoPlayer.Stop();
    }

    void Update()
    {
        // Comprueba si el video se está reproduciendo
        if (videoPlayer.isPlaying)
        {
            Steve.SetActive(false);
            Donut.SetActive(false);
            Muffin.SetActive(false);
            Canvas.SetActive(false);

            // Actualiza el temporizador
            tiempo += Time.deltaTime;

            // Comprueba si han pasado 7 segundos
            if (tiempo >= 7f)
            {
                videoPlayer.Stop(); // Detener la reproducción (opcional)
                SceneManager.LoadScene("Extras"); // Carga la escena "Extras"
                tiempo = 0f; // Reinicia el temporizador para futuras reproducciones
            }
            if (Input.GetKeyDown(KeyCode.Space))
            {
                SceneManager.LoadScene("Extras");
            }
        }
    }

    public void CupcakeBoton()
    {
        // Reproduce el video
        videoPlayer.Play();
    }
}
