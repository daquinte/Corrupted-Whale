using UnityEngine;
using UnityEngine.AI;

public class SharkController : MonoBehaviour {

    //public Camera cam;
    //public NavMeshAgent shark;
	//// Update is called once per frame
	void Update () {

        transform.position = new Vector3(transform.position.x, - 1.5f, transform.position.z);
		//if (Input.GetMouseButton(0))
        //{
        //    Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        //    
        //    RaycastHit hit;
        //    Debug.Log(Physics.Raycast(ray, out hit));
        //    if (Physics.Raycast(ray, out hit)) {
        //
        //        Debug.Log("He entrado");
        //        // Mover el agente
        //        shark.SetDestination(hit.point);
        //    }
        //}
	}
}
