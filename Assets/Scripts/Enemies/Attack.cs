using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : StateMachineBehaviour
{

    //-------------------INSPECTOR-------------------------
    public float MoveSpeed = 5; //move speed
    public float RotationSpeed = 5; //speed of turning
                                    //-------------------INSPECTOR-------------------------
    Animator anim;
    // <summary>
    /// Puntero al jugador dinámico
    /// </summary>
    private PlayerController PlayerFish;

    private GameObject NPC;         //El tiburón
    Animation slowSwim;             //Animacion

    private Rigidbody rigidbodyComp;
    // Use this for initialization
    void Awake()
    {
       
    }

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

        NPC = animator.gameObject;
        PlayerFish = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        anim = animator;
        rigidbodyComp = NPC.GetComponent<Rigidbody>();
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (PlayerFish.PlayerState == PlayerState.MOVING)
        {
            //rotate to look at the player
            rigidbodyComp.MoveRotation(Quaternion.Slerp(NPC.transform.rotation, Quaternion.LookRotation(PlayerFish.transform.position - NPC.transform.position), RotationSpeed * Time.deltaTime));
            //move towards the player
            float step = Time.deltaTime * MoveSpeed;    //Tiempo del Step(tick)
            rigidbodyComp.MovePosition(NPC.transform.position + NPC.transform.forward * step);
        }
        //Está o escondido o muerto. Pasamosa la patrulla
        else {
            anim.SetBool("ataque", false);
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }

    void OnCollisionEnter(Collision col)
    {
        Debug.Log("Me estoy chocando con" + col.gameObject.name);
        if (col.gameObject == PlayerFish.gameObject)
            PlayerFish.PlayerState = PlayerState.DEATH;
    }
}
