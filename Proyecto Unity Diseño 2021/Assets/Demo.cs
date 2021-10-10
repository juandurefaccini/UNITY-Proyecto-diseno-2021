using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Demo : MonoBehaviour
{
    public GameObject p1;
    public GameObject p2;

    // Start is called before the first frame update
    void Start()
    {
        p1.GetComponent<AnimationComposer>().AddBlock(new Block(new List<LayerInfo>()
        {
            new LayerInfo("StandingArguing"),
            new LayerInfo("AngryFace")
        }));
        StartCoroutine(Esperar());        
    }

    private IEnumerator Esperar()
    {
        yield return new WaitForSeconds(5f);
        p2.GetComponent<AnimationComposer>().AddBlock(new Block(new List<LayerInfo>()
        {
            new LayerInfo("StandingArguing"),
            new LayerInfo("AngryFace")
        }));
    }
}
