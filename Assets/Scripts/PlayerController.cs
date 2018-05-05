using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float speed = 18;

    private Rigidbody rig;

	// Use this for initialization
	void Start () {
        rig = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
        Vector2 getMov = InputManager.Instance.MoveInput;     //Tomamos el control del input
        Vector3 Mov = new Vector3(getMov.x, 0, getMov.y) * speed * Time.deltaTime;

        rig.MovePosition(transform.position + Mov);
        //transform.position += new Vector3(Movement.x, 0, Movement.y) * speed * Time.deltaTime;
	}

}
