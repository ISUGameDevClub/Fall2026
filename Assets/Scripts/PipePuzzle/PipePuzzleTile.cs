using UnityEngine;
using System.Collections.Generic;
//using System;
using UnityEngine.UI;
public class PipePuzzleTile : MonoBehaviour
{
    public bool watered;
    public List<GameObject> ConnectingTiles = new List<GameObject>();
    public bool EndTile;
    public bool EndSolutionTile;
    public bool StraightTile, TTile, ArmTile, solutionTile;
    public List<GameObject> Tiles = new List<GameObject>();
    public GameObject Child;
    //
    public int TilesX;
    public int EndTileRotateX;
    public int manualRotationInt;
    public int lastRotatInt;

    //EndTileRotateX  0 = no rotation
    //EndTileRotateX 1 = 90 degrees 
    //EndTileRotateX 2 = 180 degrees
    //EndTileRotateX 3 = 270 degrees
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }
    //Check if the one of the connected tiles are watered, water the next connected tile
    public void CheckWater()
    {
        foreach (GameObject Tiles in ConnectingTiles)
        {
            if (Tiles.GetComponent<PipePuzzleTile>().ConnectingTiles.Contains(gameObject))
            {
                if (Tiles.GetComponent<PipePuzzleTile>().watered)
                {
                    watered = true;
                }
            }
        }
        foreach (GameObject Tile in ConnectingTiles)
        {
            if (Tile.GetComponent<PipePuzzleTile>().ConnectingTiles.Contains(gameObject))
            {
                if (watered)
                {
                    Tile.GetComponent<PipePuzzleTile>().watered = true;
                }
            }
        }
        if (ConnectingTiles.Count == 0)
        {
            watered = false;
        }

    }

    public void CheckEndTile()
    {
        if (EndTileRotateX == 0)
        {
            if (TilesX < 20)
            {
                ConnectingTiles.Add(Tiles[TilesX + 5].gameObject);
            }
        }
        else if (EndTileRotateX == 1)
        {
            if (TilesX < 24)
            {
                ConnectingTiles.Add(Tiles[TilesX + 1].gameObject);
            }
        }
        else if (EndTileRotateX == 2)
        {
            if (TilesX > 4)
            {
                ConnectingTiles.Add(Tiles[TilesX - 5].gameObject);
            }
        }
        else if (EndTileRotateX == 3)
        {
            if (TilesX > 0)
            {
                ConnectingTiles.Add(Tiles[TilesX - 1].gameObject);
            }
        }

    }
    public void SetTile(int RotateInt, bool manual)
    {
        if (!manual)
        {

            manualRotationInt = RotateInt;
        }
        if (!EndTile)
        {
            if (RotateInt == 0)
            {
                if (StraightTile)
                {
                    if (TilesX > 0)
                    {
                        if (TilesX == 5 || TilesX == 10 || TilesX == 15 || TilesX == 20)
                        {

                        }
                        else
                        {
                            ConnectingTiles.Add(Tiles[TilesX - 1].gameObject);
                        }
                    }
                    if (TilesX < 24)
                    {
                        if (TilesX == 4 || TilesX == 9 || TilesX == 14 || TilesX == 19)
                        {

                        }
                        else
                        {
                            ConnectingTiles.Add(Tiles[TilesX + 1].gameObject);
                        }
                    }
                }
                else if (TTile)
                {
                    if (TilesX > 0)
                    {
                        if (TilesX == 5 || TilesX == 10 || TilesX == 15 || TilesX == 20)
                        {

                        }
                        else
                        {
                            ConnectingTiles.Add(Tiles[TilesX - 1].gameObject);
                        }
                    }
                    if (TilesX < 24)
                    {
                        if (TilesX == 4 || TilesX == 9 || TilesX == 14 || TilesX == 19)
                        {

                        }
                        else
                        {
                            ConnectingTiles.Add(Tiles[TilesX + 1].gameObject);
                        }
                    }
                    if (TilesX < 20)
                    {
                        ConnectingTiles.Add(Tiles[TilesX + 5].gameObject);
                    }

                }
                else if (ArmTile)
                {
                    if (TilesX > 0)
                    {
                        if (TilesX == 5 || TilesX == 10 || TilesX == 15 || TilesX == 20)
                        {

                        }
                        else
                        {
                            ConnectingTiles.Add(Tiles[TilesX - 1].gameObject);

                        }
                    }
                    if (TilesX < 20)
                    {
                        ConnectingTiles.Add(Tiles[TilesX + 5].gameObject);

                    }

                }
            }
            else if (RotateInt == 1)
            {
                Quaternion newRotation = new Quaternion(0, 0, 90, 1);
                if (manual)
                {

                }
                else
                {

                    transform.Rotate(0, 0, 90);
                }
                manualRotationInt = RotateInt;
                if (StraightTile)
                {
                    if (TilesX > 4)
                    {
                        ConnectingTiles.Add(Tiles[TilesX - 5].gameObject);
                    }
                    if (TilesX < 20)
                    {
                        ConnectingTiles.Add(Tiles[TilesX + 5].gameObject);
                    }
                }
                else if (TTile)
                {

                    if (TilesX < 24)
                    {
                        if (TilesX == 4 || TilesX == 9 || TilesX == 14 || TilesX == 19)
                        {

                        }
                        else
                        {
                            ConnectingTiles.Add(Tiles[TilesX + 1].gameObject);
                        }
                    }

                    if (TilesX > 4)
                    {
                        ConnectingTiles.Add(Tiles[TilesX - 5].gameObject);
                    }
                    if (TilesX < 20)
                    {
                        ConnectingTiles.Add(Tiles[TilesX + 5].gameObject);
                    }
                }
                else if (ArmTile)
                {

                    if (TilesX < 24)
                    {
                        if (TilesX == 4 || TilesX == 9 || TilesX == 14 || TilesX == 19)
                        {

                        }
                        else
                        {
                            ConnectingTiles.Add(Tiles[TilesX + 1].gameObject);

                        }
                    }
                    if (TilesX < 20)
                    {
                        ConnectingTiles.Add(Tiles[TilesX + 5].gameObject);
                    }

                }

                // }

            }
            else if (RotateInt == 2)
            {

                //Debug.Log(gameObject.name + " should be rotated 180 degrees");
                //if (transform.rotation.z < 0)
                // {
                //   transform.rotation = new Quaternion(0, 0, transform.rotation.z * -1, 1);
                // }
                // if (EndTile)
                //{
                //  if (TilesX > 4)
                //    {
                //       ConnectingTiles.Add(Tiles[TilesX - 5].gameObject);
                //    }
                //  }
                // else
                //  {
                Quaternion newRotation = new Quaternion(0, 0, 180, 1);
                if (manual)
                {

                }
                else
                {
                    transform.Rotate(0, 0, 180);
                }
                manualRotationInt = RotateInt;
                if (StraightTile)
                {
                    if (TilesX > 0)
                    {
                        if (TilesX == 5 || TilesX == 10 || TilesX == 15 || TilesX == 20)
                        {

                        }
                        else
                        {
                            ConnectingTiles.Add(Tiles[TilesX - 1].gameObject);
                        }
                    }
                    if (TilesX < 24)
                    {
                        if (TilesX == 4 || TilesX == 9 || TilesX == 14 || TilesX == 19)
                        {

                        }
                        else
                        {
                            ConnectingTiles.Add(Tiles[TilesX + 1].gameObject);
                        }
                    }
                }
                else if (TTile)
                {
                    if (TilesX > 0)
                    {
                        if (TilesX == 5 || TilesX == 10 || TilesX == 15 || TilesX == 20)
                        {

                        }
                        else
                        {
                            ConnectingTiles.Add(Tiles[TilesX - 1].gameObject);
                        }
                    }
                    if (TilesX < 24)
                    {
                        if (TilesX == 4 || TilesX == 9 || TilesX == 14 || TilesX == 19)
                        {

                        }
                        else
                        {
                            ConnectingTiles.Add(Tiles[TilesX + 1].gameObject);
                        }
                    }
                    if (TilesX > 4)
                    {
                        ConnectingTiles.Add(Tiles[TilesX - 5].gameObject);
                    }
                }
                else if (ArmTile)
                {
                    if (TilesX > 4)
                    {

                        ConnectingTiles.Add(Tiles[TilesX - 5].gameObject);


                    }
                    if (TilesX < 24)
                    {
                        if (TilesX == 9 || TilesX == 14 || TilesX == 19)
                        {

                        }
                        else
                        {
                            ConnectingTiles.Add(Tiles[TilesX + 1].gameObject);
                        }
                    }
                }
            }
            else if (RotateInt == 3)
            {
                Quaternion newRotation = new Quaternion(0, 0, 270, 1);
                if (manual)
                {

                }
                else
                {
                    transform.Rotate(0, 0, 270);
                }
                manualRotationInt = RotateInt;
                if (StraightTile)
                {
                    if (TilesX > 4)
                    {
                        ConnectingTiles.Add(Tiles[TilesX - 5].gameObject);
                    }
                    if (TilesX < 20)
                    {
                        ConnectingTiles.Add(Tiles[TilesX + 5].gameObject);
                    }
                }
                else if (TTile)
                {
                    if (TilesX > 0)
                    {
                        if (TilesX == 5 || TilesX == 10 || TilesX == 15 || TilesX == 20)
                        {

                        }
                        else
                        {
                            ConnectingTiles.Add(Tiles[TilesX - 1].gameObject);
                        }
                    }

                    if (TilesX > 4)
                    {
                        ConnectingTiles.Add(Tiles[TilesX - 5].gameObject);
                    }
                    if (TilesX < 20)
                    {
                        ConnectingTiles.Add(Tiles[TilesX + 5].gameObject);
                    }
                }
                else if (ArmTile)
                {
                    if (TilesX > 4)
                    {

                        ConnectingTiles.Add(Tiles[TilesX - 5].gameObject);

                    }

                    if (TilesX > 0)
                    {
                        if (TilesX == 5 || TilesX == 10 || TilesX == 15 || TilesX == 20)
                        {

                        }
                        else
                        {
                            ConnectingTiles.Add(Tiles[TilesX - 1].gameObject);
                        }
                    }
                }
            }
        }
    }
    public void Rotate()
    {
        if (!EndTile)
        {
            //clear and set tile 0 of all surrounding connecting tiles before clearing 
            //set tile of the current tile and all surrounding tiles
            foreach (GameObject tile in ConnectingTiles)
            {
                tile.GetComponent<PipePuzzleTile>().ConnectingTiles.Clear();
            }
            ConnectingTiles.Clear();
            watered = false;
            transform.Rotate(0, 0, 180 / 2, Space.Self);
            if (manualRotationInt < 3)
            {
                manualRotationInt++;
                SetTile(manualRotationInt, true);
            }
            else if (manualRotationInt == 3)
            {
                manualRotationInt = 0;
                SetTile(manualRotationInt, true);
            }
            foreach (GameObject why in ConnectingTiles)
            //check do the setTile of the original 
            {
                if (why.GetComponent<PipePuzzleTile>().EndTile)
                {
                    why.GetComponent<PipePuzzleTile>().CheckEndTile();

                }
                else
                {
                    why.GetComponent<PipePuzzleTile>().SetTile(why.GetComponent<PipePuzzleTile>().manualRotationInt, true);

                }
                why.GetComponent<PipePuzzleTile>().CheckWater();
            }
            CheckWater();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (watered)
        {

            Child.GetComponent<Image>().fillAmount += .10f;
            if (EndSolutionTile)
            {
                if (!transform.parent.gameObject.GetComponent<PipePuzzleManager>().PuzzleSolved)
                {
                    transform.parent.gameObject.GetComponent<PipePuzzleManager>().PuzzleSolved = true;

                    Debug.Log("Puzzle Solved");
                }
            }
        }
        else
        {
            Child.GetComponent<Image>().fillAmount = 0;
        }

    }
}
