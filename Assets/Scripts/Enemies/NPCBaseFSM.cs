using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCBaseFSM : StateMachineBehaviour {

    public GameObject NPC;
    public GameObject opponent;
    public float speed = 7.0f;
    public float rotSpeed = 2.80f;
    public float accuary = 3.0f;


    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        NPC = animator.gameObject;
        opponent = NPC.GetComponent<TankAI>().GetPlayer();
    }
}
