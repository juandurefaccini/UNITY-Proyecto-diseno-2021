using System.Collections.Generic;
using UnityEngine;
using AnimatorComposerStructures;

public class RetadoFormal : AbstractAnimation
{
    protected override void GenerateAnimation()
    {
        AddBlock(new List<string>{"ScratchHeadL"});
        AddBlock(new List<string>{"clearLeftArmLayer", "clearTorsoLayer"});
        AddBlock(new List<string>{"CrossArms", "clearBothArmsLayer"});
        AddBlock(new List<string>{"clearLeftArmLayer", "clearTorsoLayer"});
        AddBlock(new List<string>{"ScratchHeadL"});
    }
}