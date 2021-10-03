using System.Collections.Generic;

public class SadAnim : AbstractAnimation
{
    protected override void GenerateAnimation()
    {
        AddBlock(new List<string>{"SadFace", "Sad", "GrabHead"});
    }
}