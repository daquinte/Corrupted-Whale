using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PolypController : MonoBehaviour {

    bool corrupted;

    public Material greenMaterial;
    public Material corruptedMaterial;

    BoxCollider collider;

    Renderer rend;

    // Use this for initialization
    void Start () {

        corrupted = false;

        rend = GetComponent<Renderer>();

        rend.sharedMaterial = greenMaterial;

    }
	
	// Update is called once per frame
	void Update () {

        if (corrupted)
        {
            setMaterial(corruptedMaterial);

            this.gameObject.GetComponent<BoxCollider>().isTrigger = false;
        }
        else
        {
            setMaterial(greenMaterial);
            this.gameObject.GetComponent<BoxCollider>().isTrigger = true;
        }
		
	}

    public void setCorrupted (bool isCorrupted)
    {
        corrupted = isCorrupted;
    }

    public bool getCorrupted()
    {
        return corrupted;
    }

    void setMaterial(Material newMaterial)
    {
        rend.sharedMaterial = newMaterial;
    }



}
