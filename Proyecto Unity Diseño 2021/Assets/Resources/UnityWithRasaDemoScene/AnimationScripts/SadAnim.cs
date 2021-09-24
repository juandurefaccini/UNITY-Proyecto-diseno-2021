using System.Collections.Generic;
using UnityEngine;
using AnimatorComposerStructures;

public class SadAnim : InterfazAnim
{
    
    private List<Block> anim = new List<Block>();

    
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
        
        //SAD-START
        List <LayerInfo> d6 = new List <LayerInfo>();
        d6.Add(new LayerInfo("Sad"));
        d6.Add(new LayerInfo("GrabHead"));
        anim.Add(new Block(d6));
        List <LayerInfo> d7 = new List <LayerInfo>();
        d7.Add(new LayerInfo("clearTorsoLayer"));
        d7.Add(new LayerInfo("clearBothArmsLayer"));
        anim.Add(new Block(d7));
        //SAD-END
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

    public override void playAnim()
    {
        play = true;
    }
}