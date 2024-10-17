using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class patrolling : StateMachineBehaviour
{
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    float timer;
    NavMeshAgent agent;
    Transform player;
    Transform player2;
    public float distance;
    List<Transform>waypoints=new List<Transform>();
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {timer=0;
    agent=animator.GetComponent<NavMeshAgent>();
       GameObject go=GameObject.FindGameObjectWithTag("Waypoint");
       foreach(Transform t in go.transform){
        waypoints.Add(t);
       }
       player=GameObject.FindGameObjectWithTag("hero").transform;
       player2=GameObject.FindGameObjectWithTag("hero2").transform;
       
       agent.SetDestination(waypoints[Random.Range(0,waypoints.Count-1)].position);
    
    
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
        if(agent.remainingDistance<=agent.stoppingDistance){
            agent.SetDestination(waypoints[Random.Range(0,waypoints.Count-1)].position);
    

        }
    timer+=Time.deltaTime;
    if(timer>10){
        animator.SetBool("isPatrolling",false);
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
       agent.SetDestination(agent.transform.position);
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
