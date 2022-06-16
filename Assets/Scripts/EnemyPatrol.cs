using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : StateMachineBehaviour
{
    public float moveSpeed;
    private Transform playerPosition;
    EnemyBehavior behavior;
    public bool canFloat = false;





    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        playerPosition = GameObject.FindGameObjectWithTag("Player").transform;
        behavior = animator.GetComponent<EnemyBehavior>();
        moveSpeed = behavior.patrolSpeed;
        canFloat = behavior.canFloat;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // CHECK FOR PLATFORM -------------
        if (!canFloat){
            behavior.PlatformCheck();
        }

        behavior.WallCheck();
        

        // Move freely
        animator.transform.Translate(Vector2.right * moveSpeed * Time.deltaTime); 


        // Check is player is in range
        if (behavior.PlayerCheck())
        {
            animator.SetBool("isFollowing", true);
        }
        
       
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       
    }


}
