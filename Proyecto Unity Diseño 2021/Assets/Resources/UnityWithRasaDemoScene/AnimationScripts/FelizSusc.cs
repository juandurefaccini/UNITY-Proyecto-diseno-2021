using System.Collections.Generic;
using UnityEngine;
using AnimatorComposerStructures;

public class FelizSusc : AbstractAnimation
{
    protected override void GenerateAnimation()
    {
        AddBlock(new List<string>{"Happy1"});
        AddBlock(new List<string>{"LookingDown"});
        AddBlock(new List<string>{"Happy1"});
    }
}