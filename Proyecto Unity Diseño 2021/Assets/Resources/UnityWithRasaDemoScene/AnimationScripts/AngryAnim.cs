using System.Collections.Generic;

public class AngryAnim : AbstractAnimation
{
    protected override void GenerateAnimation()
    {
        AddBlock(new List<string>{"CrossArms", "RotTorsoR"});
        AddBlock(new List<string>{"clearTorsoLayer", "clearRightArmLayer", "Stomp"});
    }
}
