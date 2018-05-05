using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    /// <summary>
    /// El nivel de corrupción del mapa. Cuando la corrupción sea muy alta, el jugador y el entorno moriran
    /// </summary>
    int Corrupcion;
    public int TiempoSpawn;
    /// <summary>
    /// Esta es la instancia de corrupción que va poblando el mundo
    /// </summary>
    GameObject unidadCorrupcion;
    

    bool FinJuego;      //Fin de la partida
	// Use this for initialization
	void Start () {
		//Llamas a la corutina de corrupcion del mundo (o algo así xd)
	}
	
	// Update is called once per frame
	void Update () {

        if (Corrupcion == 100) FinJuego = true;
	}

    IEnumerator consumeMundo()
    {
        yield return new WaitForSeconds(3);
        //Y crea las bolas :3
    }
}
