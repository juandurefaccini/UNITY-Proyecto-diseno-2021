using System.Collections.Generic;
using UnityEngine;
using AnimatorComposerStructures;

public class RetarFormal : AbstractAnimation
{
    protected override void GenerateAnimation()
    {
        AddBlock(new List<string>{"Talking1"});
        AddBlock(new List<string>{"Talking1"});
        AddBlock(new List<string>{"clearTorsoLayer"});
        //AddBlock(new List<string>{"HeadGesture"});
    }
}