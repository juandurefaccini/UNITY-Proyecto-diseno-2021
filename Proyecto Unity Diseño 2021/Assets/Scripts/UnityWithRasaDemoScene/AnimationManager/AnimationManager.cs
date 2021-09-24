using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class AnimationManager : MonoBehaviour
{
    public static Dictionary<string, MonoScript> anim_scripts;

    private void CargarAnimaciones()
    {
        anim_scripts = new Dictionary<string, MonoScript>();
        foreach (var component in Resources.LoadAll<MonoScript>("UnityWithRasaDemoScene/AnimationScripts"))
        {
            anim_scripts[component.GetClass().ToString()] = component;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        CargarAnimaciones();
    }

    public static void playAnim(string anim, GameObject personaje)
    {
        InterfazAnim animation = personaje.GetComponent(anim) as InterfazAnim;
        Debug.Log(personaje.ToString());
        if (animation == null)
        {
            personaje.AddComponent(anim_scripts[anim].GetClass());
            animation = personaje.GetComponent(anim) as InterfazAnim;
           
            animation.personajeAAnimar = personaje;
        }
        animation.playAnim();
    }
}
