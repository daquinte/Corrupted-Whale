﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    /// <summary>
    /// Esta es la velocidad a la que se mueve la cámara
    /// </summary>
    public float Velocity;

    /// <summary>
    /// Prefab del pólipo
    /// </summary>
    public GameObject PolypPrefab;

    private Camera cameraComponent;

    void Awake () {
        cameraComponent = GetComponent<Camera>();
	}

    // Update is called once per frame
    void Update()
    {
        Move();

        CheckFire();
    }

    /// <summary>
    /// Mueve la cámara en función del input
    /// </summary>
    private void Move()
    {
        Vector2 movCamara = InputManager.Instance.CameraInput;
        transform.position += new Vector3(movCamara.x * Velocity, 0, movCamara.y * Velocity);
    }

    /// <summary>
    /// Comprueba si se ha pulsado la tecla de disprar y dispara en tal caso
    /// Instancia un pólipo en el centro de la cámara en el caso en que colisione con el suelo
    /// </summary>
    private void CheckFire()
    {
        if (InputManager.Instance.StaticPlayerFire)
        {
            RaycastHit hit; //Pium
            Vector3 center = new Vector3(0.5f, 0.5f, 0.5f);  //Dispara al centro de la pantalla
            Ray ray = cameraComponent.ViewportPointToRay(center);  //No es el puto centro real pero no me sale de otra forma.

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.tag == "plane")
                    Instantiate(PolypPrefab, new Vector3(hit.point.x, hit.point.y, hit.point.z), Quaternion.identity);

            }


        }

    }


}