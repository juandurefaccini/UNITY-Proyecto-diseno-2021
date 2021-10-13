using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CambioCamara : MonoBehaviour
{
    public Camera terceraPersona;
    public Camera primeraPersona;
    public bool estaInteractuando = false;
    private bool esTercera;

    // Update is called once per frame
    void Update()
    {
        if (!estaInteractuando)
        {
            if (Input.GetKeyDown(KeyCode.C))
            {
                if (esTercera)
                {
                    terceraPersona.depth = -1;
                    primeraPersona.depth = 0;
                }
                else
                {
                    terceraPersona.depth = 0;
                    primeraPersona.depth = -1;
                }
                esTercera = !esTercera;
            }
        }
    }
}
