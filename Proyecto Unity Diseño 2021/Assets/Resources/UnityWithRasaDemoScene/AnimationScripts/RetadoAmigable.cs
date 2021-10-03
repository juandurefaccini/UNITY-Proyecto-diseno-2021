using System.Collections.Generic;
using UnityEngine;
using AnimatorComposerStructures;

public class RetadoAmigable : AbstractAnimation
{
    protected override void GenerateAnimation()
    {
        AddBlock(new List<string>{"HeadNod"});
        AddBlock(new List<string>{"HeadNod"});
        AddBlock(new List<string>{"ScratchHeadL"});
        AddBlock(new List<string>{"HeadNod"});
    }
}