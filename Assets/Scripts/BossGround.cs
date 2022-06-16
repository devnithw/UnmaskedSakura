using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossGround : StateMachineBehaviour
{
    public Boss boss;
    public float hori_speed = 1;
    Vector2 pos;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // Get Stuff from Boss public Script
        boss = animator.GetComponent<Boss>();  

        
       
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // Calculate player position 
        pos = new Vector2(boss.player.transform.position.x, boss.A.position.y);
        // Move boss to that position
        animator.transform.position = Vector2.MoveTowards(animator.transform.position, pos, hori_speed * Time.deltaTime * boss.difficulty);

        






       
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       
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
