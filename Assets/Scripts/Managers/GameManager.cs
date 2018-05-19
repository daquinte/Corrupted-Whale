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
    List<GameObject> listaPolipos;

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
    int elegido;    //Polipo elegido para corromperse

    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        listaPolipos = new List<GameObject>();

    }

    /// <summary>
    /// Corrutina que cada 'x' segundos instancia corrupción en algún punto de los pólipos
    /// </summary>
    /// <returns></returns>
   
    private void Update()
    {
        if (corruption == 100)
            gameFinish = true;

        if (!gameFinish) {
            //10% de probabilidad de generar polipo
            if (Random.Range(0, 70) == 40)
            {      
                CreaCorrupto();                                                                 //Toma pólipo, puta
               
            }
            //20% de probabiidad de hacer un polipo actual corrupto
            if (Random.Range(0,40) == 10 && listaPolipos.Count != 0 )
            {
                elegido = Random.Range(0, listaPolipos.Count);                                //Elegimos uno
                //Pregunto si ya está corrupto
                if (!listaPolipos[elegido].GetComponent<PolypController>().corrupted)
                {
                    listaPolipos[elegido].GetComponent<PolypController>().SetCorrupted(true);     // You are blue now
                    medidorCorrupcion.fillAmount += corruption / 100; //100 = 1                     //Actualizo el medidor
                }
            }

            //CONDICIONES DE FIN DE PARTIDA: Lo que llegue antes
            if (corrupcionEliminada == salvadosMax) SceneManager.LoadScene("Win");

            if (Muerto || corruption == corruptosMax) SceneManager.LoadScene("GameOver");
            
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

                polyp.GetComponent<PolypController>().Init();
                polyp.GetComponent<PolypController>().SetCorrupted(true);

                listaPolipos.Add(polyp);

                SumaCorruption();
            }
        }
    }
    /// <summary>
    /// Mete un pólipo, normalmente sano, en la lista
    /// </summary>
    /// <param name="polipo"></param>
    public void MetePolipo(GameObject polipo)
    {
        listaPolipos.Add(polipo);
    }

    public void QuitaCorrupto(GameObject obj)
    {

        bool stop = false;
        int i = 0;
        while (!stop && i < listaPolipos.Count)
        {
            if (listaPolipos[i] == obj)
            {
                stop = true;
            }

            i++;
        }

        listaPolipos.Remove(listaPolipos[i]);
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


