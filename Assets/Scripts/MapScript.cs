using UnityEngine;
using System.Collections;

public class MapScript : MonoBehaviour {

    Vector3 previewPos;
    public GameObject previewObject;
    GameObject currentObject;

	// Use this for initialization
	void Start () {
        GameObject.Find("GameLogicObject").GetComponent<GameLogic>().SetNextElementToPreviewElement();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnMouseEnter()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        UnityEngine.Cursor.visible = false;
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
			/*
            if ( diffX >= 0.75 )
			{
				diffX = 1f;
			}
			else
			{
				diffX = 0.5f;
			}
            */
            diffX = 1;
		}
		else
		{
            /*
			if ( diffX >= 0.25 )
			{
				diffX = 0.5f;
			}
			else
			{
				diffX = 0f;
			}
            */
            diffX = 0;
		}

        int newZ = (int)vector.z; // ez truncate-olja a float-ot int-é
        float diffZ = vector.z - newZ;

		if ( diffZ == 0 )
			diffZ = 0f;
		if ( diffZ == 0.5 )
			diffZ = 0f;
		if ( diffZ == 1 )
			diffZ = 1f;
		
		if ( diffZ < 0.5 )
		{
            /*
			if ( diffZ >= 0.75 )
			{
				diffZ = 1f;
			}
			else
			{
				diffZ = 0.5f;
			}
            */
            diffZ = 0;
		}
		else
		{
            /*
			if ( diffZ >= 0.25 )
			{
				diffZ = 0.5f;
			}
			else
			{
				diffZ = 0f;
			}
            */
            diffZ = 1;
		}
        /*
        Vector3 ret = new Vector3(0, 0, 0);

        if ((newX + diffX) > 10 && (newZ + diffZ) < 10)
            ret = new Vector3((newX + diffX) - 1f, vector.y, (newZ + diffZ) + 1f);
        if ((newX + diffX) < 10 && (newZ + diffZ) < 10)
            ret =  new Vector3((newX + diffX) + 1f, vector.y, (newZ + diffZ) + 1f);
        if ((newX + diffX) > 10 && (newZ + diffZ) > 10)
            ret =  new Vector3((newX + diffX) - 1f, vector.y, (newZ + diffZ) - 1f);
        if ((newX + diffX) < 10 && (newZ + diffZ) > 10)
            ret =  new Vector3((newX + diffX) + 1f, vector.y, (newZ + diffZ) - 1f);
        if ((newX + diffX) == 10 && (newZ + diffZ) == 10)
            ret = new Vector3(10, vector.y, 10);
       */
        return new Vector3((newX + diffX), vector.y, (newZ + diffZ));
        /*
        if (ret.x == 0 && ret.y == 0 && ret.z == 0)
        {
            Debug.Log(Input.mousePosition.ToString());
        }

        return ret;
   */      
	}

    void OnMouseOver()
    {
        //if (currentObject != null)
        {
            UnityEngine.Cursor.visible = false;
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
			{
                Vector3 asd = CalculatePositionOnGrid(hit.point);
                previewObject.transform.position = asd;
                previewObject.SetActive(true);
				Debug.Log("asd: " + asd);
                //Debug.Log("mouse: " + hit.point);
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
                Debug.Log("asd: " + asd);
                Debug.Log("mouse: " + hit.point);
                //itt adjuk hozzá a mátrix, x,y koordinátájához, magyarul az asd vektor x, és z koordinátájból számoljuk az x y-t   
                if(PutDownElement(asd))
                { 
                    GameObject afsgdn = (GameObject)Instantiate(previewObject, asd , Quaternion.Euler(new Vector3(0, 0, 0)));
                    GameObject.Find("GameLogicObject").GetComponent<GameLogic>().SetNextElementToPreviewElement();
                }
            }
    }

    // a bal felso (kek) sarok szerint nezi most az ertekeket
    bool PutDownElement(Vector3 asd)
    {
/*        
        if (asd.x > 5 && asd.z < 5)
        {
            asd.x += 0.5f;
            asd.z -= 0.5f;
        }
        if (asd.x < 5 && asd.z < 5)
        {
            asd.x -= 0.5f;
            asd.z -= 0.5f;
        }
        if (asd.x > 5 && asd.z > 5)
        {
            asd.x += 0.5f;
            asd.z += 0.5f;
        }
        if (asd.x < 5 && asd.z > 5)
        {
            asd.x -= 0.5f;
            asd.z += 0.5f;
        }
        if (asd.x == 5 && asd.z == 5)
        {
            asd.x = 5;
            asd.z = 5;
        }
*/
        
        int indexX = ((int) ((asd.x))) - 1 ;
        // a Z a matrixban levö elemektol fugg, ha ott azon az indexen van már elem akkor az Y n+1 lesz
        int indexZ = ((int)((asd.z))) - 1;
        Debug.Log("Index: " + indexX + ", " + indexZ);

        return GameObject.Find("GameLogicObject").GetComponent<GameLogic>().PutElementInMatrix(indexX, indexZ);
    }

    void OnMouseExit()
    {
        UnityEngine.Cursor.visible = true;
        previewObject.SetActive(false);
    }
}
