using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mantener : MonoBehaviour
{
 public static Mantener instance;
    private void wake()
    {
        if (Mantener.instance == null)
        {
            Mantener.instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
