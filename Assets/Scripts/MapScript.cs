using UnityEngine;
using System.Collections;

public class MapScript : MonoBehaviour {

    Vector3 previewPos;
    public GameObject previewObject;
    GameObject currentObject;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnMouseEnter()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit))
        {
			Vector3 asd  = CalculatePositionOnGrid( hit.point );
            Debug.Log(asd);
            previewObject.transform.position = asd;
            previewObject.SetActive(true);
           // currentObject = (GameObject)Instantiate(previewObject, hit.point, Quaternion.Euler(new Vector3(0, 0, 0)));
        }
    }
	
	//ezzel csak a pont utáni értéket határozzuk meg, nem a végleges poziciót ( pl -3.6 -> -3.5-re javítás ) 
	Vector3 CalculatePositionOnGrid( Vector3 vector )
	{
        int newX = (int)vector.x; // ez truncate-olja a float-ot int-é
        float diffX = vector.x - newX;
		if ( diffX == 0 )
			diffX = 0f;
		if ( diffX == 0.5 )
			diffX = 0.5f;
		if ( diffX == 1 )
			diffX = 1f;
		
		if ( diffX > 0.5 )
		{
			if ( diffX >= 0.75 )
			{
				diffX = 1f;
			}
			else
			{
				diffX = 0.5f;
			}
		}
		else
		{
			if ( diffX >= 0.25 )
			{
				diffX = 0.5f;
			}
			else
			{
				diffX = 0f;
			}
		}

        int newZ = (int)vector.z; // ez truncate-olja a float-ot int-é
        float diffZ = vector.z - newX;

		if ( diffZ == 0 )
			diffZ = 0f;
		if ( diffZ == 0.5 )
			diffZ = 0.5f;
		if ( diffZ == 1 )
			diffZ = 1f;
		
		if ( diffZ > 0.5 )
		{
			if ( diffZ >= 0.75 )
			{
				diffZ = 1f;
			}
			else
			{
				diffZ = 0.5f;
			}
		}
		else
		{
			if ( diffZ >= 0.25 )
			{
				diffZ = 0.5f;
			}
			else
			{
				diffZ = 0f;
			}
		}

        return new Vector3((newX + diffX) - 0.5f, vector.y, (newZ + diffZ) + 0.5f);
	}

    void OnMouseOver()
    {
        //if (currentObject != null)
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
			{
                Vector3 asd = CalculatePositionOnGrid(hit.point);
                previewObject.transform.position = asd;
                previewObject.SetActive(true);
				Debug.Log(asd);
			}
			
        }
    }

    void OnMouseDown()
    {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                Vector3 asd = CalculatePositionOnGrid(hit.point);
                //itt adjuk hozzá a mátrix, x,y koordinátájához, magyarul az asd vektor x, és z koordinátájból számoljuk az x y-t
                int indexX = (int)((asd.x + 0.5f) / (1f/2f)); //matrixban az elso index
                // a Z a matrixban levö elemektol fugg, ha ott azon az indexen van már elem akkor az Y n+1 lesz
                int indexZ = (int)((asd.z - 0.5f) / (1f/2f));
                GameObject a = (GameObject)Instantiate(previewObject, asd , Quaternion.Euler(new Vector3(0, 0, 0)));
                Debug.Log("Index: " + indexX + ", " + indexZ);
            }
    }

    void OnMouseExit()
    {
        previewObject.SetActive(false);
    }
}
