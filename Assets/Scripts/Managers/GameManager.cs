using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


/// <summary>
/// Controla el flujo del juego
/// </summary>
public class GameManager : MonoBehaviour
{

    public bool Muerto = false;

    /// <summary>
    /// Singleton
    /// </summary>
    public static GameManager Instance;
    /// <summary>
    /// Cámara principal del juego
    /// </summary>
    public Camera cam;
    /// <summary>
    /// Prefab del polipo
    /// </summary>
    public GameObject polipo;

    /// <summary>
    /// Mide de forma gráfica lo jodido que estas
    /// </summary>
    public Image medidorCorrupcion;
    
    /// <summary>
    /// Máximo número de corrupción a liberar para ganar. Público para poder decidir más facilmente el valor
    /// </summary>
    public int salvadosMax;

    /// <summary>
    /// Máximo número de corrupción a liberar para ganar. Público para poder decidir más facilmente el valor
    /// </summary>
    public int corruptosMax;

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

    //LA LISTA DE MOVIDAS CORRUPTAS
    /// <summary>
    /// Aquí se guarda la lista de polipos corruptos que hay en escena
    /// </summary>
    List<GameObject> listaCorruptos;

    //-------------------PRIVATE ATTRIBUTES-------------------------

    /// <summary>
    /// El nivel de corrupción del mapa. Cuando la corrupción sea muy alta, el jugador y el entorno moriran
    /// </summary>
    private int corruption;

    /// <summary>
    /// Si es true, la partida ha terminado
    /// </summary>
    private bool gameFinish;

    /// <summary>
    /// Cantidad de corrupción liberada
    /// </summary>
    private int corrupcionEliminada = 0;
    //-------------------PRIVATE ATTRIBUTES-------------------------

    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        listaCorruptos = new List<GameObject>();
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

            //Y crea la corrupción
            CreaCorrupto();

            int elegido = Random.Range(0, listaCorruptos.Count);

            listaCorruptos[elegido].GetComponent<PolypController>().SetCorrupted(true); // You are blue now
        }
    }

    private void Update()
    {

        if (!gameFinish) {
            if(Random.Range(0, 50) == 50)      //10% de probabilidad de generar polipo
                CreaCorrupto();

            if (corrupcionEliminada == salvadosMax) SceneManager.LoadScene("Win");


            if (Muerto && corruption == corruptosMax) SceneManager.LoadScene("GameOver");

            int elegido = Random.Range(0, listaCorruptos.Count);

            listaCorruptos[elegido].GetComponent<PolypController>().SetCorrupted(true); // You are blue now

            medidorCorrupcion.fillAmount += corruption/100; //100 = 1
        }
    }

    public void CreaCorrupto()
    {

        // Dimensiones del mapa
        int x = Random.Range(-61, 69);
        int z = Random.Range(23, 40);
        Vector3 spawn = new Vector3(x, -5, z);

        // Script del tiburon para comprobar si puede acceder al punto del navmesh
        // lo usamos para comprobar si podemos spawnear un polipo
        Ray ray = cam.ScreenPointToRay(spawn);

        RaycastHit hit;
        Debug.Log(Physics.Raycast(ray, out hit));
        if (Physics.Raycast(ray, out hit))
        {
            if(hit.collider.tag == "Spawn")
            {
                GameObject polyp;

                polyp = Instantiate(polipo, spawn, Quaternion.identity);

                polyp.GetComponent<PolypController>().SetCorrupted(true);

                listaCorruptos.Add(polyp);

                SumaCorruption();
            }
        }
    }


    public void QuitaCorrupto(GameObject obj)
    {

        bool stop = false;
        int i = 0;
        while (!stop && i < listaCorruptos.Count)
        {
            if (listaCorruptos[i] == obj)
            {
                stop = true;
            }

            i++;
        }

        listaCorruptos.Remove(listaCorruptos[i]);
        //Aumenta los salvados y la corrupción disminuye
        corruption--;
        SumaSalvados();

    }

    public void SumaCorruption()
    {
        if (corruption < corruptosMax)
            corruption++;
    }

    public void SumaSalvados()
    {
        corrupcionEliminada++;
    }

    public void setMuerto()
    {
        Muerto = true;
        SceneManager.LoadScene("GameOver");
    }
}


