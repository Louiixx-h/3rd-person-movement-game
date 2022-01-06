using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableAnimation : StateMachineBehaviour
{
    public string _parameterName;

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (stateInfo.normalizedTime >= 1f)
        {
            animator.SetBool(_parameterName, false);
        }
    }
}
