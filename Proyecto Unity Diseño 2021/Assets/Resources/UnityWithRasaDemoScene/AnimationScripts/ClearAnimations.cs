using UnityEngine;
using AnimatorComposerStructures;

public class ClearAnimations : MonoBehaviour
{
    public bool play;

    public GameObject personajeAAnimar;

    private AnimationComposer _composer;
    // Start is called before the first frame update
    void Start()
    {
        _composer = personajeAAnimar.GetComponent<AnimationComposer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!play)
            return;
        if (!personajeAAnimar)
            return;
        
        _composer.ClearAnims();
        
        play = false;
    }
}
