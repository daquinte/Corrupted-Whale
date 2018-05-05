using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerHierba : MonoBehaviour {

    public int TiempoVida;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider col)
    {
        if(col.name == "Pez")
        {
            MatujaTimer();
        }
    }

    void OnTriggerExit(Collider col)
    {
        //Pum ahora tienes colision puta
        //col.gameObject.AddComponent<BoxCollider>();
        //col.GetComponent<PlayerColision>().SetASalvo(false);
        col.GetComponent<BoxCollider>().enabled = true;
    }

    /// <summary>
    /// Este timer sirve para que la matuja se destruya pasados n segundos.
    /// </summary>
    IEnumerator MatujaTimer()
    {
       
        yield return new WaitForSeconds(TiempoVida);
        //col.GetComponent<PlayerColision>().SetASalvo(false);
        Destroy(gameObject);
    
    }
    
}
