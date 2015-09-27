using UnityEngine;
using System.Collections;

public class NodeManager : MonoBehaviour {

    Node[,] NodeMap = new Node[10,10];

    public int nMapZWidth;
    public int nMapXLength;
    public int nMapYHeight;

    public float fNodeSize = 0.6f;
    public float fNodeHeight = 0.16f;

    public GameObject nodeTexture;

	// Use this for initialization
	void Start () {
        float xPos = 0 - nMapXLength / 2 * fNodeSize;
        float zPos = 0 - nMapZWidth / 2 * fNodeSize;
        for (int j = 0; j < nMapZWidth; j++ ){
            for (int i = 0; i < nMapXLength; i++)
            {
                NodeMap[i,j] = new Node(new Vector3(xPos + i * fNodeSize, 0, zPos + j * fNodeSize) /* true */);
               // Debug.Log(NodeMap[i].nodePosition.x + " " + NodeMap[i].nodePosition.y + " " + NodeMap[i].nodePosition.z);
            }
            //Debug.Log(j);
        }
        foreach (Node node in NodeMap)
        {
            Instantiate(nodeTexture, node.nodePosition, new Quaternion(0, 0, 0, 0));
        }
    }
   
        

	// Update is called once per frame
	void Update () {
	
	}
}
