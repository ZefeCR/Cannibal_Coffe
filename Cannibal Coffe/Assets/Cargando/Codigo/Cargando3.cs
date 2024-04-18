using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Cargando3 : MonoBehaviour
{
    public RawImage pantallaCargaInicial;
    public RawImage pantallaPresionarTecla;
    private void Start()
    {
        pantallaCargaInicial = GameObject.Find("Cargando1").GetComponent<RawImage>();
        pantallaPresionarTecla = GameObject.Find("Cargando2").GetComponent<RawImage>();
        pantallaCargaInicial.enabled = true;
        pantallaPresionarTecla.enabled = false;
        StartCoroutine(EsperarYCambiarPantalla());
    }
    IEnumerator EsperarYCambiarPantalla()
    {
        yield return new WaitForSeconds(4f); // Espera 3 segundos (puedes ajustar el tiempo)
        pantallaCargaInicial.enabled = false;
        pantallaPresionarTecla.enabled = true;
    }
    void Update()
    {
        if (Input.anyKey)
        {
            SceneManager.LoadScene("Juego"); // Cambia al siguiente nivel
        }
    }

}
