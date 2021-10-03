using System.Collections.Generic;
using AnimatorComposerStructures;
using UnityEngine;

public abstract class AbstractAnimation : MonoBehaviour
{
    public bool play;
    public GameObject personajeAAnimar;
    
    private AnimationComposer _composer;
    private List<Block> anim = new List<Block>();
    
    public void Start()
    {
        _composer = personajeAAnimar.GetComponent<AnimationComposer>();
        AddClearBlock();        
        GenerateAnimation();
        AddClearBlock();
    }   

    public void Update()
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

    public void PlayAnim()
    {
        play = true;
    }

    protected void AddBlock(List<string> triggers)
    {
        List<LayerInfo> layers = new List<LayerInfo>();

        foreach (string trigger in triggers)
        {
            layers.Add(new LayerInfo(trigger));
        }
        
        anim.Add(new Block(layers));
    }
    
    private void AddClearBlock()
    {
        List<LayerInfo> clear = new List<LayerInfo>();
        var animator = personajeAAnimar.GetComponent<Animator>();
        
        for (int l = 1; l < animator.layerCount; ++l)
        {
            clear.Add(new LayerInfo("clear" + animator.GetLayerName(l)));
        }
        
        Block clearBlock =  new Block(clear);
        anim.Add(clearBlock);
    }

    protected abstract void GenerateAnimation();
}
