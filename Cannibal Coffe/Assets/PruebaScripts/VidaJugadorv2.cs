using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class VidaJugador2 : MonoBehaviour
{
    [SerializeField] private List<Slider> sliders; // Lista de sliders de salud
    [SerializeField] private int maxLives = 5; // Valor máximo de vidas

    [SerializeField] private Slider lifeSlider; // Slider de vidas
    [SerializeField] private int playerLives = 3; // Vidas del jugador

    // Daño Imagen
    [SerializeField] private GameObject panelDaño;

    // Diccionario para mapear sliders a nombres de escenas de Game Over
    [SerializeField] private Dictionary<Slider, string> sliderToGameOverSceneNames = new Dictionary<Slider, string>();

    // Audio Sources for background music and damage sound
    [SerializeField] private AudioSource backgroundMusicSource;
    [SerializeField] private AudioClip damageSound;

    void Start()
    {
        foreach (Slider slider in sliders)
        {
             if (slider.name == "Slider1")
            {
                sliderToGameOverSceneNames.Add(slider, "GameOver1");
            }
            else if (slider.name == "Slider2")
            {
                sliderToGameOverSceneNames.Add(slider, "GameOver2");
            }
            else if (slider.name == "Slider3")
            {
                sliderToGameOverSceneNames.Add(slider, "GameOver3");
            }
            else if (slider.name == "Slider4")
            {
                sliderToGameOverSceneNames.Add(slider, "GameOver4");
            }
            // ... (Agregar más asignaciones para sliders adicionales
            slider.onValueChanged.AddListener(OnSliderValueChanged);
            
           
        }
        if (playerLives > 0)
        {
            panelDaño.SetActive(false); // Desactivar el panel de daño
        }
        UpdateLifeSlider(); // Actualizar el slider de vidas al inicio
    }



    void OnSliderValueChanged(float value)
    {
        if (value == 0)
        {
            playerLives--;
            UpdateLifeSlider(); // Actualizar el slider de vidas

            if (playerLives <= 0)
            {
                Debug.Log("GAME OVER"); // Fin del juego o reinicio de vidas

                // Identifica el slider activo y carga su escena de Game Over asociada
                foreach (Slider slider in sliders)
                {
                    if (slider.value == 0 )
                    {
                        string gameOverSceneName = sliderToGameOverSceneNames[slider];
                        SceneManager.LoadScene(gameOverSceneName);
                        break;
                    }
                }
            }
            else
            {
                panelDaño.SetActive(true); // Activar el panel de daño
                StartCoroutine(DamagePanelDelay()); // Iniciar la corrutina

                // Play damage sound when taking damage
                PlayDamageSound();
            }
        }
    }

    void UpdateLifeSlider()
    {
        lifeSlider.value = (float)playerLives / maxLives; // Actualizar el valor del slider de vidas
    }

    IEnumerator DamagePanelDelay()
    {
        yield return new WaitForSeconds(2.0f); // Retraso de 2 segundos
         // Desactivar el panel de daño
    }

    void PlayDamageSound()
    {
        if (damageSound != null)
        {
            backgroundMusicSource.volume = 0.5f; // Reduce background music volume temporarily
            AudioSource.PlayClipAtPoint(damageSound, transform.position); // Play damage sound
            StartCoroutine(FadeOutMusic()); // Fade out background music after a short delay
        }
    }

    IEnumerator FadeOutMusic()
    {
        yield return new WaitForSeconds(0.5f); // Wait for a brief delay before fading

        float initialVolume = backgroundMusicSource.volume;
        float fadeOutTime = 1.0f; // Adjust fade-out duration as needed

        for (float t = 0; t < fadeOutTime; t += Time.deltaTime)
        {
            backgroundMusicSource.volume = Mathf.Lerp(initialVolume, 0f, t / fadeOutTime);
            yield return null;
        }

        backgroundMusicSource.volume = 0f; // Ensure music volume is set to 0
    }
}

