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

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        for (int i = 0; i < Tiles.Count; i++)
        {
            for (int x = 0; x < Tiles.Count; x++)
            {
                Tiles[i].GetComponent<PipePuzzleTile>().Tiles.Add(Tiles[x]);

            }
                
            if (!Tiles[i].GetComponent<PipePuzzleTile>().EndTile && !Tiles[i].GetComponent<PipePuzzleTile>().solutionTile)
            {
                int TileInt = Random.Range(0, 3);
                switch (TileInt)
                {
                    case 0:
                        Tiles[i].GetComponent<PipePuzzleTile>().StraightTile = true;
                        Tiles[i].GetComponent<Image>().sprite = StraightSprite;
                        int RotatInt = Random.Range(0, 4);
                        Tiles[i].GetComponent<PipePuzzleTile>().SetTile(RotatInt);
                        //Tiles[i].GetComponent<PipePuzzleTile>().Child.GetComponent<Image>().sprite = StraightFillSprite;
                        //Tiles[i].transform.GetChild(0).gameObject.GetComponent<Image>().sprite = StraightFillSprite;
                        //Tile[i].GetComponent<PipePuzzleTile>().TilesX = 
                        break;
                    case 1:
                        Tiles[i].GetComponent<PipePuzzleTile>().TTile = true;
                        Tiles[i].GetComponent<Image>().sprite = TTileSprite;
                        int Rotat1Int = Random.Range(0, 4);
                        Tiles[i].GetComponent<PipePuzzleTile>().SetTile(Rotat1Int);
                        //Tiles[i].GetComponent<PipePuzzleTile>().Child.GetComponent<Image>().sprite = TTileFillSprite;
                        //Tiles[i].transform.GetChild(0).gameObject.GetComponent<Image>().sprite = TTileFillSprite;
                        break;
                    case 2:
                        Tiles[i].GetComponent<PipePuzzleTile>().ArmTile = true;
                        Tiles[i].GetComponent<Image>().sprite = ArmTileSprite;
                        int Rotat2Int = Random.Range(0, 4);
                        Tiles[i].GetComponent<PipePuzzleTile>().SetTile(Rotat2Int);
                        //Tiles[i].GetComponent<PipePuzzleTile>().Child.GetComponent<Image>().sprite = ArmTileFillSprite;
                        //Tiles[i].transform.GetChild(0).gameObject.GetComponent<Image>().sprite = ArmTileFillSprite;
                        break;

                }
            }
        }
    }
    // public void Rotate(int i)
    //{

    //}
    // Update is called once per frame
    void Update()
    {

    }
}
