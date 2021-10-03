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

    public static void PlayAnim(string anim, GameObject personaje)
    {
        AbstractAnimation animation = personaje.GetComponent(anim) as AbstractAnimation;
        
        if (animation == null)
        {
            personaje.AddComponent(anim_scripts[anim].GetClass());
            animation = personaje.GetComponent(anim) as AbstractAnimation;
            // TODO Es posible que animacion ya no requiera de un atributo personajeAAnimar ya que se encuentra dentro del mismo
            animation.personajeAAnimar = personaje;
        }
        
        animation.PlayAnim();
    }
}
