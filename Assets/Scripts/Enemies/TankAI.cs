using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankAI : MonoBehaviour {

    Animator anim;
    public GameObject player;

    public GameObject GetPlayer()
    {
        return player;
    }

	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
	}
	
	// Si el personaje está en movimiento, el enemigo lo buscará. Si está escondido, entonces establece que está lejos de él
	void Update () {

        if (player.GetComponent<PlayerController>().PlayerState == PlayerState.MOVING)
        {
            anim.SetFloat("distancia", Vector3.Distance(transform.position, player.transform.position));
        }

        else anim.SetFloat("distancia", 30);

    }
}
