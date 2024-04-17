using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Cargando : MonoBehaviour
{
    public RawImage cambio;
    

    private void Start()
    {
        string nivelACargar = CargandoNivel.siguienteNivel;
        StartCoroutine(IniciarCarga(nivelACargar));
       

    }

    IEnumerator IniciarCarga(string nivel)
    {
        yield return new WaitForSeconds(1f);
        AsyncOperation operacion = SceneManager.LoadSceneAsync(nivel);
        operacion.allowSceneActivation = false;

        while (!operacion.isDone)
        {
            if (operacion.progress >= 0.9f)
            {
                cambio.gameObject.SetActive(true);

                if (Input.anyKey)
                {
                    operacion.allowSceneActivation = true;
                }
            }
            yield return null;
        }

    }
}
