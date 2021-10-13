using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbrirPuerta : MonoBehaviour
{
    public GameObject puerta;
    
    private bool abierta;
    
    private void OnTriggerStay(Collider other)
    {
        if (Input.GetKeyDown(KeyCode.E) && other.gameObject.CompareTag("Puerta"))
        {
            Debug.Log(puerta);
            
            if (!abierta)
            {
                Debug.Log("Es una puerta abierta");
                puerta.transform.Rotate(0,90,0);
            }
            else
            {
                Debug.Log("Es una puerta cerrada");
                puerta.transform.Rotate(0,-90,0);
            }
            
            abierta = !abierta;
        }
    }
}
