using UnityEngine;


public class ExitBehaviour : StateMachineBehaviour
{
    private bool _notified;

    public AnimationComposer compositionController;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _notified = false;
    }
    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (stateInfo.normalizedTime % 1 > 0.99 && !_notified)
        {
            compositionController.SignalAnimationComplete();
            _notified = true; //para que pregunte una sola vez
        }
    }
}
