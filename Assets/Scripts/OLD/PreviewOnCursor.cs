using UnityEngine;
using System.Collections;

public class PreviewOnCursor : MonoBehaviour {

    Ray ray;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    RaycastHit hit;
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);//straight ray to mouse position
        if (Physics.Raycast(ray, out hit) && hit.collider.name.Equals("Map") )
        {
           // Debug.Log("Map hit!");

        }
	}

}
