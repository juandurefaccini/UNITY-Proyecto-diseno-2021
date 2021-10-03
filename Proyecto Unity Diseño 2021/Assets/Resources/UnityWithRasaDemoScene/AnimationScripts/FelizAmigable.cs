using System.Collections.Generic;
using UnityEngine;
using AnimatorComposerStructures;

public class FelizAmigable : AbstractAnimation
{
    protected override void GenerateAnimation()
    {
        AddBlock(new List<string>{"Excited"});
        AddBlock(new List<string>{"clearTorsoLayer"});
        AddBlock(new List<string>{"JoyfullJump"});
    }
}