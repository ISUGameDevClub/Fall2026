using UnityEngine;
using UnityEngine.UI;
public class PipePuzzleManager : MonoBehaviour
{
    [SerializeField] private GameObject[] Tiles; 
    [SerializeField] private Sprite StraightSprite;
    [SerializeField] private Sprite TTileSprite;
    [SerializeField] private Sprite ArmTileSprite;
    [SerializeField] private Sprite StraightFillSprite;
    [SerializeField] private Sprite TTileFillSprite;
    [SerializeField] private Sprite ArmTileFillSprite;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        for (int i = 0; i < Tiles.Length; i++)
        {
            if (!Tiles[i].GetComponent<PipePuzzleTile>().EndTile)
            {
                int TileInt = Random.Range(0, 3);
                switch(TileInt)
                {
                    case 0:
                    Tiles[i].GetComponent<PipePuzzleTile>().StraightTile = true;
                    Tiles[i].GetComponent<Image>().sprite = StraightSprite;
                    if (i != 0 && i != 5 && i != 10 && i != 15 && i != 20)
                    {
                        
                    //Tiles[i].GetComponent<PipePuzzleTile>().ConnectingTiles[0] = (Tiles[(i-1)]); 
                    Tiles[i].GetComponent<PipePuzzleTile>().SetConnectingTiles(Tiles[(i - 1)]);
                    }
                    if (i != 4 && i != 9 && i != 14 && i != 19 && i != 24)
                    {
                        Tiles[i].GetComponent<PipePuzzleTile>().SetConnectingTiles(Tiles[(i + 1)]);
                        //Tiles[i].GetComponent<PipePuzzleTile>().ConnectingTiles[1] = Tiles[(i + 1)];
                    }
                    Tiles[i].GetComponent<PipePuzzleTile>().Child.GetComponent<Image>().sprite = StraightFillSprite;
                    //Tiles[i].transform.GetChild(0).gameObject.GetComponent<Image>().sprite = StraightFillSprite;

                        break;
                    case 1:
                        Tiles[i].GetComponent<PipePuzzleTile>().TTile = true;
                        Tiles[i].GetComponent<Image>().sprite  = TTileSprite;
                        if (i != 0 && i != 5 && i != 10 && i != 15 && i != 20)
                        {
                            Tiles[i].GetComponent<PipePuzzleTile>().SetConnectingTiles(Tiles[i - 1]);

                        }
                        if (i != 4 && i !=9 && i != 14 && i != 19 && i != 24)
                        {
                            Tiles[i].GetComponent<PipePuzzleTile>().SetConnectingTiles(Tiles[i + 1]);
                        }
                        if (i != 20 && i != 21 && i != 22 && i != 23 && i != 24)
                        {
                            Tiles[i].GetComponent<PipePuzzleTile>().SetConnectingTiles(Tiles[i + 5]);
                        }
                        Tiles[i].GetComponent<PipePuzzleTile>().Child.GetComponent<Image>().sprite = TTileFillSprite;
                    //Tiles[i].transform.GetChild(0).gameObject.GetComponent<Image>().sprite = TTileFillSprite;
                        break;
                    case 2:
                        Tiles[i].GetComponent<PipePuzzleTile>().ArmTile = true;
                        Tiles[i].GetComponent<Image>().sprite = ArmTileSprite;
                        if (i != 0 && i != 5 && i != 10 && i != 15 && i != 20)
                    {
                        
                    //Tiles[i].GetComponent<PipePuzzleTile>().ConnectingTiles[0] = (Tiles[(i-1)]); 
                    Tiles[i].GetComponent<PipePuzzleTile>().SetConnectingTiles(Tiles[(i - 1)]);
                    }
                    if (i != 20 && i != 21 && i != 22 && i != 23 && i != 24)
                        {
                            Tiles[i].GetComponent<PipePuzzleTile>().SetConnectingTiles(Tiles[i + 5]);
                        }
                        Tiles[i].GetComponent<PipePuzzleTile>().Child.GetComponent<Image>().sprite = ArmTileFillSprite;
                    //Tiles[i].transform.GetChild(0).gameObject.GetComponent<Image>().sprite = ArmTileFillSprite;
                        break;
                    
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
