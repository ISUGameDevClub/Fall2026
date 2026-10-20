using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
public class PipePuzzleManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> Tiles = new List<GameObject>();
    [SerializeField] private Sprite StraightSprite;
    [SerializeField] private Sprite TTileSprite;
    [SerializeField] private Sprite ArmTileSprite;
    [SerializeField] private Sprite StraightFillSprite;
    [SerializeField] private Sprite TTileFillSprite;
    [SerializeField] private Sprite ArmTileFillSprite;
    public bool PuzzleSolved;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        for (int i = 0; i < Tiles.Count; i++)
        {
            for (int x = 0; x < Tiles.Count; x++)
            {
                Tiles[i].GetComponent<PipePuzzleTile>().Tiles.Add(Tiles[x]);

            }
            
            int TileInt = Random.Range(0, 3);
            switch (TileInt)
            {
                case 0:
                    if (!Tiles[i].GetComponent<PipePuzzleTile>().EndTile)
                    {
                        if (!Tiles[i].GetComponent<PipePuzzleTile>().solutionTile)
                        {

                            Tiles[i].GetComponent<PipePuzzleTile>().StraightTile = true;
                            Tiles[i].GetComponent<Image>().sprite = StraightSprite;
                            Tiles[i].transform.GetChild(0).gameObject.GetComponent<Image>().sprite = StraightFillSprite;
                        }
                        int RotatInt = Random.Range(0, 4);
                        Tiles[i].GetComponent<PipePuzzleTile>().SetTile(RotatInt, false);
                    }
                    else
                    {
                        Tiles[i].GetComponent<PipePuzzleTile>().CheckEndTile();
                    }
                    break;
                case 1:
                    if (!Tiles[i].GetComponent<PipePuzzleTile>().EndTile)
                    {
                        if (!Tiles[i].GetComponent<PipePuzzleTile>().solutionTile)
                        {

                            Tiles[i].GetComponent<PipePuzzleTile>().TTile = true;
                            Tiles[i].GetComponent<Image>().sprite = TTileSprite;
                            Tiles[i].transform.GetChild(0).gameObject.GetComponent<Image>().sprite = TTileFillSprite;
                        }
                        int Rotat1Int = Random.Range(0, 4);
                        Tiles[i].GetComponent<PipePuzzleTile>().SetTile(Rotat1Int, false);
                    }
                    else
                    {
                        Tiles[i].GetComponent<PipePuzzleTile>().CheckEndTile();
                    }
                     break;
                case 2:
                    if (!Tiles[i].GetComponent<PipePuzzleTile>().EndTile)
                    {
                        if (!Tiles[i].GetComponent<PipePuzzleTile>().solutionTile)
                        {

                            Tiles[i].GetComponent<PipePuzzleTile>().ArmTile = true;
                            Tiles[i].GetComponent<Image>().sprite = ArmTileSprite;
                            Tiles[i].transform.GetChild(0).gameObject.GetComponent<Image>().sprite = ArmTileFillSprite;
                        }
                        int Rotat2Int = Random.Range(0, 4);
                        Tiles[i].GetComponent<PipePuzzleTile>().SetTile(Rotat2Int, false);
                    }
                    else
                    {
                        Tiles[i].GetComponent<PipePuzzleTile>().CheckEndTile();
                    }
                    break;
            }


        }
        foreach (GameObject Tile in Tiles)
        {
            Tile.GetComponent<PipePuzzleTile>().CheckWater();
        }
    }
    void Update()
    {

    }
}
