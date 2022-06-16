using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollow : StateMachineBehaviour
{
    EnemyBehavior behavior;
    private Transform playerPosition;
    public float chaseSpeed;
    public float detectRadiusAfterSeen;
    Vector2 target = Vector2.zero;
    public bool canFloat = false;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        behavior = animator.GetComponent<EnemyBehavior>();
        playerPosition = GameObject.FindGameObjectWithTag("Player").transform;
        chaseSpeed = behavior.chaseSpeed;
        detectRadiusAfterSeen = behavior.detectRadiusAfterSeen;
        canFloat = behavior.canFloat;
       
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // Check for platform
        if (canFloat){
            target.y = playerPosition.position.y;
        } else {
            target.y = animator.transform.position.y;
            behavior.PlatformCheck();
        }
        
        target.x = playerPosition.position.x;

        behavior.WallCheck();

        // Move enemy towards player ONLY HORIZONTALLY
        animator.transform.position = Vector2.MoveTowards(animator.transform.position, target, chaseSpeed * Time.deltaTime);

        // Check if player is in range , if not return back ro patrol state
        if (Vector2.Distance(animator.transform.position, playerPosition.position) > detectRadiusAfterSeen)
        {
            animator.SetBool("isFollowing", false);
        }
        


    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    //override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

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
