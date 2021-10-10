using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Demo : MonoBehaviour
{
    public GameObject oso;
    public GameObject mateo;
    public GameObject cami;
    public GameObject agus;

    // Start is called before the first frame update
    void Start()
    {
        oso.GetComponent<AnimationComposer>().AddBlock(new Block(new List<LayerInfo>()
        {
            new LayerInfo("StandingArguing"),
            new LayerInfo("AngryFace")
        }));
        StartCoroutine(Esperar());        
    }

    private IEnumerator Esperar()
    {
        yield return new WaitForSeconds(3f);
        mateo.GetComponent<AnimationComposer>().AddBlock(new Block(new List<LayerInfo>()
        {
            new LayerInfo("StandingArguing"),
            new LayerInfo("AngryFace")
        }));
        yield return new WaitForSeconds(0.87f);
        cami.GetComponent<AnimationComposer>().AddBlock(new Block(new List<LayerInfo>()
        {
            new LayerInfo("AngryArmR"),
            new LayerInfo("AngryFace")
        }));
        yield return new WaitForSeconds(0.6f);
        agus.GetComponent<AnimationComposer>().AddBlock(new Block(new List<LayerInfo>()
        {
            new LayerInfo("StandingArguing"),
            new LayerInfo("AngryFace")
        }));
    }
}
