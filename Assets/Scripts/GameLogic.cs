using UnityEngine;
using System.Collections;
using System.Collections.Generic;

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

    public struct playersTile
    {
        public playersTile(Tile t1, Tile t2, Tile t3)
            : this()
        {
            this.t1 = t1;
            this.t2 = t2;
            this.t3 = t3;
        }

        public Tile t1;
        public Tile t2;
        public Tile t3;
    }

    Tile[, ,] gridMap;
    List<playersTile> greenPlayerTiles;
    List<playersTile> redPlayerTiles;
    playersTile nextPlayerTile;

    public GameObject T1CB; // tile1colorGreen
    public GameObject T1CG; // tile1colorGreen
    public GameObject T1CR; // tile1colorGreen

    public GameObject T2CB; // tile2colorGreen
    public GameObject T2CG; // tile2colorGreen
    public GameObject T2CR; // tile2colorGreen

    public GameObject T3CB; // tile3colorGreen
    public GameObject T3CG; // tile3colorGreen
    public GameObject T3CR; // tile3colorGreen
	// Use this for initialization
	void Start () {
	    gridMap = new Tile[20, 20, 3];
        greenPlayerTiles = new List<playersTile>();
        redPlayerTiles = new List<playersTile>();
        setMapFree();
        InitDecks(); 
	}

    private void InitDecks()
    {
        for (int i = 0; i < 15; i++)
        {
            //itt majd kell vizsgálni hogy milyen szinüenk a tileok, pl ne legyen csak prios
            playersTile temp = new playersTile();
            Tile temp2 = new Tile();
            temp2.TileColor = Random.Range(0,2);
            temp.t1 = temp2;
            temp2.TileColor = Random.Range(0, 2);
            temp.t2 = temp2;
            temp2.TileColor = Random.Range(0, 2);
            temp.t3 = temp2;
            greenPlayerTiles.Add(temp);
        }

        for (int i = 0; i < 15; i++)
        {
            //itt majd kell vizsgálni hogy milyen szinüenk a tileok, pl ne legyen csak zold
            playersTile temp = new playersTile();
            Tile temp2 = new Tile();
            temp2.TileColor = Random.Range(0, 2);
            temp.t1 = temp2;
            temp2.TileColor = Random.Range(0, 2);
            temp.t2 = temp2;
            temp2.TileColor = Random.Range(0, 2);
            temp.t3 = temp2;
            redPlayerTiles.Add(temp);
        }
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

    public bool PutElementInMatrix(int indexX, int indexY)
    {
        //most igy van (nincs rorate)
        if ( indexX >= 0 && indexX <= 19 && indexY >= 0 && indexY <= 19)
        {
            if ( gridMap[indexX, indexY, 0].isFree &&
            gridMap[indexX+1, indexY, 0].isFree &&
            gridMap[indexX+1, indexY+1, 0].isFree )
            { 
               // Tile asd =  new Tile("asd",indexY,false);
                gridMap[indexX, indexY, 0] = nextPlayerTile.t1;
                gridMap[indexX + 1, indexY, 0] = nextPlayerTile.t2;
                gridMap[indexX + 1, indexY + 1, 0] = nextPlayerTile.t3;
                return true;
            }
        }
        return false;

    }

    public void SetNextElementToPreviewElement()
    {
        // meg kell nézni hogy a playerTile-ok array üres-e

        /*
        Material[] a = GameObject.Find("TileColor1").GetComponent<MeshRenderer>().materials;
        GameObject.Find("TileColor1").GetComponent<MeshRenderer>().material = a[greenPlayerTiles[0].t1.TileColor];
        GameObject.Find("TileColor2").GetComponent<MeshRenderer>().material = a[greenPlayerTiles[0].t2.TileColor];
        GameObject.Find("TileColor3").GetComponent<MeshRenderer>().material = a[greenPlayerTiles[0].t3.TileColor];
        */
        //TileColor1Green
        switch (greenPlayerTiles[0].t1.TileColor)
        {
            case 0:
                T1CB.SetActive(true);
                T1CG.SetActive(false);
                T1CR.SetActive(false);
                break;
            case 1:
                T1CB.SetActive(false);
                T1CG.SetActive(true);
                T1CR.SetActive(false);
                break;
            case 2:
                T1CB.SetActive(false);
                T1CG.SetActive(false);
                T1CR.SetActive(true);
                break;
            default:
                break;
        }

        switch (greenPlayerTiles[0].t2.TileColor)
        {
            case 0:
                T2CB.SetActive(true);
                T2CG.SetActive(false);
                T2CR.SetActive(false);
                break;
            case 1:
                T2CB.SetActive(false);
                T2CG.SetActive(true);
                T2CR.SetActive(false);
                break;
            case 2:
                T2CB.SetActive(false);
                T2CG.SetActive(false);
                T2CR.SetActive(true);
                break;
            default:
                break;
        }

        switch (greenPlayerTiles[0].t3.TileColor)
        {
            case 0:
                T3CB.SetActive(true);
                T3CG.SetActive(false);
                T3CR.SetActive(false);
                break;
            case 1:
                T3CB.SetActive(false);
                T3CG.SetActive(true);
                T3CR.SetActive(false);
                break;
            case 2:
                T3CB.SetActive(false);
                T3CG.SetActive(false);
                T3CR.SetActive(true);
                break;
            default:
                break;
        }
        nextPlayerTile = greenPlayerTiles[0];
        greenPlayerTiles.RemoveAt(0);
    }
}
