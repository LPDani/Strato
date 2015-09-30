using UnityEngine;
using System.Collections;

public class NodeManager : MonoBehaviour {

    //Node[,] NodeMap = new Node[10,10];

    public int nMapZWidth = 10;
    public int nMapXLength = 10;
    public int nMapYHeight = 3;

    Node[, ,] NodeMap; // = new Node[nMapZWidth, nMapXLength, nMapYHeight];

    public float fNodeSize = 0.6f;
    public float fNodeHeight = 0.16f;

    public GameObject nodeObject;

	// Use this for initialization
	void Start () {
        NodeMap = new Node[nMapZWidth, nMapXLength, nMapYHeight];
        float xPos = 0.6f - nMapXLength / 2 * fNodeSize;
        float zPos = 0.6f - nMapZWidth / 2 * fNodeSize;
        float yPos = 0.16f - nMapYHeight / 2 * fNodeHeight;

        for (int k = 0; k < nMapYHeight; k++) {
            for (int j = 0; j < nMapZWidth; j++)
            {
                for (int i = 0; i < nMapXLength; i++)
                {
                    NodeMap[i, j, k] = new Node(new Vector3(xPos + i * fNodeSize, yPos + k * fNodeHeight, zPos + j * fNodeSize) /* true */);
                    // Debug.Log(NodeMap[i].nodePosition.x + " " + NodeMap[i].nodePosition.y + " " + NodeMap[i].nodePosition.z);
                }
                //Debug.Log(j);
            }
        }
        foreach (Node node in NodeMap)
        {
            //Debug.Log(nodeObject.transform.right);
            if(node != null)
                Instantiate(nodeObject, node.nodePosition, Quaternion.Euler( new Vector3(90,0,0) ) );
        }
    }
   
        

	// Update is called once per frame
	void Update () {

	}
}
