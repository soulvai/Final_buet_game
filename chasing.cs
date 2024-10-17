using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System;
using Unity.Mathematics;

public class chasing : StateMachineBehaviour
{
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
     NavMeshAgent agent;
     Transform player;
     Transform player2;
     
     
     public float distance;
     public float atadis;
     
    
  
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
         agent=animator.GetComponent<NavMeshAgent>();
        player=GameObject.FindGameObjectWithTag("hero").transform;
        player2=GameObject.FindGameObjectWithTag("hero2").transform;
        
        agent.speed=10.0f;
         float dis=Vector3.Distance(player.position,animator.transform.position);
      float dis2=Vector3.Distance(player2.position,animator.transform.position);
      

      dis=Math.Min(dis,dis2);
      
      
      if(dis>distance  && dis<130){
         animator.SetBool("ischasing",true);
      }
      
      if(dis>130){
         animator.SetBool("ischasing",false);

      }
     
     
     if(dis<atadis){
         animator.SetBool("attack",true);


    }


  
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
      
      float dis=Vector3.Distance(player.position,animator.transform.position);
      float dis2=Vector3.Distance(player2.position,animator.transform.position);

      dis=Math.Min(dis,dis2);
      
        if(dis<atadis){
         animator.SetBool("attack",true);
         if(dis<dis2){
animator.transform.LookAt(player);
         }
else{
   animator.transform.LookAt(player2);
}

    }


       if(dis<dis2  && dis>50){
       agent.SetDestination(player.position);
       }
       else if(dis2<dis && dis2>50){
         agent.SetDestination(player2.position);
       }
    
    
    }


    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
          agent.SetDestination(animator.transform.position);
          
    
    }

    // OnStateMove is called right after Animator.OnAnimatorMove()
    override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       // Implement code that processes and affects root motion
    }

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}
