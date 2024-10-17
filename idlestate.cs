using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.InputSystem.Controls;

public class idlestate : StateMachineBehaviour
{
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this statef
    float timer;
    Transform player;
    Transform player2;
    
    public float distance=8;
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       timer=0;
       player=GameObject.FindGameObjectWithTag("hero").transform;
       player2=GameObject.FindGameObjectWithTag("hero2").transform;
       
       
    
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
        timer += Time.deltaTime;

        // After 5 seconds, switch to the "isPatrolling" state
        if (timer > 5)
        {
            animator.SetBool("isPatrolling", true);
        }

        float dis=Vector3.Distance(player.position,animator.transform.position);

float dis2=Vector3.Distance(player2.position,animator.transform.position);


    if(dis<distance){

        animator.SetBool("ischasing",true);
    }
    
    if(dis2<distance){

        animator.SetBool("ischasing",true);
    }
    
    
    
    
    
    
    
    
    
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
