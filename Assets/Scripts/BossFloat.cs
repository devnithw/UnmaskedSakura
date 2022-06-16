using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossFloat : StateMachineBehaviour
{
    public Boss boss;
    public float hori_speed = 1;
    Vector2 pos;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // Get Stuff from Boss public Script
        boss = animator.GetComponent<Boss>();
        
        // Move where?
        pos = new Vector2(boss.player.transform.position.x, boss.B.position.y);   
       
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // Move boss to that position
        animator.transform.position = Vector2.MoveTowards(animator.transform.position, pos, hori_speed * Time.deltaTime * boss.difficulty);

        if (Vector2.Distance(animator.transform.position, pos) < 0.01f){
            animator.SetTrigger("followPlayer");
        }







    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("followPlayer");
       
    }

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}
