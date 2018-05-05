using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Singleton. Guarda el input del mando para ser llamado desde todas las clases que necesitan Input
/// </summary>
public class InputManager : MonoBehaviour
{
    /// <summary>
    /// Singleton
    /// </summary>
    public static InputManager Instance;

    //-------------------INSPECTOR-------------------------
    /// <summary>
    /// Bloquea el input
    /// </summary>
    public bool InputBlocked;

    //-------------------INSPECTOR-------------------------

    //-------------------PROPERTIES-------------------------

    /// <summary>
    /// Devuelve un vector2 con el input del personaje dinamico
    /// </summary>
    public Vector2 MoveInput
    {
        get
        {
            if (InputBlocked)
                return Vector2.zero;
            return movementInput;
        }
    }

    /// <summary>
    /// Devuelve un vector2 con el input del personaje estático
    /// </summary>
    public Vector2 CameraInput
    {
        get
        {
            if (InputBlocked)
                return Vector2.zero;
            return cameraInput;
        }
    }

    /// <summary>
    /// Variable que determina si se ha pulsado el botón de disparar
    /// </summary>
    public bool StaticPlayerFire
    {
        get
        {
            return fire;
        }

        set
        {
            fire = value;
        }
    }
    //-------------------PROPERTIES-------------------------

    //-------------------PRIVATE ATTRIBUTES-------------------------

    protected Vector2 movementInput;
    protected Vector2 cameraInput;

    protected bool fire;   //El botón de acción del jugador estático

    //-------------------PRIVATE ATTRIBUTES-------------------------

    void Awake()
    {
        Instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        movementInput.Set(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        cameraInput.Set(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
        StaticPlayerFire = Input.GetButtonDown("Fire1");
    }
}
