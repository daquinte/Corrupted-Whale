using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class oscilacionCabeza : MonoBehaviour {

    float oscilacion = 0; // Entre -1 y 1 creo que iria bien
	// Use this for initialization
	void Start () {
        StartCoroutine("restaOscilacion");
    }
	
	// Update is called once per frame
	void Update () {
        
        transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y , transform.eulerAngles.z + oscilacion);
    }

    IEnumerator restaOscilacion()
    {
        while (oscilacion >= -100)
        {
            oscilacion -= 0.1f;

            yield return new WaitForSeconds(0.1f);
        }
        sumaOscilacion();
    }

    IEnumerator sumaOscilacion()
    {
        while (oscilacion <= 100)
        {
            oscilacion += 0.1f;

            yield return new WaitForSeconds(0.1f);
        }
        restaOscilacion();
    }
}
