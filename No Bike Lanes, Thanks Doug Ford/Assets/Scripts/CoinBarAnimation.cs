using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinBarAnimation : StateMachineBehaviour
{
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // Pause animation by setting speed to 0 when entering this state
        animator.speed = 0;
    }
}