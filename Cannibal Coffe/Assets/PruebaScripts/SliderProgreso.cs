using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class SliderProgreso : MonoBehaviour
{
    public Slider timerSlider;

    public float sliderTimer;

    public bool timerOn = false;

    public bool stopTimer = false;

    public Collider triggerCollider;
    void Start()
    {
        timerSlider.maxValue = sliderTimer;
        timerSlider.value = sliderTimer;

        triggerCollider = GetComponent<Collider>();


        StartTimer();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemigo2")
        {
            timerOn = true;
        }
    }
    private void Update()
    {
        if (timerOn == true)
        {
            sliderTimer -= Time.deltaTime;

        }
    }

    public void StartTimer()
    {
        StartCoroutine(StarTheTimerTicker());

    }

    IEnumerator StarTheTimerTicker()
    {
        while (stopTimer == false)
        {

            yield return new WaitForSeconds(0.001f);

            if (sliderTimer < 0)
            {
                stopTimer = true;
            }

            if (stopTimer == false)
            {
                timerSlider.value = sliderTimer;
            }
        }
        //Aquie poner la logica del juego
    }

    public void StopTimer()
    {
        stopTimer = true;
    }
}