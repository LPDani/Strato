using UnityEngine;
using System.Collections;

public class GameLogic : MonoBehaviour {

    public struct Tile
    {
        public Tile(string name, int color, bool free = true)
            : this()
        {
            this.Playername = name;
            this.TileColor = color;
            this.isFree = free;
        }
        public string Playername { get; set; }
        public int TileColor { get; set; } // 0 - fekete, 1 - piros, 2 - zold
        public bool isFree { get; set; }

    }

    Tile[, ,] gridMap;

	// Use this for initialization
	void Start () {
	    gridMap = new Tile[20, 20, 3];
        setMapFree();
	}

    private void setMapFree()
    {
        for (int i = 0; i < 19; i++)
        {
            for (int j = 0; j < 19; j++)
            {
                for (int k = 0; k < 2; k++)
                {
                    gridMap[i, j, k].isFree = true;
                }
            }
        }
    }
	
	// Update is called once per frame
	void Update () {
	}

    public bool PutElementInMatrix(int indexX, int indexZ)
    {
        //most igy van (nincs rorate)
        if ( indexX >= 0 && indexX <= 19 && indexZ >= 0 && indexZ <= 19)
        {
            if ( gridMap[indexX, 0, indexZ].isFree &&
            gridMap[indexX+1, 0, indexZ].isFree &&
            gridMap[indexX+1, 0, indexZ+1].isFree )
            { 
                Tile asd =  new Tile("asd",0,false);
                gridMap[indexX, 0, indexZ] = asd;
                gridMap[indexX+1, 0, indexZ] = asd;
                gridMap[indexX+1, 0, indexZ+1] = asd;
                return true;
            }
        }
        return false;

    }
}
