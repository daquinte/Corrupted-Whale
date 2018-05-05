﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : StateMachineBehaviour {

    GameObject NPC;
    GameObject[] waypoints;
    static int currentWP;       //Static para que se mantenga

    Animation slowSwim;
    Animator anim;
    // <summary>
    /// Puntero al jugador dinámico
    /// </summary>
    private GameObject PlayerFish;

    void Awake()
    {
      
    }


	 // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
	override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {

        PlayerFish = GameObject.FindGameObjectWithTag("Player");
        
        waypoints = GameObject.FindGameObjectsWithTag("waypointAbajo");

        
        NPC = animator.gameObject;
        anim = animator;
        currentWP = 0;
    }

	// OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
	override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        if (waypoints.Length == 0) return;
        Debug.Log(Vector3.Distance(PlayerFish.transform.position, NPC.transform.position));

        if (Vector3.Distance(PlayerFish.transform.position, NPC.transform.position) < 20.0f)
        {
            //Ir al state de ataque
            Debug.Log("AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAa");
            anim.SetBool("ataque", true);
        }

        

        else if (Vector3.Distance(waypoints[currentWP].transform.position, NPC.transform.position) < 3.0f)
        {
            currentWP++;
            if (currentWP >= waypoints.Length)
            {
                currentWP = 0;
            }
        }

       
        var direction = waypoints[currentWP].transform.position - NPC.transform.position;
        NPC.transform.rotation = Quaternion.Slerp(NPC.transform.rotation, Quaternion.LookRotation(direction), 2.80f * Time.deltaTime);
        NPC.transform.Translate(0, 0, Time.deltaTime * 7.0f);
	}

	// OnStateExit is called when a transition ends and the state machine finishes evaluating this state
	override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        //Si sale, va a pasar al estado de ataque y tiene que guardar su waypoint para luego
        Debug.Log("CHAAAAAAAAAAO PESCAO");
	}

	// OnStateMove is called right after Animator.OnAnimatorMove(). Code that processes and affects root motion should be implemented here
	//override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	//
	//}

	// OnStateIK is called right after Animator.OnAnimatorIK(). Code that sets up animation IK (inverse kinematics) should be implemented here.
	//override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	//
	//}
}
