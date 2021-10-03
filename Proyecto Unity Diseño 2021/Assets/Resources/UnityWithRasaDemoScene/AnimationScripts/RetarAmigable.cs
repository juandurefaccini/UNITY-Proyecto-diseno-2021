using System.Collections.Generic;
using UnityEngine;
using AnimatorComposerStructures;

public class RetarAmigable : AbstractAnimation
{
    protected override void GenerateAnimation()
    {
        AddBlock(new List<string>{"Talking2"});
        AddBlock(new List<string>{"clearTorsoLayer", "HandsForward"});
        AddBlock(new List<string>{"clearTorsoLayer", "clearBothArmsLayer", "clearLegsLayer"});
        AddBlock(new List<string>{"Talking2"});
    }
}