using System.Collections.Generic;
using UnityEngine;
using AnimatorComposerStructures;

public class RetarSusc : AbstractAnimation
{
    protected override void GenerateAnimation()
    {
        AddBlock(new List<string>{"Disbelief"});
        AddBlock(new List<string>{"clearBothArmsLayer"});
        AddBlock(new List<string>{"StandingArguing"});
    }
}