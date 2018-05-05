using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyController : MonoBehaviour {

    //-------------------INSPECTOR-------------------------
    public float MoveSpeed = 5; //move speed
    public float RotationSpeed = 5; //speed of turning
    //-------------------INSPECTOR-------------------------

    /// <summary>
    /// Puntero al jugador dinámico
    /// </summary>
    private PlayerController PlayerFish;


    //private Rigidbody rb;

    // Use this for initialization
    void Start () {
        PlayerFish = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>() ;
    }
	
	// Update is called once per frame
	void Update () {
        //Ia muy tonta para que se mueva hacia el jugador
        //rotate to look at the player
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(PlayerFish.transform.position - transform.position), RotationSpeed * Time.deltaTime);
            //move towards the player
            transform.position += transform.forward * Time.deltaTime * MoveSpeed;
    }

    /// <summary>
    /// Método que provoca que cuando el enemigo se choque con el portador del script, este muera.
    /// </summary>
    /// <param name="col"> La colisión con la que choca este objeto </param>
    void OnCollisionEnter(Collision col)
    {
        Debug.Log("Me estoy chocando con" + col.gameObject.name);
        if (col.gameObject == PlayerFish.gameObject)
            PlayerFish.PlayerState = PlayerState.DEATH;
    }
}
