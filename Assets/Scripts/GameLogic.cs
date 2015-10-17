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
        public int TileColor { get; set; } // 0 - zold, 1 - fekete, 2 - piros
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

    // GUI ELEMEK
    public GameObject T1CG; // tile1colorGreen
    public GameObject T1CB; // tile1colorGreen
    public GameObject T1CR; // tile1colorGreen

    public GameObject T2CG; // tile2colorGreen
    public GameObject T2CB; // tile2colorGreen
    public GameObject T2CR; // tile2colorGreen

    public GameObject T3CG; // tile3colorGreen
    public GameObject T3CB; // tile3colorGreen
    public GameObject T3CR; // tile3colorGreen

    public UnityEngine.UI.Text remainingGC; //green count
    public UnityEngine.UI.Text remainingRC;

    public GameObject gameEndPanel;
    public UnityEngine.UI.Text winnerText;

    //GAME LOGIC 
    Tile[, ,] gridMap;
    List<playersTile> greenPlayerTiles;
    List<playersTile> redPlayerTiles;
    playersTile nextPlayerTile;
    string actualPlayer;

    void Awake()
    {
       gameEndPanel.SetActive(false);
       chooseStart();
    }
	// Use this for initialization
	void Start () {
	    gridMap = new Tile[20, 20, 3];
        greenPlayerTiles = new List<playersTile>();
        redPlayerTiles = new List<playersTile>();
        setMapFree();
        InitDecks();
        updateText();
	}

    private void chooseStart ()
    {
        int res = Random.Range(0, 2); // 0 v 1
        if (res == 1)
            actualPlayer = "G";
        else
            actualPlayer = "R";
    }

    private void updateText()
    {
        remainingGC.text = "Remaining tiles: " + greenPlayerTiles.Count;
        remainingRC.text = "Remaining tiles: " + redPlayerTiles.Count;
    }

    void Update()
    {
        updateText();

    }
    
    void FixedUpdate()
    {
        finishGame();
    }

    private void finishGame()
    {
        if (redPlayerTiles.Count == 0 && greenPlayerTiles.Count == 0 && Time.timeScale != 0 )
        {
            winnerText.text += actualPlayer;
            gameEndPanel.SetActive(true);
            GameObject.Find("Map_v2").GetComponent<BoxCollider>().enabled = false;
            Time.timeScale = 0;
            UnityEngine.Time.timeScale = 0;
        }
    }

    private void InitDecks()
    {
        for (int i = 0; i < 1; i++)
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

        for (int i = 0; i < 1; i++)
        {
            //itt majd kell vizsgálni hogy milyen szinüenk a tileok, pl ne legyen csak zold
            playersTile temp = new playersTile();
            Tile temp2 = new Tile();
            temp2.TileColor = Random.Range(1, 3);
            temp.t1 = temp2;
            temp2.TileColor = Random.Range(1, 3);
            temp.t2 = temp2;
            temp2.TileColor = Random.Range(1, 3);
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
        List<playersTile> tiles = new List<playersTile>();
        if (actualPlayer == "G")
            tiles = greenPlayerTiles;
        else
            tiles = redPlayerTiles;

        if (tiles.Count == 0)
            return;

        //TileColor1Green
        switch (tiles[0].t1.TileColor)
        {
            case 0:
                T1CG.SetActive(true);
                T1CB.SetActive(false);
                T1CR.SetActive(false);
                break;
            case 1:
                T1CG.SetActive(false);
                T1CB.SetActive(true);
                T1CR.SetActive(false);
                break;
            case 2:
                T1CG.SetActive(false);
                T1CB.SetActive(false);
                T1CR.SetActive(true);
                break;
            default:
                break;
        }

        switch (tiles[0].t2.TileColor)
        {
            case 0:
                T2CG.SetActive(true);
                T2CB.SetActive(false);
                T2CR.SetActive(false);
                break;
            case 1:
                T2CG.SetActive(false);
                T2CB.SetActive(true);
                T2CR.SetActive(false);
                break;
            case 2:
                T2CG.SetActive(false);
                T2CB.SetActive(false);
                T2CR.SetActive(true);
                break;
            default:
                break;
        }

        switch (tiles[0].t3.TileColor)
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

        nextPlayerTile = tiles[0];

    }

    public void SwitchPlayer()
    {
        if (actualPlayer == "G")
        {
            actualPlayer = "R";
            return;
        }
        if (actualPlayer == "R")
        {
            actualPlayer = "G";
            return;
        }
    }

    public void RemoveFirstTile()
    {
        if (actualPlayer == "G")
            greenPlayerTiles.RemoveAt(0);
        else
            redPlayerTiles.RemoveAt(0);
    }
}
