using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slide : StateMachineBehaviour
{
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (stateInfo.normalizedTime >= 1f)
        {
            animator.SetBool("slide", false);
        }
    }
}
