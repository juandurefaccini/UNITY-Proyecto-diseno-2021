using System.Collections.Generic;
using UnityEngine;
using AnimatorComposerStructures;

public class HappyAnim : AbstractAnimation
{
    protected override void GenerateAnimation()
    {
        AddBlock(new List<string>{"Jump", "FistPump"});
        AddBlock(new List<string>{"clearBothArmsLayer", "ThumbsUp"});
    }
}
