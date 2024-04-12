using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoJugador : MonoBehaviour
{
    public CharacterController Controlador;
    public float Velocidad = 15f;
    public float Gravedad = -10;

    public Transform EnelPiso;
    public float DistanciadelPiso;
    public LayerMask MascaradelPiso;

    Vector3 VelocidadAbajo;
    bool EstaenelPiso;

    private void Update()
    {
        EstaenelPiso = Physics.CheckSphere(EnelPiso.position, DistanciadelPiso, MascaradelPiso);

        if (EstaenelPiso && VelocidadAbajo.y < 0)
        {
            VelocidadAbajo.y = -2;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 mover = transform.right * x + transform.forward * z;
        Controlador.Move(mover * Velocidad * Time.deltaTime);

        VelocidadAbajo.y += Gravedad * Time.deltaTime;

        Controlador.Move(VelocidadAbajo * Time.deltaTime);

    }
}

