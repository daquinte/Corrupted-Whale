using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Controla el flujo del juego
/// </summary>
public class GameManager : MonoBehaviour
{
    /// <summary>
    /// Singleton
    /// </summary>
    public static GameManager Instance;

    //-------------------INSPECTOR-------------------------
    /// <summary>
    /// Tiempo de spawn de la corrupción
    /// </summary>
    public int SpawnTime;


    /// <summary>
    /// Esta es la instancia de corrupción que va poblando el mundo
    /// </summary>
    public GameObject CorruptionPrefab;

    //-------------------INSPECTOR-------------------------
    //-------------------PROPERTIES-------------------------

    //-------------------PROPERTIES-------------------------

    //-------------------PRIVATE ATTRIBUTES-------------------------

    /// <summary>
    /// El nivel de corrupción del mapa. Cuando la corrupción sea muy alta, el jugador y el entorno moriran
    /// </summary>
    private int corruption;

    /// <summary>
    /// Si es true, la partida ha terminado
    /// </summary>
    private bool gameFinish;
    //-------------------PRIVATE ATTRIBUTES-------------------------

    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        StartCoroutine(Corruption());
    }

    /// <summary>
    /// Corrutina que cada 'x' segundos instancia corrupción en algún punto de los pólipos
    /// </summary>
    /// <returns></returns>
    IEnumerator Corruption()
    {
        while (!gameFinish)
        {
            if (corruption == 100)
                gameFinish = true;

            yield return new WaitForSeconds(3);
        }
        //Y crea las bolas :3
    }
}
