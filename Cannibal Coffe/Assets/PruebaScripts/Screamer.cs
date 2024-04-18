using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class SilasScreamer : MonoBehaviour
{
    public VideoPlayer video;
    [SerializeField] public GameObject finish;
    private void Start()
    {
        finish = GetComponent<GameObject>();
    }
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

    }
}
