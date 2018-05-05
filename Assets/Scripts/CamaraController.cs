using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraController : MonoBehaviour {

    /// <summary>
    /// Esta es la velocidad a la que se mueve la cámara
    /// </summary>
    public float Velocity;
    public GameObject Alga;

    private Camera camera;
   

    // Use this for initialization
    void Start () {
        camera = GetComponent<Camera>();
	}

    // Update is called once per frame
    void Update()
    {
        //Toma el vector 2 del inputManager y se lo aplica a la cámara para moverla
        Vector2 movCamara = InputManager.Instance.CameraInput;
        transform.position += new Vector3(movCamara.x * Velocity, 0, movCamara.y * Velocity);

        //Disparo del jugador estático
        if (InputManager.Instance.StaticPlayerFire)
        {
            RaycastHit hit; //Pium
            Vector3 centro = new Vector3(0.5f, 0.5f, 0);  //Dispara al centro de la pantalla
            Ray ray = camera.ViewportPointToRay(centro);  //No es el puto centro real pero no me sale de otra forma.
           
            if (Physics.Raycast(ray, out hit))
            {
                if(hit.transform.name == "Plane")
                {
                    Instantiate(Alga, new Vector3(hit.point.x, hit.point.y, 0), Quaternion.identity);
                }
                // Do something with the object that was hit by the raycast.
            }


        }
    }


}
