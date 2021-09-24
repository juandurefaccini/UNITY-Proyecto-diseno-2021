using System.Collections.Generic;
using UnityEngine;
using AnimatorComposerStructures;

public class AngryAnim : MonoBehaviour
{
    public bool play;
    private List<Block> anim = new List<Block>();

    public GameObject personajeAAnimar;

    private AnimationComposer _composer;
    // Start is called before the first frame update
    void Start()
    {
        _composer = personajeAAnimar.GetComponent<AnimationComposer>();
        
        //resetear las extremidades que hayan quedado animadas
        List<LayerInfo> clear = new List<LayerInfo>();
        var animator = personajeAAnimar.GetComponent<Animator>();
        for (int l = 1; l < animator.layerCount; l++)
        {
            clear.Add(new LayerInfo("clear"+animator.GetLayerName(l)));
        }
        Block clearBlock = new Block(clear);
        anim.Add(clearBlock);
        
        //ANGRY-START
        List <LayerInfo> d1 = new List <LayerInfo>();
        d1.Add(new LayerInfo("CrossArms"));
        d1.Add(new LayerInfo("RotTorsoR"));
        
        List <LayerInfo> d2 = new List <LayerInfo>();
        
        d2.Add(new LayerInfo("clearTorsoLayer")); 
        d2.Add(new LayerInfo("clearRightArmLayer"));
        d2.Add(new LayerInfo("Stomp")); 
        
        List <LayerInfo> d3 = new List <LayerInfo>();
        d3.Add(new LayerInfo("clearLegsLayer"));
        d3.Add(new LayerInfo("clearTorsoLayer"));
        d3.Add(new LayerInfo("clearLeftArmLayer"));
        d3.Add(new LayerInfo("clearBothArmsLayer"));

        Block b1 = new Block(d1);
        Block b2 = new Block(d2);
        Block b3 = new Block(d3);

        anim.Add(b1);
        anim.Add(b2);
        anim.Add(b3);
        //ANGRY-END
    }

    // Update is called once per frame
    void Update()
    {
        if (!play)
            return;
        if (!personajeAAnimar)
            return;
        //le pasamos una copia de la queue anim asi anim no se vacia y podemos ejecutar la animacion mas de una vez

        foreach (var block in anim)
        {
            _composer.AddBlock(block);
        }
        
        play = false;
    }
}
