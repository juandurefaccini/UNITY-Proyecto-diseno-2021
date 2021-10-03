using System.Collections.Generic;
using UnityEngine;
using AnimatorComposerStructures;

public class OtherAnim : AbstractAnimation
{
    protected override void GenerateAnimation()
    {
        AddBlock(new List<string>{"RaiseArmL", "RaiseArmR", "Jump"}); // , "clearBothArmsLayer", "FistPump"
    }
}