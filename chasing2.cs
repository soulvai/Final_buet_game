using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class chasing2 : StateMachineBehaviour
{
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    Transform player2;
     NavMeshAgent agent;
     public float atadis=2;
    
     
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    { agent=animator.GetComponent<NavMeshAgent>();
        player2=GameObject.FindGameObjectWithTag("hero2").transform;
        
       
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    { agent.SetDestination(player2.position);
        float dis2=Vector3.Distance(player2.position,animator.transform.position);
    if(dis2<atadis){
         animator.SetBool("attack",true);
         animator.transform.LookAt(player2);
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
