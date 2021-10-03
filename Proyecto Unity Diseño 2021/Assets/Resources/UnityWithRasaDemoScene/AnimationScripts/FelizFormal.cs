using System.Collections.Generic;
using UnityEngine;
using AnimatorComposerStructures;

public class FelizFormal : AbstractAnimation
{
    protected override void GenerateAnimation()
    {
        AddBlock(new List<string>{"HappyHandGesture"});
        AddBlock(new List<string>{"ThumbsUp"});
    }
}