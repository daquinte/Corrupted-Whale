using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public enum PlayerState { MOVING, HIDING, HIDE, DEATH }

/// <summary>
/// Controla el movimiento del personaje
/// Necesita de un rigidbody asociado
/// </summary>
public class PlayerController : MonoBehaviour {


    public PlayerState PlayerState { get { return state; } set { state = value; } }


    /// <summary>
    /// Velocidad de movimiento del personaje
    /// </summary>
    public float speed;

    /// <summary>
    /// Rigidbody del personaje
    /// </summary>
    private Rigidbody rigidbodyComp;

    /// <summary>
    /// Estado actual del personaje
    /// </summary>
    private PlayerState state;

    /// <summary>
    /// Referencia al pólipo para poder borrarlo
    /// </summary>
    private GameObject currentPolyp;

    /// <summary>
    /// Vector de rotacion
    /// </summary>
    private Vector3 m_EulerAngleVelocity;

    void Start () {
        rigidbodyComp = GetComponent<Rigidbody>();
        state = PlayerState.MOVING;
	}
	
	void Update () {
        if (state == PlayerState.MOVING)
        {
            //Tomamos el control del input
            Vector2 getMov = InputManager.Instance.MoveInput;
            Vector3 Mov = new Vector3(getMov.x, 0, getMov.y) * speed * Time.deltaTime;

            rigidbodyComp.MovePosition(transform.position + Mov);


            //Vamos a girarlo jaja
            if (InputManager.Instance.TurningRight)
            {
                Debug.Log("Derecha");
                m_EulerAngleVelocity = new Vector3(0, 100, 0);

                Quaternion deltaRotation = Quaternion.Euler(m_EulerAngleVelocity * Time.deltaTime);
                rigidbodyComp.MoveRotation(rigidbodyComp.rotation * deltaRotation);
            }

            else if (InputManager.Instance.TurningLeft)
            {
                m_EulerAngleVelocity = new Vector3(0, -100, 0);

                Quaternion deltaRotation = Quaternion.Euler(m_EulerAngleVelocity * Time.deltaTime);
                rigidbodyComp.MoveRotation(rigidbodyComp.rotation * deltaRotation);
            }
            
        }
	}

    /// <summary>
    /// Cuando entra en el pólipo, se oculta
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Polyp")
        {
            currentPolyp = other.gameObject;
            state = PlayerState.HIDING;
            transform.DOMove(other.gameObject.transform.position + new Vector3 (0.0f,1.0f,0.0f),2.0f).SetEase(Ease.OutQuint).onComplete+= OnEndHiding;
        }
    }

    /// <summary>
    /// Es llamado cuando acaba la corrutina de ocultarse
    /// </summary>
    private void OnEndHiding()
    {
        Destroy(currentPolyp);
        state = PlayerState.HIDE;
        transform.DOMove(this.transform.position + new Vector3 (0.0f,1.0f,0.0f), 1.0f).SetEase(Ease.OutQuint).onComplete+=OnEndHide;

    }

    private void OnEndHide()
    {
        state = PlayerState.MOVING;

    }

}
