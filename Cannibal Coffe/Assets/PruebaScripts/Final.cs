using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class Final : MonoBehaviour
{
    public VideoPlayer video;
    //Dialogo

    void Awake()
    {
        video = GetComponent<VideoPlayer>();
        video.Play();
        video.loopPointReached += CheckOver;
    }

    void CheckOver(VideoPlayer vp)
    {
        //Poner aqui el cambio de escena al de muerte

        gameObject.SetActive(false);
        SceneManager.LoadScene("MainMenu");
    }

    private void Update()
    {
        if (video.isPlaying && Input.GetButtonDown("Jump"))
        {

            CheckOver(video);
            gameObject.SetActive(false);
            SceneManager.LoadScene("MainMenu");
        }
    }
}