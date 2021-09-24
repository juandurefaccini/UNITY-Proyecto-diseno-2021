using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class InterfazAnim : MonoBehaviour
{
    public bool play = false;
    public GameObject personajeAAnimar;

    public abstract void playAnim();
}
