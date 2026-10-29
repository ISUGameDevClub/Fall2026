using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
public class PipePuzzleManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> Tiles = new List<GameObject>();
    private readonly List<PipePuzzleTile> waterSources = new List<PipePuzzleTile>();
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
        foreach (GameObject tile in Tiles)
        {
            PipePuzzleTile pipeTile = tile.GetComponent<PipePuzzleTile>();
            if (pipeTile.watered)
            {
                waterSources.Add(pipeTile);
            }
        }

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
        RecalculateWater();
    }

    public void RecalculateWater()
    {
        foreach (GameObject tile in Tiles)
        {
            tile.GetComponent<PipePuzzleTile>().ConnectingTiles.Clear();
        }

        foreach (GameObject tile in Tiles)
        {
            PipePuzzleTile pipeTile = tile.GetComponent<PipePuzzleTile>();
            if (pipeTile.EndTile)
            {
                pipeTile.CheckEndTile();
            }
            else
            {
                pipeTile.SetTile(pipeTile.manualRotationInt, true);
            }
        }

        foreach (GameObject tile in Tiles)
        {
            tile.GetComponent<PipePuzzleTile>().watered = false;
        }

        Queue<PipePuzzleTile> pendingTiles = new Queue<PipePuzzleTile>();
        foreach (PipePuzzleTile source in waterSources)
        {
            source.watered = true;
            pendingTiles.Enqueue(source);
        }

        while (pendingTiles.Count > 0)
        {
            PipePuzzleTile currentTile = pendingTiles.Dequeue();
            foreach (GameObject connectedObject in currentTile.ConnectingTiles)
            {
                PipePuzzleTile connectedTile = connectedObject.GetComponent<PipePuzzleTile>();
                if (!connectedTile.watered && connectedTile.ConnectingTiles.Contains(currentTile.gameObject))
                {
                    connectedTile.watered = true;
                    pendingTiles.Enqueue(connectedTile);
                }
            }
        }
    }

    void Update()
    {

    }
}
