using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PolypController : MonoBehaviour {

    //Esto está público para las pruebas, pero luego no debería serlo
     public bool corrupted;

    public Material greenMaterial;
    public Material corruptedMaterial;

    public ParticleSystem particles;

    Renderer rend;

    // Use this for initialization
    void Start () {

        //corrupted = false;

        rend = GetComponent<Renderer>();

        rend.sharedMaterial = greenMaterial;

        if (corrupted)
        {
            SetMaterial(corruptedMaterial);

            this.gameObject.GetComponent<BoxCollider>().isTrigger = false;
        }
        else
        {
            SetMaterial(greenMaterial);
        }

    }
    
    public void Init()
    {
        Start();
    }
	
	// Update is called once per frame
	void Update () {

     
		
	}

    public void SetCorrupted (bool isCorrupted)
    {
        corrupted = isCorrupted;

        if (corrupted)
        {
            SetMaterial(corruptedMaterial);

            this.gameObject.GetComponent<BoxCollider>().isTrigger = false;
        }
        else
        {
            StartCoroutine("CorruptionTransition");
            SetMaterial(greenMaterial);
        }
    }

    IEnumerator CorruptionTransition()
    {
        Vector3 polypPosition = new Vector3(this.gameObject.transform.position.x, 0, this.gameObject.transform.position.z);

        particles = Instantiate(particles, polypPosition, Quaternion.identity);
        particles.Play();

        GameManager.Instance.QuitaCorrupto(this.gameObject);   //Informa al GameObject de que este gameobject ha muerto

        yield return new WaitForSeconds(0.5f);

        this.gameObject.GetComponent<BoxCollider>().isTrigger = true;
        //TODO: Comprobar por qué los polipos creados por Space no borran particulas
        //->Se corrompen mientras se destruye lmao
        particles.Stop();
        corrupted = false;
       

    }

    public bool GetCorrupted()
    {
        return corrupted;
    }

    void SetMaterial(Material newMaterial)
    {
       rend.sharedMaterial = newMaterial;
    }



}
