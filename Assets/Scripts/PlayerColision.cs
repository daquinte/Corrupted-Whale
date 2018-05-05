using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PlayerColision : MonoBehaviour {
    
    /// <summary>
    /// Método que provoca que cuando el enemigo se choque con el portador del script, este muera.
    /// </summary>
    /// <param name="col"> La colisión con la que choca este objeto </param>
    void OnCollisionEnter(Collision col)
    {
        Debug.Log("Me estoy chocando con" + col.gameObject.name);
        if (col.gameObject.name == "ElMalo")
        {
            Destroy(gameObject);
        }
    }
}
