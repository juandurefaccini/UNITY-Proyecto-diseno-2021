using System.Collections.Generic;
using UnityEngine;
using AnimatorComposerStructures;

public class happy3 : InterfazAnim
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
        
        //HAPPY-START
        List <LayerInfo> d4 = new List <LayerInfo>();
        d4.Add(new LayerInfo("Jump"));
        d4.Add(new LayerInfo("FistPump"));
        anim.Add(new Block(d4));
        
        List <LayerInfo> d5 = new List <LayerInfo>();
        d5.Add(new LayerInfo("clearBothArmsLayer"));
        d5.Add(new LayerInfo("ThumbsUp"));
        anim.Add(new Block(d5));
        
        List <LayerInfo> dc = new List <LayerInfo>();
        dc.Add(new LayerInfo("clearLegsLayer"));
        dc.Add(new LayerInfo("clearRightArmLayer"));
        anim.Add(new Block(dc));
        //HAPPY-END
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
