using UnityEngine;
using System.Collections;

public class MapManager : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    Vector3 previewPos;
    public GameObject previewObject;
    GameObject currentObject;

    void OnMouseEnter()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit))
        {
            //Debug.Log(hit.point);
            currentObject = (GameObject)Instantiate(previewObject, hit.point, Quaternion.Euler(new Vector3(0, 0, 0)));
        }
    }

    void OnMouseOver()
    {
        if (currentObject != null)
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
                currentObject.transform.position = hit.point;
        }
    }

    void OnMouseClick()
    {
        if (currentObject != null)
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                //Debug.Log(hit.point);
                //currentObject = (GameObject)Instantiate(previewObject, hit.point, Quaternion.Euler(new Vector3(0, 0, 0)));
                currentObject.transform.position = hit.point;
            }
            currentObject = null;
        }
    }

    void OnMouseLeave()
    {
        if (currentObject != null)
            currentObject = null;
    }
}
