using System.Collections.Generic;

public class RetadoSusceptible : AbstractAnimation
{
    protected override void GenerateAnimation()
    {
        AddBlock(new List<string>{"AngryFace", "Stomp"});
        AddBlock(new List<string>{"Dismissing"});
        AddBlock(new List<string>{"AngryGesture"});
    }
}