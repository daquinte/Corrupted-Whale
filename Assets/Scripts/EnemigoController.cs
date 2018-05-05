using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemigoController : MonoBehaviour {
    /// <summary>
    /// Puntero al jugador dinámico, que será el pez :3
    /// </summary>
    public GameObject pez;
    public float moveSpeed = 5; //move speed
    public float rotationSpeed = 5; //speed of turning

    //private Rigidbody rb;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        //Ia muy tonta para que se mueva hacia el jugador
        //rotate to look at the player
        if(pez != null) { 
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(pez.transform.position - transform.position), rotationSpeed * Time.deltaTime);


            //move towards the player
            transform.position += transform.forward * Time.deltaTime * moveSpeed;
        }
    }
}
