using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour {

    public bool playerControllerInputBlocked;
    protected bool m_ExternalInputBlocked;

    protected Vector2 m_Movement;
    protected Vector2 m_Camera;

    protected bool m_CameraClick;   //El botón de acción del jugador estático
    
    /// <summary>
    /// Singleton
    /// </summary>
    public static InputManager Instance;

    void Awake()
    {
        Instance = this;
    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        m_Movement.Set(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        m_Camera.Set(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
        if (Input.GetButtonDown("Fire1"))
        {
            m_CameraClick = true;
        }
    }


    /// <summary>
    /// Get de las variables de Input
    /// </summary>
    public Vector2 MoveInput
    {
        get
        {
            if (playerControllerInputBlocked || m_ExternalInputBlocked)
                return Vector2.zero;
            return m_Movement;
        }
    }

    public Vector2 CameraInput
    {
        get
        {
            if (playerControllerInputBlocked || m_ExternalInputBlocked)
                return Vector2.zero;
            return m_Camera;
        }
    }

    public bool StaticPlayerFire
    {
        get
        {
            if (m_CameraClick == true)
            {
                m_CameraClick = false;
                return true;
            }

            return false;
        }
    }




}
