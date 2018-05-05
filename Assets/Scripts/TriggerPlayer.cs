using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerPlayer : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    /// <summary>
    /// Los triggers del jugador SOLO se van a comunicar con la matuja, y van a reaccionar dependiendo de si está o no en ella
    /// Para poder activar y desactivar su collider
    /// </summary>
    /// <param name="col"></param>
    public void OnTriggerEnter(Collider col)
    {
        if (col.name == "Matuja")
        {
            //Hemos entrado en la matuja: Nos desactivamos
            gameObject.GetComponent<BoxCollider>().enabled = false;
        }
    }

    public void OnTriggerExit(Collider col)
    {
        if (col.name == "Matuja")
        {
            //Hemos salido de la matuja: Nos activamos
            gameObject.GetComponent<BoxCollider>().enabled = true;
        }
    }
}
